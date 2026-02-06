using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace OgrenciYonetimUygulamasi
{
    internal class Program
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        static void Main(string[] args)
        {
            Uygulama();
            

        }

        static void Uygulama()
        {
            SahteVeriEkle();
            SecimAL();

            


        }


        static void OgrenciEkle()
        {
            
            Ogrenci o = new Ogrenci();

            Console.WriteLine("----- Öğrenci Ekle ------");
            Console.WriteLine((ogrenciler.Count+1)+". Öğrencinin");

            Console.Write("No: ");
            
            while (true)
            {
                
                int girilenNo = int.Parse(Console.ReadLine());

                bool varMi = true;
                foreach (Ogrenci item in ogrenciler)
                {
                    if (item.No == girilenNo)
                    {
                        varMi = false;
                        break;
                    }

                }
                if (varMi == false)
                {
                    Console.WriteLine("Bu numaraya sahip öğrenci zaten var.");
                    Console.Write("Lütfen başka bir numara giriniz: ");
                }
                else
                {
                    o.No = girilenNo;
                    break;
                }
            }
            
                

            Console.Write("Adı: ");
            o.Ad = Console.ReadLine();

            o.Ad= o.Ad.Substring(0, 1).ToUpper() + o.Ad.Substring(1).ToLower(); ;
            
            
            Console.Write("Soyadı: ");
            o.Soyad = Console.ReadLine();

            o.Soyad= o.Soyad.Substring(0, 1).ToUpper()+ o.Soyad.Substring(1).ToLower(); ;
           
            

            Console.Write("Şubesi: ");
            o.Sube = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H) :  ");
            string secim = Console.ReadLine().ToUpper();

            if (secim == "E")
            {
                ogrenciler.Add(o);
                Console.WriteLine("Öğrenci eklendi. ");
            }
            else
            {
                Console.WriteLine("Öğrenci eklenmedi.");
            }
            Console.WriteLine();
        }

        static void OgrenciListele()
        {
            if (ogrenciler.Count != 0)
            {
                Console.WriteLine();
                Console.WriteLine("---------Öğrenci Listele---------");
                Console.WriteLine("Şube".PadRight(8) +"No".PadRight(8) + "Ad"+ " " + "Soyad");
                Console.WriteLine("--------------------------------- ");


                foreach (Ogrenci item in ogrenciler)
                {
                Console.WriteLine(item.Sube.PadRight(8) + (item.No.ToString().PadRight(8))+ item.Ad + " " + item.Soyad);
                }
            }
            else
            {
                Console.WriteLine("Gösterilecek öğrenci yok.");

            }

        }

        static void OgrenciSil()
        {
            Console.WriteLine("------ Öğrenci Sil ------- ");

            if (ogrenciler.Count != 0)
            {
                Console.WriteLine("Silmek istediğiniz öğrencinin");
                Console.Write("No: ");
                int no = int.Parse(Console.ReadLine());

                Ogrenci ogr = null;

                foreach (Ogrenci item in ogrenciler)
                {
                    if (item.No == no)
                    {
                        ogr = item;
                        break;
                    }
                }
                if (ogr != null)
                {
                    Console.WriteLine("Adı: " + ogr.Ad);
                    Console.WriteLine("Soyadı: " + ogr.Soyad);
                    Console.WriteLine("Şubesi: " + ogr.Sube);
                    Console.WriteLine();
                    Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E/H) : ");

                    string secim = Console.ReadLine().ToUpper();

                    if (secim == "E")
                    {
                        ogrenciler.Remove(ogr);
                        Console.WriteLine("Öğrenci silindi.");

                    }
                    else if (secim == "H")
                    {
                        Console.WriteLine("Öğrenci silinmedi.");

                    }

                    }
                    else
                    {
                        Console.WriteLine("Öğrenci Bulunamadı.");
                    }
            }
            else
            {
                Console.WriteLine("Listede silinecek öğrenci yok");
             
            }




                }
            
            

        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1 - Öğrenci Ekle(E)");
            Console.WriteLine("2 - Öğrenci Listele(L)");
            Console.WriteLine("3 - Öğrenci Sil(S)");
            Console.WriteLine("4 - Çıkış(X)");
            Console.WriteLine();
            
        }

        static void SahteVeriEkle()
        {


            Ogrenci o1 = new Ogrenci();
            o1.Ad = "Güney";
            o1.Soyad = "Cin";
            o1.Sube = "A";
            o1.No = 1;

            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Ali";
            o2.Soyad = "Yılmaz";
            o2.No = 2;
            o2.Sube = "B";

            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Ayşe";
            o3.Soyad = "Yıldız";
            o3.Sube = "C";
            o3.No = 3;

            ogrenciler.Add(o1);
            ogrenciler.Add(o2);
            ogrenciler.Add(o3);
        }
        
        static void SecimAL()
        {

            
            int hata = 10;
            do
            {
                Menu();
                Console.Write("Seçiminiz : ");
                string secim = Console.ReadLine().ToUpper();

                switch (secim)
                {
                    case "1":
                    case "E":

                        OgrenciEkle();
                        break;
                    case "2":
                    case "L":
                        OgrenciListele();
                        break;
                    case "3":
                    case "S":
                        OgrenciSil();
                        break;
                    case "4":
                    case "X":
                        Console.WriteLine("Program sonlandırılıyor...");
                        return;

                    default:
                        Console.WriteLine("Hatalı giriş yapıldı.!!!");
                        hata--;
                        break;
                }
                if (hata <= 0)
                {

                    Console.WriteLine();
                    Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                    return;
                }
                Console.ReadLine();
                Console.Clear();
            }
            while (true);
           
            
                
            

                
            
                
        }
    }
}
