using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using FuelStation.Shared.ViewModels;
using FuelStation.Win.Handlers;
using FuelStation.Model.Entities;

namespace FuelStation.Win
{
    public partial class ManagerForm : Form
    {
        readonly HttpClient httpClient = new();
        private readonly Login _login = new();

        public ManagerForm()
        {
            InitializeComponent();
        }

        private async void ManagerForm_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\u25CF';
        }
        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new();
            customersForm.ShowDialog();
        }

        public async Task LoadCustomersFromServer()
        {
            await httpClient.GetFromJsonAsync<List<CustomerViewModel>>("https://localhost:7060/customer/");
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new();
            itemListForm.ShowDialog();
        }

        private void btnMainExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new();
            transactionForm.ShowDialog();
        }
        private async Task CreateManager(Login login)
        {
            login.Username = textBox1.Text;
            login.Password = textBox2.Text;
            Cursor = Cursors.WaitCursor;
            var resposne = await httpClient.PostAsJsonAsync("https://localhost:7060/authentication/createnewmanager", login);
            resposne.EnsureSuccessStatusCode();
            if (resposne.IsSuccessStatusCode)
                MessageBox.Show("New manager Username/Password Created", "Success");

        }
        private async Task CreateStaff(Login login)
        {
            login.Username = textBox1.Text;
            login.Password = textBox2.Text;
            Cursor = Cursors.WaitCursor;
            var resposne = await httpClient.PostAsJsonAsync("https://localhost:7060/authentication/createnewstaff", login);
            if (resposne.IsSuccessStatusCode)
                MessageBox.Show("New staff Username/Password Created", "Success");

        }
        private async Task CreateCashier(Login login)
        {
            login.Username = textBox1.Text;
            login.Password = textBox2.Text;
            Cursor = Cursors.WaitCursor;
            var resposne = await httpClient.PostAsJsonAsync("https://localhost:7060/authentication/createnewcashier", login);
            if (resposne.IsSuccessStatusCode)
                MessageBox.Show("New cashier Username/Password Created", "Success");

        }
        private void MesageForUser()
        {
            var message = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (message == DialogResult.No)
            {
                return;
            }
            Cursor = Cursors.WaitCursor;
        }

        private async void btnCreateManager_Click_1(object sender, EventArgs e)
        {
            MesageForUser();
            await CreateManager(_login);
        }

        private async void btnCreateCashier_Click_1(object sender, EventArgs e)
        {
            MesageForUser();
            await CreateCashier(_login);
        }

        private async void btnCreateStaff_Click_1(object sender, EventArgs e)
        {
            MesageForUser();
            await CreateStaff(_login);
        }
    }
}
