using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace odev_soru_9
{
    class Program
    {
        public int foodLevel = 3, SleepLevel = 3, estDay = 0;
        public bool isAlive = true;
        public Stopwatch stp = new Stopwatch();
        void alive()
        {
            stp.Reset();
            estDay++;
            Random rnd = new Random();
            Console.ForegroundColor = ConsoleColor.Gray; Console.Write("Açlık: "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(foodLevel);
            Console.ForegroundColor = ConsoleColor.Gray; Console.Write("Uykusuzluk: "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(SleepLevel);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Gün ilerliyor....");
            Thread.Sleep(rnd.Next(1, 3) * 1500);
            Console.Clear();
            int randomNeed;
            randomNeed = rnd.Next(1, 3);
            switch (randomNeed)
            {
                case 1: // Food
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Açlığınızı gidermek için 'Yemek ye' yazınız.");
                    Console.ForegroundColor = ConsoleColor.White;
                    var foodChar = Console.ReadKey().KeyChar;
                    stp.Start();
                    var restOfFood = Console.ReadLine();
                    stp.Stop();
                    if (string.Concat(foodChar, restOfFood).ToLower() == "yemek ye" && stp.Elapsed.Seconds < 2)
                        foodLevel++;
                    else
                    {
                        foodLevel--;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Kelimeyi doğru veya 5 saniyeden kısa sürede yazmadığınız için bugün yemek yemediniz.");
                    }
                    break;
                case 2: // Sleep
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Uykunuz geldi yatmak için için 'Yat uyu' yazınız.");
                    Console.ForegroundColor = ConsoleColor.White;
                    var sleepChar = Console.ReadKey().KeyChar;
                    stp.Start();
                    var restOfSleep = Console.ReadLine();
                    stp.Stop();
                    if (string.Concat(sleepChar, restOfSleep).ToLower() == "yat uyu" && stp.Elapsed.Seconds < 2)
                        SleepLevel++;
                    else
                    {
                        SleepLevel--;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Kelimeyi doğru veya 5 saniyeden kısa sürede yazmadığınız için bugün uyuyamadınız.");
                    }
                    break;
            }

            if (foodLevel > 3)
                foodLevel = 3;
            if (SleepLevel > 3)
                SleepLevel = 3;

            if (foodLevel <= 0 || SleepLevel <= 0)
            {
                isAlive = false;
            }
        }
        void death()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Karakteriniz öldüğü için kaybettiniz.");
            Console.Write("Hayatta kalınan gün: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(estDay);
        }
        static void Main(string[] args)
        {
            Program prg = new Program();
            Console.WriteLine("Oyuna başlamak için herhangi bir tuşa basın.");
            Console.ReadKey();
            Console.Clear();
            do
            {
                prg.alive();
            }
            while (prg.isAlive);
            if (!prg.isAlive)
            {
                prg.death();
            }
        }
    }
}
