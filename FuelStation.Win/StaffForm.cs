using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win
{
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
            Cursor = Cursors.WaitCursor;
        }

        private void btnStaffExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemListForm item = new();
            item.ShowDialog();
        }
    }
}
