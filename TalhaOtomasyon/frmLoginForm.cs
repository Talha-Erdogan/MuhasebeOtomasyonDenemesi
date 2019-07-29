using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TalhaOtomasyon
{
    public partial class frmLoginForm : DevExpress.XtraEditors.XtraForm
    {
        public frmLoginForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            AnaForm frm = new AnaForm();
            frm.Show();
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
            frmAyar frm = new frmAyar();
            frm.ShowDialog();
        }

        private void frmLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}