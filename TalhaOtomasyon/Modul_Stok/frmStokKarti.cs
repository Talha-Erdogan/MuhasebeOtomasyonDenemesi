﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TalhaOtomasyon.Modul_Stok
{
    public partial class frmStokKarti : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Resimleme Resimleme = new Fonksiyonlar.Resimleme();



        bool Edit=false;
        bool Resim = false;
        int GrupID = -1;
        OpenFileDialog Dosya = new OpenFileDialog();
        int StokID = -1;

        public frmStokKarti()
        {
            InitializeComponent();
        }

        private void frmStokKarti_Load(object sender, EventArgs e)
        {
            txtStokKodu.Text = Numaralar.StokKodNumarasi();
        }


        void Temizle()
        {
            txtStokKodu.Text = Numaralar.StokKodNumarasi();
            txtStokAdi.Text = "";
            txtSatisKDV.Text = "0";
            txtSatisFiyat.Text = "0";
            txtGrupAdi.Text = "";
            txtGrupKodu.Text = "";
            txtBirim.SelectedIndex = 0;
            txtBarkod.Text = "";
            txtAlisKDV.Text = "";
            txtAlisFiyat.Text = "0";
            pictureBox1.Image = null;
            Edit = false;
            Resim = false;
            GrupID = -1;
            StokID = -1;
            AnaForm.Aktarma = -1;

        }
        void ResimSec()
        {
            Dosya.Filter = "Jpg(*.jpg)|*.jpg|Jpeg(*.jpeg)|*.jpeg";
            if (Dosya.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = Dosya.FileName;
                Resim = true;
            }
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            ResimSec();
        }
        void YeniKayit()
        {
            try
            {
                Fonksiyonlar.TBL_STOKLAR Stok = new Fonksiyonlar.TBL_STOKLAR();
                Stok.STOKADI = txtStokAdi.Text;
                Stok.STOKALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
                Stok.STOKALISKDV = decimal.Parse(txtAlisKDV.Text);
                Stok.STOKBARKOD = txtBarkod.Text;
                Stok.STOKBIRIM = txtBirim.Text;
                Stok.STOKGRUPID = GrupID;
                Stok.STOKKODU = txtStokKodu.Text;
                Stok.STOKRESIM = new System.Data.Linq.Binary(Resimleme.ResimYukleme(pictureBox1.Image));
                Stok.STOKSATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
                Stok.STOKSATISKDV = decimal.Parse(txtSatisKDV.Text);
                Stok.STOKSAVEDATE = DateTime.Now;
                Stok.STOKSAVEUSER = AnaForm.UserID;
                DB.TBL_STOKLAR.InsertOnSubmit(Stok);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("Yeni Stok Kaydı Oluşturuldu...");
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);

            }
            
        }
        void Guncelle()
        {
            try
            {
                Fonksiyonlar.TBL_STOKLAR Stok = DB.TBL_STOKLAR.First(s => s.ID == StokID);
                Stok.STOKADI = txtStokAdi.Text;
                Stok.STOKALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
                Stok.STOKALISKDV = decimal.Parse(txtAlisKDV.Text);
                Stok.STOKBARKOD = txtBarkod.Text;
                Stok.STOKBIRIM = txtBirim.Text;
                Stok.STOKGRUPID = GrupID;
                Stok.STOKKODU = txtStokKodu.Text;
                if (Resim)
                {
                    Stok.STOKRESIM = new System.Data.Linq.Binary(Resimleme.ResimYukleme(pictureBox1.Image));
                }
                Stok.STOKSATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
                Stok.STOKSATISKDV = decimal.Parse(txtSatisKDV.Text);
                Stok.STOKEDITDATE = DateTime.Now;
                Stok.STOKEDITUSER = AnaForm.UserID;
                DB.TBL_STOKLAR.InsertOnSubmit(Stok);
                DB.SubmitChanges();
                Mesajlar.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);

            }
        }
        void Sil()
        {
            try
            {
                DB.TBL_STOKLAR.DeleteOnSubmit(DB.TBL_STOKLAR.First(s => s.ID == StokID));
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }
        void GrupAc(int ID)
        {
            GrupID = ID;
            txtGrupAdi.Text = DB.TBL_STOKGRUPLARI.First(s => s.ID == GrupID).GRUPADI;
            txtGrupKodu.Text = DB.TBL_STOKGRUPLARI.First(s => s.ID == GrupID).GRUPKODU;
        }
        public void Ac(int ID)
        {
            Edit = true;
            StokID = ID;
            Fonksiyonlar.TBL_STOKLAR Stok = DB.TBL_STOKLAR.First(s => s.ID == StokID);
            GrupAc(Stok.STOKGRUPID.Value);
            pictureBox1.Image = Resimleme.ResimGetirme(Stok.STOKRESIM.ToArray());
            txtAlisFiyat.Text = Stok.STOKALISFIYAT.ToString();
            txtAlisKDV.Text = Stok.STOKALISKDV.ToString();
            txtBarkod.Text = Stok.STOKBARKOD;
            txtBirim.Text = Stok.STOKBIRIM;
            txtSatisFiyat.Text = Stok.STOKSATISFIYAT.ToString();
            txtSatisKDV.Text = Stok.STOKSATISKDV.ToString();
            txtStokAdi.Text = Stok.STOKADI;
            txtStokKodu.Text = Stok.STOKKODU;
        }

        private void txtStokKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.StokListesi(true);
            if (ID>0)
            {
                Ac(ID);
                
            }
            AnaForm.Aktarma = -1;
        }

        private void txtGrupKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.StokGruplari(true);
            if(ID>0)
            {
                GrupAc(ID);

            }
            AnaForm.Aktarma = -1;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && StokID > 0 &&Mesajlar.Sil()==DialogResult.Yes)
            {
                Sil();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && StokID > 0 && Mesajlar.Guncelle()==DialogResult.Yes)
            {
                Guncelle();

            }
            else
            {
                YeniKayit();
            }
        }
    }
}