using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
namespace odev_soru_4
{
    class Program
    {
        public int player1Score, player2Score, maxScore, turn;
        public string player1Name, player2Name;
        public List<string> boostList = new List<string>() { "Yeni araba", "Mercedes g63", "Toyota supra", "Pegout 207", "Opel astra", "Audi s1", "Bentley bentayga", "Avendator", "Lotus 340", "Pit stop", "Mclaren f1", "Mclaren p1", "Skyline", "Takviye yakıt", "Tnt" };
        public TimeSpan _timespan;
        public double _estimatedTime, player1Estimated, player2Estimated;
        public bool isFirst;
        void resetVariables()
        {
            player1Score = default;
            player2Score = default;
            player1Estimated = 0;
            player2Estimated = 0;
            maxScore = 50;
            player1Name = default;
            player2Name = default;
            _estimatedTime = default;
            turn = default;
            isFirst = true;
        }

        string getTimeAndInput()
        {
            Stopwatch stp = new Stopwatch();
            var firstChar = Console.ReadKey();
            stp.Start();
            var restOfBoost = Console.ReadLine();
            stp.Stop();
            _timespan = stp.Elapsed;
            _estimatedTime = Convert.ToDouble((_timespan.Seconds.ToString() + "," + _timespan.Milliseconds.ToString()));
            return string.Concat(firstChar.KeyChar, restOfBoost);

        }
        string getRandomBoost()
        {
            Random rnd = new Random();
            string _boost = boostList[rnd.Next(0, boostList.Count - 1)];
            _boost = boostList[rnd.Next(0, boostList.Count - 1)];
            return _boost;
        }
        void setPlayerNames()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("İlk oyuncunun adı: ");
            player1Name = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("İkinci oyuncunun adı: ");
            player2Name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("----------------------------\n");
            Console.ResetColor();
        }

        void chooseRandomPlayer()
        {
            Random rnd = new Random();
            turn = rnd.Next(1, 3);
        }
        // String metodu kullanılan bölüm -> 
        bool checkInputIsBoost(string input)
        {
            // input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1) || System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower())
            if (boostList.Contains(input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1)))
            {
                int index = boostList.FindIndex(x => x.StartsWith(input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1)));
                if (index > -1 && boostList[index] == (input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1)))
                {
                    return true;
                }
                else
                    return false;
            }

            else
                return false;
        }
        void finish(bool isDrawn = false)
        {
            switch (isDrawn)
            {
                case true:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("Kazanan: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Berabere");
                    break;
                case false:

                    if (player1Score > player2Score)
                    {
                        if (player1Name.ToLower() == "engin")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("Kazanan: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Beşiktaşk!");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Puan Tablosu");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(player1Name + ": " + player1Score);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(player2Name + ": " + player2Score);
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("Kazanan: ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(player1Name);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Puan Tablosu");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(player1Name + ": " + player1Score);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(player2Name + ": " + player2Score);
                        }
                    }
                    else
                    {
                        if (player2Name.ToLower() == "engin")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("Kazanan: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Beşiktaşk!");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Puan Tablosu");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(player2Name + ": " + player2Score);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(player1Name + ": " + player1Score);
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("Kazanan: ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(player2Name);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Puan Tablosu");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(player2Name + ": " + player2Score);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(player1Name + ": " + player1Score);
                        }
                    }

                    break;
            }
            Console.ResetColor();
            Console.WriteLine("Yeniden başlatmak için Yenile yazın, çıkmak için Enter'a basın.");
            if (Console.ReadLine().ToLower() == "yenile")
            {
                prepare();
            }
            else
            {
                Environment.Exit(-1);
            }
        }
        void game()
        {
            string boost = getRandomBoost();
            Random rnd = new Random();
            if (turn == 1 && isFirst == true) // 1. player and first turn
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(player1Name + " yazacağın kelime: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(boost);
                string input = getTimeAndInput();
                player1Estimated = _estimatedTime;
                if (checkInputIsBoost(input))
                {
                    player1Score += input.Length;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Doğru bildiniz ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+" + input.Length + " puan ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("kazandınız");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Yeni puan durumu: " + player1Score);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Girdiğiniz kelime yanlış! Puan alamadınız ve sıra diğer oyuncuya geçti.");
                }
                // Turn End
                //Console.WriteLine("debug: p1->" + player1Estimated + "   p2->" + player2Estimated);
                turn = 2;
                isFirst = false;
            }
            else if (turn == 1 && isFirst == false) // 1. player normal turns
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(player1Name + " yazacağın kelime: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(boost);
                string input = getTimeAndInput();
                player1Estimated = _estimatedTime;
                if (checkInputIsBoost(input) && player2Estimated > player1Estimated)
                {
                    player1Score += input.Length;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Doğru ve daha hızlı bildiğiniz için ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+" + input.Length + " puan ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("kazandınız");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Yeni puan durumu: " + player1Score);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Kelimeyi yanlış yazmanız veya diğer oyuncudan yavaş olmanızdan dolayı puan kazanamadınız.");
                }
                // Turn End
                //Console.WriteLine("debug: p1->" + player1Estimated + "   p2->" + player2Estimated);
                turn = 2;
                isFirst = false;
            }

            if (turn == 2 && isFirst == true) // 2. player first turn
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(player2Name + " yazacağın kelime: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(boost);
                string input = getTimeAndInput();
                player2Estimated = _estimatedTime;
                if (checkInputIsBoost(input))
                {

                    player2Score += input.Length;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Doğru bildiniz ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+" + input.Length + " puan ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("kazandınız");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Yeni puan durumu: " + player2Score);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Girdiğiniz kelime yanlış! Puan alamadınız ve sıra diğer oyuncuya geçti.");
                }
                turn = 1;
                isFirst = false;
                //Console.WriteLine("debug: p1->" + player1Estimated + "   p2->" + player2Estimated);
            }
            else if (turn == 2 && isFirst == false) // 2. player normal
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(player2Name + " yazacağın kelime: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(boost);
                string input = getTimeAndInput();
                player2Estimated = _estimatedTime;
                if (checkInputIsBoost(input) && player1Estimated > player2Estimated)
                {

                    player2Score += input.Length;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Doğru ve daha hızlı bildiğiniz için ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+" + input.Length + " puan ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("kazandınız");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Yeni puan durumu: " + player2Score);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Kelimeyi yanlış yazmanız veya diğer oyuncudan yavaş olmanızdan dolayı puan kazanamadınız.");
                }
                turn = 1;
                isFirst = false;
                //Console.WriteLine("debug: p1->" + player1Estimated + "   p2->" + player2Estimated);
            }

            while (maxScore > player1Score && maxScore > player2Score)
            {
                game();
            }
            if (maxScore <= player1Score || maxScore <= player2Score)
            {
                if (player1Score == player2Score)
                {
                    finish(true);
                }
                else
                {
                    finish();
                }
            }

            // Game End
        }

        void prepare()
        {
            Console.Clear();
            resetVariables();
            setPlayerNames();
            chooseRandomPlayer();
            game();
        }
        void tutorial()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bilinen Hata: Kelimelerin ilk harfini yanlış yazmanız durumunda silememektesiniz, oyun yayınlanmaya karar verilirse bu hata giderilecektir.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Merhaba, oyun 2 tarafın karşısına rastgele çıkan kelime veya kelime öbeklerini ekrana doğru yazması üzerine kuruludur.\n" + "Oyunda 2 adet oyuncu bulunup 50 puana ulaşmaya çalışmaktadırlar, ilk önce 50 puana ulaşan oyuncu kazanır.\n" + "Oyunda kelimeleri en hızlı yazan puan alır. Hızınız siz her yazdığınızda değişir yani ilk kelimeyi 1 saniyede yazdıysanız rakibinizin 1 saniyeden kısa sürede yazması gerekir. \n" +
                "Eğer 2. kelimeyi 2 saniyede yazdıysanız rakibinizin 2 saniyeden kısa sürede yazması gerekir.\n" + "Oyuna ilk başlayacak oyuncu rastgele olarak belirlenir. \nIlk sürüm olması dolayısıyla 2 oyuncuyada aynı karakter sayısına sahip kelimeler gelmeyebilir ilerleyen sürümlerde düzeltilecektir.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Thread.Sleep(500);
            Console.WriteLine("-------------------------------------------------------------------");
            Console.ResetColor();
            Thread.Sleep(1200);
            Console.WriteLine("Oyuna geçmek için herhangi bir tuşa basınız.");
            Console.ReadKey();
            prepare();

        }
        static void Main(string[] args)
        {
            Program prg = new Program();
            Console.WriteLine("Oynanış hakkında bilgi edinmek için egitim yazınız, egitime girmeden baslamak icin Enter'a basınız.");
            string input = Console.ReadLine().ToLower();
            if (input != null && (input == "egitim" || input == "eğitim"))
            {
                prg.tutorial();
            }
            else
            {
                prg.prepare();
            }
        }
    }
}
