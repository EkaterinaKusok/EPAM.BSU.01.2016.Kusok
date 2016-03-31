using System;
using System.Threading;
using Timer;

namespace TimerConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var customTimer = new CustomTimer();
            var watcher = new Watcher();
            var inspector = new Inspector(customTimer);
            watcher.Register(customTimer);

            string secondsString = "";
            int seconds;
            Console.WriteLine("Set timer:");
            secondsString = Console.ReadLine();
            while (secondsString != "-1")
            {
                if (Int32.TryParse(secondsString, out seconds) && seconds>-1)
                {
                    Console.WriteLine("Start timer to {0} seconds.", seconds);
                    Thread.Sleep(seconds*1000);
                    customTimer.SimulateEndTimer(seconds);
                }
                else
                    Console.WriteLine("You set incorrect value of seconds.");
                Console.WriteLine();
                Console.WriteLine("Set timer (-1 for end of programm):");
                secondsString = Console.ReadLine();
            }

            //watcher.Unregister(customTimer);
            //Console.WriteLine();
            //Console.WriteLine("Start timer in 5 seconds.");
            //Thread.Sleep(5 * 1000);
            //customTimer.SimulateEndTimer(5);
            //Console.ReadKey();

        }
        
        #region Listeners: Watcher and Inspector
        sealed class Watcher
        {
            //CustomTimer вызывает этот метод для уведомления
            //объекта Watcher о прибытии нового почтового сообщени
            private void WatherMsg(Object sender, EndTimerEventArgs eventArgs)
            {
                Console.WriteLine("Wather CustomTimer message:");
                Console.WriteLine("Elapsed {0} seconds.", eventArgs.Seconds);
            }

            public void Register(CustomTimer customTimer)
            {
                customTimer.EndTimer += WatherMsg;
            }
            public void Unregister(CustomTimer customTimer)
            {
                customTimer.EndTimer -= WatherMsg;
            }
        }

        class Inspector
        {
            public Inspector(CustomTimer customTimer)
            {
                customTimer.EndTimer += InspectorMsg;
            }
            private void InspectorMsg(Object sender, EndTimerEventArgs eventArgs)
            {
                Console.WriteLine("Inspector CustomTimer message:");
                Console.WriteLine("Elapsed {0} seconds.", eventArgs.Seconds);
            }
            public void Unregister(CustomTimer mail)
            {
                mail.EndTimer -= InspectorMsg;
            }
        }
        #endregion
    }
}
