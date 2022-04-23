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

public partial class NewCustomerForm : Form
{
    private CustomerViewModel _customer = new();
    private bool _isEditing = false;
    private CustomerHandler _customerHandler = new();

    public NewCustomerForm()
    {
        InitializeComponent();
        _isEditing = false;
    }
    public NewCustomerForm(CustomerViewModel customer)
    {
        InitializeComponent();
        _customer = customer;
        _isEditing = true;
    }
    private void NewCustomerForm_Load(object sender, EventArgs e)
    {
        if(_isEditing)
        {
            txtCusName.EditValue = _customer.Name;
            txtCusSurname.EditValue = _customer.Surname;
        }
    }

    private async void btnNewCustomer_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(txtCusName.Text) || string.IsNullOrWhiteSpace(txtCusSurname.Text))
        {
            MessageBox.Show("Please fill the empty fields", "Warning");
            return;
        }

        if (txtCusName.Text.Any(x => char.IsDigit(x)) is true
        || txtCusSurname.Text.Any(x => char.IsDigit(x)) is true)
        {
            MessageBox.Show("Customer name and surname cannot have numbers");
            return;
        }
        
        await SaveCustomer(_customer);
    }

    private void btnCloseCustomer_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    async Task SaveCustomer(CustomerViewModel customer)
    {
        customer.Name = txtCusName.Text;
        customer.Surname = txtCusSurname.Text;

        var msg = MessageBox.Show("Save Customer?", Text, MessageBoxButtons.OKCancel);
        if (msg != DialogResult.OK) return;
        if (!_isEditing)
        {
            customer.ID = _customer.ID;
            customer.CardNumber = _customer.CardNumber;
            await _customerHandler.CreateCustomer(customer);
        }
        else
        {
            await _customerHandler.PutCustomer(customer);
        }

        this.Close();
    }
}
