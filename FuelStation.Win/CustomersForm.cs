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

public partial class CustomersForm : Form
{
    private CustomerViewModel _customer;
    private List<CustomerViewModel> _customerList = new();
    private CustomerHandler _customerHandler = new();
    private bool _showDel = false;
    public CustomersForm()
    {
        InitializeComponent();
    }
    private async void CustomersForm_Load(object sender, EventArgs e)
    {
        await LoadCustomersFromServer();
        TimerRefresh();
    }
    public async Task LoadCustomersFromServer()
    {
        _customerList = await _customerHandler.GetCustomers();
        BindCustomersToGrid();
    }
        
    public async Task LoadDeletedCustomersFromServer()
    {
        _customerList = await _customerHandler.GetDeletedCustomers();
        BindCustomersToGrid();
    }

    private void btnNewCustomer_Click(object sender, EventArgs e)
    {
        NewCustomerForm frm = new NewCustomerForm();
        frm.ShowDialog();
        grvCustomers.RefreshData();
    }
    private async void btnEditCustomer_Click(object sender, EventArgs e)
    {
        var customer = bsCustomers.Current as CustomerViewModel;
        if (customer == null) return;

        NewCustomerForm form = new NewCustomerForm(customer);
        form.ShowDialog();
        await _customerHandler.PutCustomer(customer);
    }

    private async void btnDeleteCustomer_Click(object sender, EventArgs e)
    {
        var dr = MessageBox.Show("Delete Customer?", Text, MessageBoxButtons.OKCancel);
        if (dr == DialogResult.Cancel)
        {
            return;
        }
        var customer = bsCustomers.Current as CustomerViewModel;
        if (customer == null) return;
        await _customerHandler.DeleteCustomer(customer);
    }

    private async void btnShowDeletedCustomers_Click(object sender, EventArgs e)
    {
        _showDel = true;
        _customerList = new();
        await LoadDeletedCustomersFromServer();
        BindCustomersToGrid();
        btnDeleteCustomer.Text = "Undo Customer";
        Cursor.Current = Cursors.WaitCursor;
    }

    private async void btnShowCurrentCustomers_Click(object sender, EventArgs e)
    {
        _showDel = false;
        _customerList = new();
        await LoadCustomersFromServer();
        BindCustomersToGrid();
        btnDeleteCustomer.Text = "Delete Customer";
        Cursor.Current = Cursors.WaitCursor;
    }
    private void TimerRefresh()
    {
        cusTimer.Enabled = true;
        cusTimer.Interval = 6000;
    }
    
    private async void cusTimer_Tick(object sender, EventArgs e)
    {
        if (_showDel)
        {
            await LoadDeletedCustomersFromServer();
            grvCustomers.RefreshData();
        }
        else
        {
            await LoadCustomersFromServer();
            grvCustomers.RefreshData();
        }
    }
    private void btnCloseCustomer_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BindCustomersToGrid()
    {
        bsCustomers.DataSource = _customerList;
        grdCustomers.DataSource = bsCustomers;
        grvCustomers.Columns["ID"].Visible = false;
        grvCustomers.Columns["Status"].Visible = false;
        grvCustomers.RefreshData();
    }
}
