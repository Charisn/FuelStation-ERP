using FuelStation.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win;

public partial class LoginForm : Form
{
    readonly HttpClient httpClient = new();
    private readonly Login _login = new();
    public LoginForm()
    {
        InitializeComponent();
    }
    private void LoginForm_Load(object sender, EventArgs e)
    {
        textBox2.Text = "";
        textBox2.PasswordChar ='\u25CF';
    }

    private async void Authenticate(Login login)
    {
        Cursor = Cursors.WaitCursor;
        var response = await LoginCheck(login);

        switch (response.EmployeeType)
        {
            case Model.Enums.EmployeeTypeEnum.Manager:
                MessageBox.Show("Logging in as Manager!", "Success");
                textBox1.Text = null;
                textBox2.Text = null;
                ManagerForm form = new();
                form.ShowDialog();
                break;
            case Model.Enums.EmployeeTypeEnum.Staff:
                MessageBox.Show("Logging in as Staff!", "Success");
                textBox1.Text = null;
                textBox2.Text = null;
                StaffForm form1 = new();
                form1.ShowDialog();
                break;
            case Model.Enums.EmployeeTypeEnum.Cashier:
                MessageBox.Show("Logging in as Cashier!", "Success");
                textBox1.Text = null;
                textBox2.Text = null;
                CashierForm form2 = new();
                form2.ShowDialog();
                break;
            default:
                MessageBox.Show("Wrong Username Or Password");
                textBox1.Text = null;
                textBox2.Text = null;
                break;
        }
        Cursor = Cursors.Default;
    }
    private async Task<Login>LoginCheck(Login login)
    {
       var response = await httpClient.PostAsJsonAsync("https://localhost:7060/authentication/", login);
        return await response.Content.ReadFromJsonAsync<Login>();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        _login.Username = textBox1.Text;
        _login.Password = textBox2.Text;
        Authenticate(_login);
    }
    private void CancelButtonManager_Click(object sender, EventArgs e)
    {
        var dr = MessageBox.Show("Close Application?", Text, MessageBoxButtons.YesNo);
        if (dr == DialogResult.No)
        {
            return;
        }
        this.Close();
    }
}