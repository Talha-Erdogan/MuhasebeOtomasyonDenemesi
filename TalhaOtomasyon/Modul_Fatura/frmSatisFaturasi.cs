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

namespace TalhaOtomasyon.Modul_Fatura
{
    public partial class frmSatisFaturasi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();

        int CariID = -1;
        int OdemeID = -1;
        int FaturaID = -1;
        int IrsaliyeID = -1;


        public frmSatisFaturasi()
        {
            InitializeComponent();
        }
        public frmSatisFaturasi(bool Edit,int ID)
        {
            InitializeComponent();
        }
        private void frmSatisFaturasi_Load(object sender, EventArgs e)
        {
            txtFaturaTarihi.Text = DateTime.Now.ToShortDateString();
            txtIrsaliyeTarihi.Text = DateTime.Now.ToShortDateString();
        }

        private void btnStokSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int StokID = Formlar.StokListesi(true);
            if (StokID > 0)
            {
                Fonksiyonlar.TBL_STOKLAR Stok= DB.TBL_STOKLAR.First(s => s.ID == StokID);
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("MIKTAR", 0);
                gridView1.SetFocusedRowCellValue("BARKOD", Stok.STOKBARKOD);
                gridView1.SetFocusedRowCellValue("STOKKODU", Stok.STOKKODU);
                gridView1.SetFocusedRowCellValue("STOKADI", Stok.STOKADI);
                gridView1.SetFocusedRowCellValue("BIRIM", Stok.STOKBIRIM);
                gridView1.SetFocusedRowCellValue("BIRIMFIYAT", Stok.STOKSATISFIYAT);
                gridView1.SetFocusedRowCellValue("KDV",Stok.STOKSATISKDV);
            }
            AnaForm.Aktarma = -1;

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            decimal Miktar = 0, BirimFiyat = 0, Toplam = 0;
            try
            {
                if (e.Column.Name != "colTOPLAM")
                {
                    Miktar = decimal.Parse(gridView1.GetFocusedRowCellValue("MIKTAR").ToString());
                    if (gridView1.GetFocusedRowCellValue("BIRIMFIYAT").ToString() != "")
                    {
                        BirimFiyat = decimal.Parse(gridView1.GetFocusedRowCellValue("BIRIMFIYAT").ToString());
                    }

                    Toplam = Miktar * BirimFiyat;
                    gridView1.SetFocusedRowCellValue("TOPLAM", Toplam.ToString());
                    Hesapla();
                }
            }   
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

           
        }


        void Hesapla()
        {
            try
            {

                decimal BirimFiyat = 0, Miktar = 0, GenelToplam = 0, AraToplam = 0, KDV = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    BirimFiyat = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    Miktar = decimal.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString())/100+1;
                    AraToplam += Miktar * BirimFiyat;
                    GenelToplam += decimal.Parse(gridView1.GetRowCellValue(i, "TOPLAM").ToString()) * KDV;
                }
                txtAraToplam.Text = AraToplam.ToString("0.00");
                txtKDV.Text =(GenelToplam-AraToplam).ToString("0.00");
                txtGenelToplam.Text = GenelToplam.ToString("0.00");

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.CariListesi(true);
            if (ID>0)
            {
                CariSec(ID);
            }
            AnaForm.Aktarma = -1;
        }
        void CariSec(int ID)
        {
            try
            {
                CariID = ID;
                Fonksiyonlar.TBL_CARILER Cari = DB.TBL_CARILER.First(s => s.ID == CariID);
                txtCariKodu.Text = Cari.CARIKODU;
                txtCariAdi.Text = Cari.CARIDADI;
            }
            catch (Exception e)
            {

                Mesajlar.Hata(e);
            }
        }

        private void txtFaturaTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFaturaTuru.SelectedIndex==0)
            {
                pnlOdemeYerleri.Enabled = false;
            }
            if (txtFaturaTuru.SelectedIndex==1)
            {
                pnlOdemeYerleri.Enabled = true;
            }
        }

        private void txtOdemeYeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFaturaTuru.SelectedIndex==0)
            {
                txtHesapAdi.Enabled = false;
                txtHesapNo.Enabled = false;
                txtKasaAdi.Enabled = true;
                txtKasaKodu.Enabled = true;
                    
            }
            if (txtFaturaTuru.SelectedIndex==1)
            {
                txtHesapAdi.Enabled = true;
                txtHesapNo.Enabled = true;
                txtKasaAdi.Enabled = false;
                txtKasaKodu.Enabled = false;
            }
        }
    }
}