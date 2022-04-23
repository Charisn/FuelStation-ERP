using FuelStation.Shared.ViewModels;
using FuelStation.Win.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win;

public partial class TransactionForm : Form
{
    private CustomerViewModel _customer = new();
    private TransactionViewModel _transaction = new();
    private List<TransactionViewModel> _transactionList = new();
    private TransactionHandler _transactionHandler = new();

    public TransactionForm()
    {
        InitializeComponent();
    }
    private async void TransactionForm_Load(object sender, EventArgs e)
    {
        PopulateTransactions();
        TimerRefresh();
    }
    private void btnNewTransaction_Click(object sender, EventArgs e)
    {
        FindCustomer findCustomer = new(_customer);
        findCustomer.Show();
        PopulateTransactions();
    }
    private async void btnEditTransaction_Click(object sender, EventArgs e)
    {
        _transaction = grvTransaction.GetFocusedRow() as TransactionViewModel;
        if (_transaction is null)
            return;

        NewTransactionForm newTransactionForm = new NewTransactionForm(_transaction.ID);
        newTransactionForm.ShowDialog();
        
        PopulateTransactions();
    }
    private async void btnDeleteTransaction_Click(object sender, EventArgs e)
    {
        _transaction = grvTransaction.GetFocusedRow() as TransactionViewModel;

        if (_transaction is not null)
        {
            var dialog = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel);
            if(dialog == DialogResult.OK)
            {
                await _transactionHandler.DeleteTransaction(_transaction);
                PopulateTransactions();
            }
            return;
        }
    }
    private void btnExitTransaction_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
        PopulateTransactions();
    }
    private async void PopulateTransactions()
    {
        _transactionList = await _transactionHandler.GetTransactions();

        bsTransaction.DataSource = _transactionList;
        grdTransaction.DataSource = _transactionList;

        grvTransaction.Columns["ID"].Visible = false;
        grvTransaction.Columns["Status"].Visible = false;
        grvTransaction.Columns["EmployeeID"].Visible = false;
        grvTransaction.Columns["CustomerID"].Visible = false;
        grvTransaction.Columns["TotalValue"].OptionsColumn.AllowEdit = false;
        grvTransaction.Columns["PaymentMethod"].OptionsColumn.AllowEdit = false;
        grvTransaction.Columns["DateTime"].OptionsColumn.AllowEdit = false;

        grvTransaction.RefreshData();
    }
    private void TimerRefresh()
    {
        timer1.Enabled = true;
        timer1.Interval = 6000;
    }
    private async void timer1_Tick(object sender, EventArgs e)
    {
        _transactionList = await _transactionHandler.GetTransactions();
        grdTransaction.DataSource = _transactionList;
        grvTransaction.RefreshData();
    }
}
