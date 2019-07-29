﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TalhaOtomasyon.Modul_Banka
{
    public partial class frmBankaListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();

        public bool Secim = false;
        int SecimID = -1;
        public frmBankaListesi()
        {
            InitializeComponent();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {

        }

        private void frmBankaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            var lst = from s in DB.VW_BANKALISTESI
                      where s.HESAPADI.Contains(txtHesapAdi.Text) && s.HESAPNO.Contains(txtHesapNo.Text) && s.IBAN.Contains(txtIban.Text)
                      select s;
            Liste.DataSource = lst;
                
        }
        void Sec()
        {
            try
            {
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            }
            catch (Exception e)
            {

                SecimID = -1;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim&& SecimID>0)
            {
                AnaForm.Aktarma = SecimID;
                this.Close();
            }
        }
    }
}