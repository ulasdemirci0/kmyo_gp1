using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace odev_soru_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int permanentHeart = 20;
            int maxHeart = 20;
            int Heart = 20;
            while (Heart > 0)
            {
                Thread.Sleep(551);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Heart + " kalp canınız var.");
                Console.WriteLine("Karakteriniz bugün ne yapmalı? (Uyu , Spor, Yemek ye, Ders)\n");
                Console.ResetColor();
                string input = Console.ReadLine().ToLower();
                Random rnd = new Random();
                int chance = rnd.Next(0, 101); // [0-25) Uyu / [25-50) Spor / [50-75) Yemek / [75-100) Ders / chance == 100 Kanser
                if (input == "uyu" && chance < 25)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enerjiniz yenilendi ve daha dinç, mutlu bir gün geçiriyorsunuz.");
                    if (Heart != maxHeart)
                        Heart = maxHeart; maxHeart--;
                    continue;
                }
                else if (input == "uyu" && chance >= 25)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("İkindi vakti uyandınız, ağzınızda garip bir tat var."); Heart--; continue;
                }
                // -----------
                if (input == "spor" && chance >= 25 && chance < 50)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Spor yaparak kendinizi geliştirdiniz, yorulduğunuz için gün burada bitiyor.");
                    if (Heart != maxHeart)
                        Heart = maxHeart; maxHeart--;
                    continue;
                }
                else if (input == "spor" && (chance < 25 || chance >= 50))
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Vücudunuz spor yapacak kadar enerjik değildi, kaslarınız size karşı savaş açmış gibisiniz ve uyumaya gidiyorsunuz.");
                    Heart--; continue;
                }
                // ----------
                if ((input == "yemek" || input == "yemek ye") && chance >= 50 && chance < 75)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Çok acıkmıştınız ve en yakın kebapçıya girerek bol acılı adana kebap yiyorsunuz, yemekten sonra şişkinliği atmak için eve doğru yürümeye başlıyorsunuz.");
                    if (Heart != maxHeart)
                        Heart = maxHeart; maxHeart--;
                    continue;
                }
                else if ((input == "yemek" || input == "yemek ye") && (chance < 50 || chance >= 75))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bugün hiç yemek yememiştiniz kebap midenizi bulandırdı ve kendinizi iyi hissetmiyorsunuz, taksi ile eve döndünüz.");
                    Heart--;
                    continue;
                }
                // --------
                if (input == "ders" && chance >= 75 && chance < 100)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Lise sınavına girerken yediğiniz okunmuş pirinç bugün etkisini gösterdi ve ders çalışmaya başladınız, kitaplardan kafanızı kaldırdığınızda akşam olduğunu fark ettiniz ve yemek yiyip uyudunuz.");
                    if (Heart != maxHeart)
                        Heart = maxHeart; maxHeart--;
                    continue;
                }
                else if (input == "ders" && chance <= 75)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Daha önce birkaç defa ders çalışmıştınız fakat bünyeye ters olunca olmuyor, mide bulantısı ateş yükselmesi vb etkiler yüzünden fenalaşmaya başladınız direkt yatarak instagram ilacı aldınız.");
                    Heart--;
                    continue;
                }
                // -------------
                if (chance == 100 & Heart < permanentHeart - (permanentHeart - 5))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Maalesef kendinize kötü bakmanızdan dolayı, son evre kanser olduğunuz ortaya çıktı... Başımız sağolsun.");
                    Heart = 0;
                    break;
                }
            }
            if (Heart <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nKalp yetmezliği nedeniyle vefat ediyorsunuz...\nOyunumuz bitmiştir.");
                Console.ReadKey();
            }
        }
    }

}