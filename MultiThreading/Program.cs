using System;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeThread = 20;
            int sizeMain = 20;

            //int[] inputs = new int[] { 999999999, 888888888, 998990996, 667889776, 955755655, 994995996, 911822733 };
            long[] inputs = new long[] { 2101000000, 1800000000, 1501000000, 2110000000 };

            var startTime = DateTime.Now;
            Console.WriteLine($"Using single thread. Started: {startTime.ToLongTimeString()}");

            foreach (var input in inputs)
                Sum(input);

            var finishTime = DateTime.Now;
            Console.WriteLine($" Single thread - Finished at {finishTime.ToLongTimeString()}. Total time consumed (in sec): {(finishTime - startTime).TotalSeconds}");

            startTime = DateTime.Now;
            Console.WriteLine($"Using multi threads. Started: {startTime.ToLongTimeString()}");


            foreach (var input in inputs)
            {
                // создаем новый поток
                Thread myThread = new Thread(() => Sum(input));
                myThread.Start(); // запускаем поток
            }

            Console.WriteLine($" Multi threads - Total time consumed (in sec): {(DateTime.Now - startTime).TotalSeconds}");

            Console.ReadLine();
        }

        public static void Sum(long input)
        {
            Console.WriteLine($"-------  input {input}. Started: {DateTime.Now.ToLongTimeString()}");
            var startTime = DateTime.Now;
            long result = 1;
            for (int i = 1; i <= input; i++)
                result += i;

            Console.WriteLine($"--------  Sum of {input} equals {result: # ###}, finished at {DateTime.Now.ToLongTimeString()}. Time consumed (in sec): {(DateTime.Now - startTime).TotalSeconds}");
        }


        public static void Count(int size)
        {
            for (int i = 1; i < size; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(400);
            }
        }
    }
}
