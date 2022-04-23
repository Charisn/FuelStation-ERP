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

public partial class CashierForm : Form
{
    public CashierForm()
    {
        InitializeComponent();
        Cursor = Cursors.WaitCursor;
    }

    private void btnCashierExit_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        CustomersForm customersForm = new CustomersForm();
        customersForm.ShowDialog();
    }

    private void btnTransaction_Click(object sender, EventArgs e)
    {
        TransactionForm transactionForm = new TransactionForm();
        transactionForm.ShowDialog();
    }
}
