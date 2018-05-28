using System;
using System.Diagnostics;
using System.Text;

namespace DebugAndSecurity.Demos
{
    class ProfilingApplication
    {
        const int numberOfIterations = 100000;

        internal static void StopWatchClass()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Algorithm1();
            sw.Stop();
            Console.WriteLine($"Algorithm 1 elapsed time: {sw.Elapsed}");

            sw.Reset();

            sw.Start();
            Algorithm2();
            sw.Stop();
            Console.WriteLine($"Algorithm 2 elapsed time: {sw.Elapsed}");

            Console.WriteLine($"Ready....");
        }

        private static void Algorithm1()
        {
            StringBuilder sb = new StringBuilder();

            for (int x = 0; x < numberOfIterations; x++)
            {
                sb.Append('a');
            }

            string result = sb.ToString();
        }

        private static void Algorithm2()
        {
            string result = "";

            for (int x = 0; x < numberOfIterations; x++)
            {
                result += 'a';
            }
        }

        internal static void Reading_Data_From_Performance_Counter()
        {
            Console.WriteLine("Press escape key to stop");

            using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available Bytes"))
            {
                string text = "Available memory: ";
                Console.Write(text);

                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.Write(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }
    }
}
