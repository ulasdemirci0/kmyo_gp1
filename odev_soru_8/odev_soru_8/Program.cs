using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;

namespace odev_soru_8
{
    class Program
    {
        public Timer timer = new Timer();
        public int elapsed = 0;
        void timerSetup()
        {
            elapsed = 0;
            if (timer.Enabled)
                timer.Stop();
            timer.Interval = 500;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            elapsed++;
        }

        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.timerSetup();
            prg.timer.Start();
            while (prg.timer.Enabled)
            {
                Console.Clear();
                Console.WriteLine("Kronometre: " + prg.elapsed);
                System.Threading.Thread.Sleep(500);
            }

        }
    }
}
