using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalhaOtomasyon.Fonksiyonlar
{
    class Formlar
    {

        #region StokFormlari
        public int StokListesi(bool Secim=false)
        {
            Modul_Stok.frmStokListesi frm = new Modul_Stok.frmStokListesi();
            if(Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }
        
        public int StokGruplari(bool Secim =false)
        {
            Modul_Stok.frmStokGruplari frm= new Modul_Stok.frmStokGruplari();
            if (Secim)
            {
                frm.Secim = Secim;
            }
            frm.ShowDialog();
            return AnaForm.Aktarma;
        }

        public void StokHareketleri(bool Ac=false)
        {

        }

        public void StokKarti(bool Ac=false)
        {
            Modul_Stok.frmStokKarti frm = new Modul_Stok.frmStokKarti();
            frm.ShowDialog();
        }
        #endregion
        #region CariFormlari
        public int CariGruplari(bool Secim=false)
        {
            Modul_Cari.frmCariGruplari frm = new Modul_Cari.frmCariGruplari();
            if (Secim)
            {
                frm.Secim = Secim;
            }
            frm.ShowDialog();
            return AnaForm.Aktarma;
        }
        public int CariListesi(bool Secim =false)
        {
            Modul_Cari.frmCariListesi frm = new Modul_Cari.frmCariListesi();
            if (Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }
        public void CariAcilisKarti(bool Ac=false,int CariID=-1)
        {
            Modul_Cari.frmCariAcilisKarti frm = new Modul_Cari.frmCariAcilisKarti();
            if (Ac)
            {
                frm.Ac(CariID);
            }
            frm.ShowDialog();
        }

        #endregion
        #region kasaFormlari
        public void KasaAcilisKarti()
        {
            Modul_Kasa.frmKasaAcilisKarti frm = new Modul_Kasa.frmKasaAcilisKarti();
            frm.ShowDialog();
        }
        public void KasaDevirIslemKarti(bool Ac = false, int IslemID = -1)
        {
            Modul_Kasa.frmKasaDevirIslem frm = new Modul_Kasa.frmKasaDevirIslem();
            if (Ac)
            {
                frm.Ac(IslemID);
            }
            frm.ShowDialog();
        }
        public int KasaListesi(bool Secim=false)
        {
            Modul_Kasa.frmKasaListesi frm = new Modul_Kasa.frmKasaListesi();
            if (Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }
        public void KasaTahsilatOdemeKarti(bool Ac = false, int ID = -1)
        {
            Modul_Kasa.frmKasaTahsilatOdeme frm = new Modul_Kasa.frmKasaTahsilatOdeme();
            if (Ac)
            {
                frm.Ac(ID);
            }
            frm.ShowDialog();
        }
        public void KasaHareketleri(bool Ac = false, int ID = -1)
        {
            Modul_Kasa.frmKasaHareketleri frm = new Modul_Kasa.frmKasaHareketleri();
            frm.MdiParent = AnaForm.ActiveForm;
            if(Ac)
            {
                frm.Ac(ID);
            }
            frm.Show();
        }
        #endregion
        #region BankaFormlari
        public void BankaAcilisKarti()
        {
            Modul_Banka.frmBankaAcilisKarti frm = new Modul_Banka.frmBankaAcilisKarti();
            frm.ShowDialog();
        }
        public void BankaIslem(bool Ac = false, int ID = -1)
        {
            Modul_Banka.frmBankaIslem frm = new Modul_Banka.frmBankaIslem();
            if (Ac)
            {
                frm.Ac(ID);
            }
            frm.ShowDialog();
        }
        public int BankaListesi(bool Secim=false)
        {
            Modul_Banka.frmBankaListesi frm = new Modul_Banka.frmBankaListesi();
            if (Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }
        public void BankaParaTransfer(bool AC=false,int ID=-1)
        {
            Modul_Banka.frmParaTransfer frm = new Modul_Banka.frmParaTransfer();
            if(AC)
            {
                frm.Ac(ID);
            }
            frm.ShowDialog();
        }
        public void BankaHareketleri(bool Ac=false,int ID=-1)
        {
            Modul_Banka.frmBankaHareketleri frm = new Modul_Banka.frmBankaHareketleri();
            frm.MdiParent = AnaForm.ActiveForm;
            if (Ac)
            {
                frm.BankaAc(ID);
            }
            frm.Show();
        }
        #endregion

        public void Fatura(bool Ac = false, int ID = -1)
        {
            Modul_Fatura.frmSatisFaturasi frm;
            if (Ac)
            {
               frm = new Modul_Fatura.frmSatisFaturasi(Ac,ID);
            }
            else
            {
                frm =new  Modul_Fatura.frmSatisFaturasi();
            }
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();
        }
    }
}
