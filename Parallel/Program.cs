using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new List<long>() { 1111111111, 722222222, 833333333, 944444444 };

            //Consecutive execution
            Console.WriteLine($"-------  Consecutive execution started: {DateTime.Now.ToLongTimeString()}");
            var startTime = DateTime.Now;

            inputs.ForEach(input => Sum(input));

            
            Console.WriteLine($"--------  Consecutive execution finished at {DateTime.Now.ToLongTimeString()}. Time consumed (in sec): {(DateTime.Now - startTime).TotalSeconds}");

            Console.WriteLine();

            //Parallel execution
            Console.WriteLine($"-------  Parallel execution started: {DateTime.Now.ToLongTimeString()}");
            startTime = DateTime.Now;

            Parallel.ForEach<long>(inputs, Sum);

            Console.WriteLine($"--------  Parallel execution finished at {DateTime.Now.ToLongTimeString()}. Time consumed (in sec): {(DateTime.Now - startTime).TotalSeconds}");
        }

        public static void Sum(long input)
        {
            long result = 0;
            for (int i = 1; i <= input; i++)
                result += i;

            Console.WriteLine($"Sum for {input} is {result}"); ;
        }        
    }
}
