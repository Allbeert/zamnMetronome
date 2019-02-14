using System;
using System.Diagnostics;
using System.Threading;

namespace zamnMetronome
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            DateTime dt;
            long milis;
            sw.Start();

            int initialDelay = 160;
            int speakerDelay = 100;
            int beepLength = 100;

            Console.WriteLine("Metronome™");

            if (args.Length > 0)
            {
                if (args[0].Equals("--help") || args[0].Equals("-h"))
                {
                    Console.WriteLine("Usage: \n" +
                        "zamnMetronome.exe [InitialDelay] [SpeakerDelay] [BeepLength]\n" +
                        "All values in ms.\n" +
                        "InitialDelay: For 100% -> 160ms\n" +
                        "              For any% -> 40ms");
                    return;
                }
                initialDelay = int.Parse(args[0]);
                if (args.Length > 1)
                {
                    speakerDelay = int.Parse(args[1]);
                    if (args.Length > 2)
                    {
                        beepLength = int.Parse(args[2]);
                    }
                }
            }

            Console.Write("Ready to start. Press any key...");

            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }
                Console.Write("\r" + new string(' ', Console.WindowWidth - 1));
                dt = DateTime.Now;
                milis = sw.ElapsedMilliseconds;

                /* 100% CPU consumption here. */
                while ((sw.ElapsedMilliseconds - milis) != initialDelay) ;

                milis = sw.ElapsedMilliseconds - speakerDelay;


                bool f = true;
                int ms = 0;

                /* 22s to make sure it stops by itself after the last beep in 100% */
                while (ms < 22000)
                {
                    if ((sw.ElapsedMilliseconds - milis) % 500 < 1)
                    {
                        /* Avoids early beep when calibrating */
                        if (f && initialDelay == 0)
                        {
                            Thread.Sleep(beepLength);
                            f = false;
                        }
                        else
                        {
                            Console.Beep(1300, beepLength);
                        }

                        Console.Write("\r" + DateTime.Now.ToString("ss.fff"));

                        ms += 500;
                    }

                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    /* 100% CPU consumption here. */
                }

                Console.Write("\rPress 2 keys");
                Console.ReadKey(true);
                Console.Write("\rPress 1 key ");
                Console.ReadKey(true);
                Console.Write("\rReady. Press any key...");
                continue;
            }
        }
    }
}
