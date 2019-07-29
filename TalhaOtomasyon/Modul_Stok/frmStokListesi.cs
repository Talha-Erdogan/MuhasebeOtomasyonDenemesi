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
using System.Data.Linq;



namespace TalhaOtomasyon.Modul_Stok
{
    public partial class frmStokListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        int SecimID = -1;

        public bool Secim = false;
        public frmStokListesi()
        {
            InitializeComponent();
        }

        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.TBL_STOKLAR
                      where s.STOKADI.Contains(txtStokAdi.Text) && s.STOKBARKOD.Contains(txtStokKodu.Text) && s.STOKKODU.Contains(txtStokKodu.Text) 
                       select s;
            Liste.DataSource = lst;

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtStokKodu.Text = "";
            txtStokAdi.Text = "";
            txtBarkod.Text = "";
        }
        
        void Sec()
        {
            try
            {
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString() );

            }
            catch (Exception)
            {

                SecimID = -1;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if(Secim && SecimID>0)
            {
                AnaForm.Aktarma = SecimID;
                this.Close();

            }

        }
    }
}