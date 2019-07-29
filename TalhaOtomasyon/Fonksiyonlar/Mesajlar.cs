using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace TalhaOtomasyon.Fonksiyonlar
{
    //Program içerisinde uyarılar vermek için olusturdugumuz classtır.
    //örnegin güncelleme gerceklessin mi? veya silme işlemini onaylıyor msunuz diye sorguladııgmız kısımdır.

    class Mesajlar
    {
        //yeni kayıt eklendiğinde bilgi verdiğimiz fonksiyondur.
        public void YeniKayit(string Mesaj)
        {
            MessageBox.Show(Mesaj,  "...Yeni Kayit Girisi...",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        //guncelleme islemi gerceklessin mi diye uyarı verdiğimiz kısımdır. DialogResult olmasının sebebi ise bize onaylıyor musuunz diye sormasından kaynaklanmaktadır.
        public DialogResult Guncelle()
        {
            return MessageBox.Show("Seçili kalıcı olarak guncellenecektir.\n Guncelleme islemini onaylıyor musunuz= ","Guncelleme Islemi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

        }
        //silme islemini onaylıyor musunuz diye sordugumuz kısımdır.
        public DialogResult Sil()
        {
            return MessageBox.Show("Seçili kalıcı olarak silinecektir.\n Silme islemini onaylıyor musunuz= ", "Silme Islemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }
        //guncellenmiştir bilgisi
        public void Guncelle(bool Guncelleme)
        {
            MessageBox.Show("Kayit Guncellenmistir", "Kayit Guncelleme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        //hata olguunda bilgi verdiğimiz kısımdır.
        public void Hata(Exception Hata)
        {
            MessageBox.Show(Hata.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void GirisHatasi(string Hata)
        {
            MessageBox.Show(Hata, "Giris Hatasi Olustu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
