using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev_soru_6
{
    class Program
    {
        void run()
        {
            Console.Clear();
            Console.WriteLine("Takımlar: Fenerbahçe - Beşiktaş - Trabzonspor - Galatasaray");
            Console.WriteLine("Tuttuğunuz takım hakkında bir şey yazın ve tahmin edelim. (Kuruluş Yılı, Bağlı olduğu şehir, Güncel Kulüp Başkanı)");
            string input = Console.ReadLine().ToLower();
            string[] sehirler = { "istanbul", "trabzon", "beşiktaş", "fenerbahçe", "galata" };
            string[] baskanlar = { "ahmet ağaoğlu", "ali koç", "mustafa cengiz", "ahmet nur çebi" };
            if (int.TryParse(input, out _))
            {
                switch (Convert.ToInt32(input))
                {
                    case 1995:
                        Console.Write("Tuttuğunuz takım: Beşiktaş");
                        break;
                    case 1905:
                        Console.WriteLine("Tuttuğunuz takım: Galatasaray");
                        break;
                    case 1907:
                        Console.WriteLine("Tuttuğunuz takım: Fenerbahçe");
                        break;
                    case 1967:
                        Console.WriteLine("Tuttuğunuz takım: Trabzonspor");
                        break;
                }
            }
            else
            {
                if (sehirler.Contains(input))
                {
                    switch (input)
                    {
                        case "istanbul":
                            Console.WriteLine("Semt belirtiniz.");
                            break;
                        case "fenerbahçe":
                            Console.WriteLine("Tuttuğunuz takım: Fenerbahçe");
                            break;
                        case "beşiktaş":
                            Console.WriteLine("Tuttuğunuz takım: Beşiktaş");
                            break;
                        case "galata":
                            Console.WriteLine("Tuttuğunuz takım: Galatasaray");
                            break;
                        case "trabzon":
                            Console.WriteLine("Tuttuğunuz takım: Trabzonspor");
                            break;
                    }
                }
                else if (baskanlar.Contains(input))
                {
                    switch (input)
                    {
                        case "ahmet ağaoğlu":
                            Console.WriteLine("Tuttuğunuz takım: Trabzonspor");
                            break;
                        case "ali koç":
                            Console.WriteLine("Tuttuğunuz takım: Fenerbahçe");
                            break;
                        case "mustafa cengiz":
                            Console.WriteLine("Tuttuğunuz takım: Galatasaray");
                            break;
                        case "ahmet nur çebi":
                            Console.WriteLine("Tuttuğunuz takım: Beşiktaş");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Tuttuğunuz takım anlaşılmadı üzgünüz.");
                }
            }
        }
        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.run();
            Console.WriteLine("\n\nTekrar başlatmak için \"Yenile\" yazınız. \nÇıkmak için Enter tuşuna basınız.");
            string input = Console.ReadLine().ToLower();
            if (input == "yenile")
                prg.run();
        }
    }
}
