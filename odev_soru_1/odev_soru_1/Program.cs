using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev_soru_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Random rnd = new Random();
            string[,] pTablo = new string[4, 4];
            string[] takımlar = { "Fenerbahçe", "Galatasaray", "Beşiktaş" };
            for (int i = 0; i < pTablo.GetUpperBound(1); i++)
            {
                pTablo[i, i] = takımlar[i];
                pTablo[i, i+1] = rnd.Next(0, 4).ToString();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Puan Tablosu:");
            Console.ResetColor();
            for (int i = 0; i < pTablo.GetUpperBound(1); i++)
            {
                Console.WriteLine(pTablo[i, i] + ": " + pTablo[i, i + 1]);
            }
            Console.WriteLine();
        }
    }
}
