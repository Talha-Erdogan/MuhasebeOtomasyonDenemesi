using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using System.Threading.Tasks;

namespace TalhaOtomasyon.Fonksiyonlar
{
    class Numara
    {
        Fonksiyonlar.DatabaseDataContext DB = new DatabaseDataContext();
        Mesajlar Mesajlar = new Mesajlar();
        public string StokGrupKodNumarasi()
        {
            try
            {
                int Numara = int.Parse(
                    (from s in DB.TBL_STOKGRUPLARI orderby s.ID descending select s).First().GRUPKODU
                    );
                Numara++;
                string num = Numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {

                return "00000001";
            }
        }
        public string StokKodNumarasi()
        {
            try
            {
                int Numara = int.Parse(
                    (from s in DB.TBL_STOKLAR orderby s.ID descending select s).First().STOKKODU 
                    );
                Numara++;
                string num = Numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {

                return "00000001";
            }
        }

        public string CariKodNumarasi()
        {
            try
            {
                int Numara = int.Parse(
                    (from s in DB.TBL_CARILER orderby s.ID descending select s).First().CARIKODU
                    );
                Numara++;
                string num = Numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {

                return "00000001";
            }
        }


        public string KasaKodNumarasi()
        {
            try
            {
                int Numara = int.Parse(
                    (from s in DB.TBL_KASALAR orderby s.ID descending select s).First().KASAKODU
                    );
                Numara++;
                string num = Numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {

                return "00000001";
            }
        }

    }
}
