using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlOlusturma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Linq ile Xml'e veri basma
            /*List<Ogrenci> Ogrencilerim = new List<Ogrenci>();
            
            for (int i = 0; i < 50; i++)
            {   //Veritabanı yerine Fake Data kullanılmıştır ve içerisinde bir sürü data oldugu için sadece 50 tane seçilmiştir.
                Ogrenci temp = new Ogrenci();
                temp.Id = Guid.NewGuid();
                temp.Isim = FakeData.NameData.GetFirstName();
                temp.Soysim = FakeData.NameData.GetSurname();
                temp.Numara = FakeData.PhoneNumberData.GetPhoneNumber();
                Ogrencilerim.Add(temp);
            }
            XDocument Doc = new XDocument(
                new XDeclaration("1.0", "UTF-8", "no"),
                new XElement("Ogrencilerim", Ogrencilerim.Select(x =>
               new XElement("Ogrenci",
               new XElement("Id", x.Id),
               new XElement("Isim", x.Isim),
               new XElement("Soyisim", x.Soysim),
               new XElement("Numara", x.Numara)
               ))));
            Doc.Save(@"e:\\xml\\Ogrencilerim.xml");
            */
            #endregion

            #region Xml'i Okuma
            XDocument DocOku = XDocument.Load(@"e:\\xml\\Ogrencilerim.xml");
            List<XElement> OkunanXElements = DocOku.Descendants("Ogrenci").ToList();
            List<Ogrenci> OkunanData = new List<Ogrenci>();


            foreach (XElement item in OkunanXElements)
            {
                Ogrenci temp = new Ogrenci();
                temp.Id=Guid.Parse(item.Element("Id").Value);
                temp.Isim = item.Element("Isim").Value;
                temp.Soysim = item.Element("Soyisim").Value;
                temp.Numara = item.Element("Numara").Value;
                OkunanData.Add(temp);
            }

            foreach (Ogrenci item in OkunanData)
            {
                Console.WriteLine("Id : "+item.Id);
                Console.Write("Tam adı : "+item.Isim+" ");
                Console.WriteLine(item.Soysim);
                Console.WriteLine("Numara : "+item.Numara);
                Console.WriteLine();
            }


            Console.ReadKey();
            #endregion
        }
    }
}
