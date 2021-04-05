using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev_soru_5
{
    class Program
    {
        IDictionary<string, string> users = new Dictionary<string, string>();
        void register()
        {
            string user, pass;
            Console.WriteLine("- Kayıt Ol - ");
            Console.Write("Kullanıcı Adı: ");
            user = Console.ReadLine();
            Console.Write("Parola: ");
            pass = Console.ReadLine();
            users.Add(user, pass);
            run();
        }
        void login()
        {
            string user, pass;
            Console.WriteLine("- Giriş Yap - ");
            Console.Write("Kullanıcı Adı: ");
            user = Console.ReadLine();
            Console.Write("Parola: ");
            pass = Console.ReadLine();
            if (users.ContainsKey(user) && users[user] == pass)
            {
                loginOK();
            }
        }

        void loginOK()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGiriş başarıyla tamamlandı.");
        }
        void run()
        {
            Console.WriteLine("Daha önceden kayıt olmadıysanız kayıt olmak için \"kayit\" yazınız. \nGiriş yapmak için \"giriş\" yazınız.");
            string input = Console.ReadLine().ToLower();
            if (input.Length == 5)
            {
                if (input == "kayit")
                    register();
                else if (input == "kayıt")
                    register();
                else
                    login();
            }
            else
            {
                run();
            }
        }
        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.run();
        }
    }
}
