using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev_soru_3
{
    class Program
    {
        // Abbreviations
        // nm = Normal math operators
        // mf = Math functions
        double nmAdd(double int1, double int2)
        {
            return int1 + int2;
        }
        double nmMultiply(double int1, double int2)
        {
            return int1 * int2;
        }
        double nmSubtract(double int1, double int2)
        {
            return int1 - int2;
        }
        double nmDivide(double int1, double int2)
        {
            return int1 / int2;
        }
        double mfPow(double int1, double int2)
        {
            return Math.Pow(int1, int2);
        }
        double mfAbs(double int1)
        {
            return Math.Abs(int1);
        }
        void chooseNM()
        {
            Console.WriteLine("Hangi işlemi yapmak istediğinizi yazınız. (Toplama / Çıkarma / Çarpma / Bölme)");
            string choosen = Console.ReadLine().ToLower();
            if (choosen == "toplama" || choosen == "topla")
            {
                Console.WriteLine("Değer1 + Değer2 işlemi için sırayla değerleri giriniz.");
                Console.Write("Değer1: ");
                double _int1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Değer2: ");
                double _int2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Sonuç: " + nmAdd(_int1, _int2));
            }
            else if (choosen == "çarpma" || choosen == "çarp")
            {
                Console.WriteLine("Değer1 * Değer2 işlemi için sırayla değerleri giriniz.");
                Console.Write("Değer1: ");
                double _int1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Değer2: ");
                double _int2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Sonuç: " + nmMultiply(_int1, _int2));
            }
            else if (choosen == "çıkartma" || choosen == "çıkart" || choosen == "çıkar")
            {
                Console.WriteLine("Değer1 - Değer2 işlemi için sırayla değerleri giriniz.");
                Console.Write("Değer1: ");
                double _int1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Değer2: ");
                double _int2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Sonuç: " + nmSubtract(_int1, _int2));
            }
            else
            {
                Console.WriteLine("Değer1 / Değer2 işlemi için sırayla değerleri giriniz.");
                Console.Write("Değer1: ");
                double _int1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Değer2: ");
                double _int2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Sonuç: " + nmDivide(_int1, _int2));
            }
        }
        void chooseMF(string str)
        {
            switch (str)
            {
                case "pow":
                    Console.WriteLine("Üssünü almak istediğiniz sayıyı sonrasında kaçıncı kuvvetini istediğinizi yazınız.");
                    Console.Write("Üssü alınacak sayı: ");
                    double _pow1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Kuvvet: ");
                    double _pow2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Sonuç: " + mfPow(_pow1, _pow2));
                    break;
                case "abs":
                    Console.WriteLine("Mutlak değerini hesaplanacak sayıyı giriniz.");
                    Console.Write("Mutlak değeri alınacak sayı: ");
                    double _abs1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Sonuç: " + mfAbs(_abs1));
                    break;
            }
        }
        static void Main(string[] args)
        {
            Program prg = new Program();
            Console.WriteLine("Aynı işlem içerisinde en fazla 2 sayı üzerinden işlem yapılabilir.");
            Console.WriteLine("Toplama+Çıkarma-Bölme/Çarpma* işlemleri için 'Hesap Makinesi' yazınız.");
            Console.WriteLine("Sayıların üssünü öğrenmek için 'Üslü'");
            Console.WriteLine("Sayıların mutlak değerini öğrenmek için 'Mutlak' yazınız");

            switch (Console.ReadLine().ToLower())
            {
                case "hesap makinesi":
                    prg.chooseNM();
                    break;
                case "üslü":
                    prg.chooseMF("pow");
                    break;
                case "mutlak":
                    prg.chooseMF("abs");
                    break;
            }
        }
    }
}
