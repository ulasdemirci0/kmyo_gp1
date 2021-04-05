using System;
using System.Timers;

namespace odev_soru_2
{
    public class Program
    {

        // Variables
        public int atk_turn, p1_hit, p2_hit, luck, dmg, p1_health, p2_health;
        public string p1, p2, b202501018="ULAŞ DEMİRCİ";
        public int sayacCounter = 0;
        public Timer sayac = new Timer();
        public bool isEnded = false;
        // inGame Functions
        void getPlayerNames()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("İlk Oyuncu'nun adı: ");
            p1 = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("2. Oyuncu'nun adı: ");
            p2 = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Oyuncu: " + p1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2. Oyuncu " + p2);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
        }
        int randomizeFirstTurn()
        {
            Random rnd = new Random();
            return rnd.Next(1, 3);
        }
        int generateLuck()
        {
            Random rnd = new Random();
            return rnd.Next(0, 9);
        }

        int findRealDmg(int playerID)
        {
            if (playerID == 1)
                dmg = Math.Abs(0 - (luck - p1_hit));
            else
                dmg = Math.Abs(0 - (luck - p2_hit));

            if (dmg == 0)
                dmg = 10;
            return dmg;
        }

        string takeDmg(int dmg, int receiverPID)
        {
            if (receiverPID == 1)
            {
                p1_health -= dmg;
                return p1 + " " + dmg + " hasar aldı! \nYeni Can Durumu: " + p1_health;
            }
            else
            {
                p2_health -= dmg;
                return p2 + " " + dmg + " hasar aldı! \nYeni Can Durumu: " + p2_health;
            }
        }

        // Start Turns
        void startTurn()
        {
            if (atk_turn == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(p1 + "'in sırası:");
                p1_hit = Convert.ToInt32(Console.ReadLine());
                luck = generateLuck();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(takeDmg(findRealDmg(1), 2));
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(p2 + "'in sırası:");
                p2_hit = Convert.ToInt32(Console.ReadLine());
                luck = generateLuck();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(takeDmg(findRealDmg(2), 1));
                Console.ResetColor();
            }
        }

        // Start Rainbow Effect with Timer constructions
        void rainbow()
        {
            sayac.Interval = 1000;
            sayac.Elapsed += Sayac_Elapsed;
            sayac.Start();
        }

       // Show Winner and set game period to end
        void finish()
        {
            Console.Clear();
            Console.ResetColor();
            if (p1_health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(p2 + ", Kazandı!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(p1 + ", Kazandı!");
            }
            isEnded = true;
        }

        // Timer Tick
        private void Sayac_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            Console.BackgroundColor = (ConsoleColor)rnd.Next(0, 16);
            Console.WindowWidth = 100;
            System.Threading.Thread.Sleep(1);
            Console.WindowWidth = 99;
            Console.Clear();
            sayacCounter++;
        }

        // Main function
        void initialize()
        {
            p1_health = 20;
            p2_health = 20;
            atk_turn = randomizeFirstTurn();
            getPlayerNames();

            while (p1_health > 0 && p2_health > 0)
            {
                startTurn();
                if (atk_turn == 1)
                    atk_turn = 2;
                else
                    atk_turn = 1;

            }
            if (p1_health <= 0 || p2_health <= 0)
            {
                rainbow();
                while (sayac.Enabled)
                {
                    if (sayacCounter > 3)
                    {
                        System.Threading.Thread.Sleep(1);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WindowWidth = 100;
                        System.Threading.Thread.Sleep(1);
                        Console.WindowWidth = 99;
                        finish();
                        sayac.Stop();
                        sayacCounter = 0;
                    }
                }
            }
        }

        // Configure console & Restart game
        static void Main(string[] args)
        {
            Console.Title = "B202501018 - SIRA TABANLI SAVAŞ OYUNU";
            Program prg = new Program();
            prg.initialize();

            if (prg.isEnded == true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Tekrar başlatmak için Yenile yazın, çıkmak için Enter'a basın");
                string input = Console.ReadLine();
                if (input.ToLower() == "yenile")
                {
                    prg.initialize();
                }
                else
                {
                    Environment.Exit(-1);
                }
            }
        }
    }
}
