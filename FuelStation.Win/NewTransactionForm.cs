using FuelStation.Model.Enums;
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

public partial class NewTransactionForm : Form
{
    private TransactionViewModel _transaction;
    private TransactionHandler _transactionHandler = new();
    private List<EmployeeViewModel> _employeeList = new();
    private CustomerViewModel _customer = new();
    private bool _isEditing = false;
    private bool _hasFuel = false;
    private Guid _transactionID = Guid.Empty;
    private CustomerHandler _customerHandler = new();
    private List<CustomerViewModel> _customerList = new();

    public NewTransactionForm(CustomerViewModel customer)
    {
        InitializeComponent();
        _customer = customer;
        TransactionViewModel _transaction = new();
        _transaction.TransactionLines = new List<TransactionLineViewModel>();
    }
    public NewTransactionForm(Guid ID)
    {
        InitializeComponent();
        _transactionID = ID;
        _isEditing = true;
    }
    private async void NewTransactionForm_Load(object sender, EventArgs e)
    {
        _transaction = await _transactionHandler.GetTransactionByID(_transactionID);
        _employeeList = await _transactionHandler.GetEmployees();
        bsTransaction.DataSource = _transaction;
        PopulateControls();
        PopulateLines();
        SetBindings();
        _transaction.CustomerID = _customer.ID;
        txtCustomer.ReadOnly = true;
        _transaction.Status = true;
    }
    public void NewCustomerFormClose()
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private async void simpleButton1_Click(object sender, EventArgs e) // Save
    {
        if(comboEmployee.SelectedIndex == -1)
        {
            MessageBox.Show("Please Select an Employee First", "Warning");
            return;
        }
        else
        {
            if (_transactionID == Guid.Empty)
            {
                await _transactionHandler.CreateTransaction(_transaction);
            }
            else
            {
                await _transactionHandler.PutTransaction(_transaction);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
    void SetBindings()
    {
        comboEmployee.DataBindings.Add(new Binding("SelectedValue", bsTransaction, "EmployeeID", true));
        comboPay.DataBindings.Add(new Binding("ValueMember", bsTransaction, "PaymentMethod", true));
        spinTotal.DataBindings.Add(new Binding("Value", bsTransaction, "TotalValue", true));
        spinNetPrice.DataBindings.Add(new Binding("Value", bsTLines, "NetValue", true));
        spinDiscountPercent.DataBindings.Add(new Binding("Value", bsTLines, "DiscountPercentage", true));
        spinDiscountValue.DataBindings.Add(new Binding("Value", bsTLines, "DiscountValue", true));
        spinQty.DataBindings.Add(new Binding("Value", bsTLines, "Quantity", true));
    }
    private async void PopulateControls()
    {
        if (_employeeList is not null)
        {
            comboEmployee.DataSource = _employeeList;
            comboEmployee.DisplayMember = "Surname";
            comboEmployee.ValueMember = "ID";
            txtDate.Text = DateTime.Now.ToString();
            comboPay.DataSource = Enum.GetValues(typeof(PaymentMethodEnum));
        }

        if (!_isEditing)
        {
            txtCustomer.Text = _customer.Name + " " + _customer.Surname;
        }
        else
        {
            txtCustomer.Visible = false;
            var findCustomer = await _customerHandler.GetCustomerByID(_transaction.CustomerID);
            _transaction.CustomerID = findCustomer.ID;
            txtCustomer.ReadOnly = true;
            label2.Visible = false;
        }
        spinDiscountPercent.Visible = false;
        label6.Visible = false;
    }

    void PopulateLines()
    {
        bsTLines.DataSource = _transaction.TransactionLines;

        grdTLine.DataSource = null;
        grdTLine.DataSource = bsTLines;
        grvTLine.Columns["ID"].Visible = false;
        grvTLine.Columns["Status"].Visible = false;
        grvTLine.Columns["DiscountPercentage"].Visible = false;
        grvTLine.Columns["ItemID"].Visible = false;
    }

    private async void btnAddLine_Click(object sender, EventArgs e)
    {
        if (_isEditing is true)
        {
            MessageBox.Show("Cannot add items while editing. Please make a new transaction", "Warning");
            return;
        }
        if (_transaction is null)
        {
            _transaction = new();
            _transaction.TransactionLines = new();
        }

        AddLineForm form = new AddLineForm(bsTLines);
        form.ShowDialog();

        UpdateTransactionLines((TransactionLineViewModel)bsTLines.Current);

        _transaction.TotalValue = _transactionHandler.CalculateTransactionTotalValue(_transaction.TransactionLines.Select(x => x.TotalValue).ToList());

        spinTotal.Value = (decimal)_transaction.TotalValue;

        if (!_transactionHandler.CheckCardPaymentAvail(_transaction.TotalValue))
        {
            comboPay.SelectedIndex = (int)PaymentMethodEnum.Cash;
        }

        PopulateLines();
    }

    private async void simpleButton3_Click(object sender, EventArgs e) // delete
    {
        var selectedLine = grvTLine.GetFocusedRow() as TransactionLineViewModel;
        if (selectedLine is not null)
            _transaction.TransactionLines.Remove(selectedLine);

        if (selectedLine.ItemType == ItemTypeEnum.Fuel)
        {
            _hasFuel = false;
        }

        UpdateTransactionLines(selectedLine);
        bsTLines.Remove(selectedLine);
        PopulateLines();
        grvTLine.RefreshData();
    }
    private async void UpdateTransactionLines(TransactionLineViewModel transactionLine)
    {
        _transactionHandler.CheckDiscount(transactionLine);
        transactionLine.NetValue =  _transactionHandler.CalculateNetValue(transactionLine.Quantity, transactionLine.ItemPrice);
        transactionLine.DiscountValue = _transactionHandler.ApplyTenPercentDiscount(transactionLine.NetValue, transactionLine.DiscountPercentage, transactionLine.ItemType);
        transactionLine.TotalValue = _transactionHandler.CalculateLineTotalValue(transactionLine.DiscountValue, transactionLine.NetValue);
        _transactionHandler.CalculateTotal(_transaction);
    }

    private void spinQty_EditValueChanged(object sender, EventArgs e)
    {
        var line = grvTLine.GetFocusedRow() as TransactionLineViewModel;
        if (line is null) return;

        UpdateTransactionLines(line);
        CheckPaymentMethod();
        grvTLine.RefreshData();
    }

    private void grvTLine_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
        var line = grvTLine.GetRow(e.RowHandle) as TransactionLineViewModel;
        if (line is null) return;


        UpdateTransactionLines(line);
        _transactionHandler.CheckDiscount(line);
        _transactionHandler.CalculateTotal(_transaction);

        spinTotal.Value = _transaction.TotalValue;
        CheckPaymentMethod();
    }
    public void CheckPaymentMethod()
    {
        if (_transaction.TotalValue > 50)
        {
            _transaction.PaymentMethod = PaymentMethodEnum.Cash;
            comboPay.SelectedIndex = (int)_transaction.PaymentMethod;
            comboPay.Enabled = false;
        }
        else
        {
            comboPay.Enabled = true;
        }
    }
    private void simpleButton2_Click(object sender, EventArgs e) // Exit
    {
        this.Close();
    }
}
