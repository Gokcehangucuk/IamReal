using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje__IamReal
{
    internal class Program
    {
        static void Main(string[] args)
        {   // e devlet kullanıcısının bilgileri alınarak doğruluğu denetlecenecek.
            BaşaDon:
            kisi kisi = new kisi();
           
            Console.WriteLine("Lütfen adınızı giriniz");
            kisi.Ad=Console.ReadLine();

            Console.WriteLine("Lütfen Soyadınızı giriniz");
            kisi.Soyad = Console.ReadLine();

            Console.WriteLine("Lütfen Doğum yılınızı giriniz");
            kisi.DogumYili = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Lütfen TcNo giriniz");
            kisi.TcNo =long.Parse(Console.ReadLine());

            bool durum;


            
            try
            {
                using (KimlikDogrula.KPSPublicSoapClient service = new KimlikDogrula.KPSPublicSoapClient { })
                {
                    durum = service.TCKimlikNoDogrula(kisi.TcNo, kisi.Ad, kisi.Soyad, kisi.DogumYili);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (durum==true)
            {
                Console.WriteLine("Girmiş olduğunuz bilgiler DOĞRUDUR");
            }
            else 
            {
                Console.WriteLine("Sen Aslında Yoğsun");
            }
            goto BaşaDon;

        }
        class kisi 
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public int DogumYili  { get; set; }
            public long TcNo { get; set; }
        }
    }
}
