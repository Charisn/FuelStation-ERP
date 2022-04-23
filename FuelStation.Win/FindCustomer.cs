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

public partial class FindCustomer : Form
{
    private List<CustomerViewModel> _customerList = new();
    private CustomerHandler _customerHandler = new();
    private CustomerViewModel _customer = new();
    private bool _customerFound = false;
    private Guid _transactionID = Guid.Empty;
    public FindCustomer(CustomerViewModel customer)
    {
        InitializeComponent();
        _customer = customer;
    }
    private async void FindCustomer_Load(object sender, EventArgs e)
    {
        _customerList = await _customerHandler.GetCustomers();
        BindComboToList();
    }
    private void BindComboToList()
    {
        foreach (var card in _customerList)
        {
            comboCustomerCard.Items.Add(card.CardNumber);
            comboName.Items.Add(card.Name + " " + card.Surname);
        }
        comboCustomerCard.SelectedIndex = -1;        
    }

    private void btnFindCard_Click(object sender, EventArgs e)
    {
        foreach (var customer in _customerList)
        {
            if (customer.CardNumber == textBox1.Text)
            {
                MessageBox.Show($"Success! Customer found with card: {customer.CardNumber}", "Success!");
                this.Close();
                NewTransactionForm newTransactionForm = new NewTransactionForm(customer);
                newTransactionForm.ShowDialog();
                _customerFound = true;
            }
        }

        if(_customerFound is false)
        {
            MessageBox.Show($"Customer could not be found. Create a new one?", "Attention!", MessageBoxButtons.OKCancel);
            NewCustomerForm newCustomerForm = new NewCustomerForm();
            newCustomerForm.Show();
            this.Close();
        }
    }

    private void btnBackToList_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void comboCustomerCard_SelectedIndexChanged(object sender, EventArgs e)
    {
        textBox1.Text = comboCustomerCard.Text;
        comboName.SelectedIndex = comboCustomerCard.SelectedIndex;
    }

    private void comboName_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboCustomerCard.SelectedIndex = comboName.SelectedIndex;
    }
}
