using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace TalhaOtomasyon.Fonksiyonlar
{
    //Stok resmimizi koymak veya onu tekrardan getir dediğimizde kullandıgımız classtır.
    //Veri tabanına nasıl resim eklenir vs onu görüyoruz burada.
    //using System.IO; ve using System.Drawing; kutuphaneleri önemli burada.
    //pictureboxta bunları koyabiliyoruz bu sekilde

    class Resimleme
    {
        //ilk resim yukle diye buton yaptıgımızda,mesela masaustundeki bir  resmetıklayıp ekleyebişiyorz bu sekilde.
        public byte[] ResimYukleme(System.Drawing.Image Resim)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Resim.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        //veri tabanından vs veriyi cekip, pictureboxta sergileyebileceiğimiz kod parcasıdır.
        public Image ResimGetirme(byte[] GelenByteArray)
        { 
            using (MemoryStream ms = new MemoryStream(GelenByteArray))
            {
                Image resim = Image.FromStream(ms);
                return resim;
            }
        }
    }
}
