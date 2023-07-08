using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eumanav
{
    internal class Program
    {
    
        static List<string> toptanciMeyveler = new List<string>() { "Elma", "Armut", "Muz" };
        static List<string> toptanciSebzeler = new List<string>() { "Domates", "Salatalık", "Patates" };
        static Dictionary<string, double> manavMeyveler = new Dictionary<string, double>();
        static Dictionary<string, double> manavSebzeler = new Dictionary<string, double>();
        static Dictionary<string, double> musteriListesi = new Dictionary<string, double>();

        static void Main(string[] args)
        {
            Console.WriteLine("HALE HOŞGELDİNİZ\nMeyve için M, Sebze için S'ye basınız.");

            string secim = Console.ReadLine().ToUpper();

            if (secim == "M")
            {
                Console.WriteLine("Toptancının meyve listesi:");
                Listele(toptanciMeyveler);
                ManavUrunAl("meyve");
            }
            else if (secim == "S")
            {
                Console.WriteLine("Toptancının sebze listesi:");
                Listele(toptanciSebzeler);
                ManavUrunAl("sebze");
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!!");
                return;
            }

            Console.WriteLine("MANAVA HOŞGELDİNİZ\nMeyve için M, Sebze için S'ye basınız.");

            secim = Console.ReadLine().ToUpper();

            if (secim == "M")
            {
                Console.WriteLine("Manavın toptancıdan aldığı meyveler:");
                Listele(manavMeyveler);
                MusteriUrunAl("meyve");
            }
            else if (secim == "S")
            {
                Console.WriteLine("Manavın toptancıdan aldığı sebzeler:");
                Listele(manavSebzeler);
                MusteriUrunAl("sebze");
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Program sonlandırılıyor.");
                return;
            }

            Console.WriteLine("Müşteri listesi:");
            Listele(musteriListesi);
        }

        static void Listele(List<string> liste)
        {
            foreach (string urun in liste)
            {
                Console.WriteLine(urun);
            }
        }

        static void Listele(Dictionary<string, double> liste)
        {
            foreach (KeyValuePair<string, double> urun in liste)
            {
                Console.WriteLine("{0} - {1} kg", urun.Key, urun.Value);
            }
        }

        static void ManavUrunAl(string tur)
        {
            Console.WriteLine("Bir {0} seçin:", tur);
            string urun = Console.ReadLine();

            if (tur == "meyve")
            {
                if (toptanciMeyveler.Contains(urun))
                {
                    Console.WriteLine("Kaç kilo {0} almak istersiniz?", urun);
                    double kilo;
                    if (double.TryParse(Console.ReadLine(), out kilo))
                    {
                        if (manavMeyveler.ContainsKey(urun))
                        {
                            manavMeyveler[urun] += kilo;
                        }
                        else
                        {
                            manavMeyveler.Add(urun, kilo);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz kilo değeri. Ürün eklenemedi.");
                    }
                }
                else
                {
                    Console.WriteLine("Toptancının meyve listesinde {0} bulunmamaktadır.", urun);
                }
            }
            else if (tur == "sebze")
            {
                if (toptanciSebzeler.Contains(urun))
                {
                    Console.WriteLine("Kaç kilo {0} almak istersiniz?", urun);
                    double kilo;
                    if (double.TryParse(Console.ReadLine(), out kilo))
                    {
                        if (manavSebzeler.ContainsKey(urun))
                        {
                            manavSebzeler[urun] += kilo;
                        }
                        else
                        {
                            manavSebzeler.Add(urun, kilo);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz kilo değeri. Ürün eklenemedi.");
                    }
                }
                else
                {
                    Console.WriteLine("Toptancının sebze listesinde {0} bulunmamaktadır.", urun);
                }
            }

            Console.WriteLine("Başka bir arzunuz var mı? (Evet E/Hayır H)");
            string cevap = Console.ReadLine().ToUpper();

            if (cevap == "E")
            {
                if (tur == "meyve")
                {
                    Console.WriteLine("Toptancının meyve listesi:");
                    Listele(toptanciMeyveler);
                }
                else if (tur == "sebze")
                {
                    Console.WriteLine("Toptancının sebze listesi:");
                    Listele(toptanciSebzeler);
                }

                ManavUrunAl(tur);
            }
        }

        static void MusteriUrunAl(string tur)
        {
            Console.WriteLine("Bir {0} seçin:", tur);
            string urun = Console.ReadLine();

            if (tur == "meyve")
            {
                Console.WriteLine("Kaç kilo {0} almak istersiniz?", urun);
                double kilo;
                if (double.TryParse(Console.ReadLine(), out kilo))
                {
                    if (manavMeyveler.ContainsKey(urun))
                    {
                        double stokMiktarı = manavMeyveler[urun];

                        if (stokMiktarı >= kilo)
                        {
                            musteriListesi.Add(urun, kilo);
                            manavMeyveler[urun] -= kilo;
                        }
                        else
                        {
                            Console.WriteLine("Manavın meyve listesinde yeterli miktarda {0} bulunmamaktadır.", urun);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Manavın meyve listesinde {0} bulunmamaktadır.", urun);
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz kilo değeri. Ürün eklenemedi.");
                }
            }
            else if (tur == "sebze")
            {
                Console.WriteLine("Kaç kilo {0} almak istersiniz?", urun);
                double kilo;
                if (double.TryParse(Console.ReadLine(), out kilo))
                {
                    if(manavSebzeler.ContainsKey(urun))
                {
                        double stokMiktarı = manavSebzeler[urun];

                        if (stokMiktarı >= kilo)
                        {
                            musteriListesi.Add(urun, kilo);
                            manavSebzeler[urun] -= kilo;
                        }
                        else
                        {
                            Console.WriteLine("Manavın sebze listesinde yeterli miktarda {0} bulunmamaktadır.", urun);
                        }
                    }
                else
                    {
                        Console.WriteLine("Manavın sebze listesinde {0} bulunmamaktadır.", urun);
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz kilo değeri. Ürün eklenemedi.");
                }
            }

            Console.WriteLine("Başka bir arzunuz var mı? (Evet E/Hayır H)");
            string cevap = Console.ReadLine().ToUpper();

            if (cevap == "E")
            {
                if (tur == "meyve")
                {
                    Console.WriteLine("Manavın toptancıdan aldığı meyveler:");
                    Listele(manavMeyveler);
                }
                else if (tur == "sebze")
                {
                    Console.WriteLine("Manavın toptancıdan aldığı sebzeler:");
                    Listele(manavSebzeler);
                }

                MusteriUrunAl(tur);
            }
        }
    }

}
