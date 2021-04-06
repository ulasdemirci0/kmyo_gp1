using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev_soru_7
{
    class Program
    {

        void generateSky()
        {
            Random rnd = new Random();
            int i = 0;
            for (; i < 10; i++)
            {
                for (int a = i; a < 10; a++)
                {
                    for (int b = 0; b < rnd.Next(10, 50); b++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("*");
                }

                Console.WriteLine();
            }
            run();
        }

        void run()
        {
            Console.WriteLine("Gökyüzü deseninizi yeniden oluşturmak için 'olustur' yazınız.");
            if (Console.ReadLine().ToLower() == "olustur")
            {
                Console.Clear(); generateSky();
            }else
            {
                Environment.Exit(-1);
            }
                
        }
        static void Main(string[] args)
        {
            Console.WindowWidth = 125;
            Console.WindowHeight = 25;
            Program prg = new Program();
            prg.run();
        }
    }
}
