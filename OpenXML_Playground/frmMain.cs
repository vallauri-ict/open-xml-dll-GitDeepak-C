using System;
using System.Windows.Forms;

namespace OpenXML_Playground
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            frmWord frm = new frmWord();
            frm.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            frmExcel frm = new frmExcel();
            frm.Show();
        }
    }
}
