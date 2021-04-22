using AsyncAwait.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Repository repository = Repository.Instance;

            SeedData.Seed(repository);
            SeedData.SeedLessons(repository);

            //Sync execution
            DateTime start = DateTime.Now;

            double avgSync = CalculateAvgSync(repository);

            var duration = (DateTime.Now - start).TotalMilliseconds;

            Console.WriteLine($"Duration of SYNC execution (ms): {duration}, result = {avgSync}");


            //Async execution
            start = DateTime.Now;
            double avgAsync = CalculateAvgAsync(repository);
            duration = (DateTime.Now - start).TotalMilliseconds;

            Console.WriteLine($"Duration of Async execution (ms): {duration}, result = {avgAsync}");

        }

        private static double CalculateAvgSync(Repository repository)
        {
            double sum = 0;
            foreach (var lesson in repository.Lessons)
            {
                sum += lesson.GetAverage();
            }

            var avg = sum / repository.Lessons.Count;
            return avg;
        }

        private static double CalculateAvgAsync(Repository repository)
        {
            List<Task<double>> tasks = new List<Task<double>>();
            foreach (var lesson in repository.Lessons)
            {
                tasks.Add(lesson.GetAverageAsync());
            }

            Task.WaitAll(tasks.ToArray());

            var sum = tasks.Select(t => t.Result).Sum();

            return sum / repository.Lessons.Count;
        }
    }
}
