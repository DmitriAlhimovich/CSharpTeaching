using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Models
{
    public class Lesson
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Room Room { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }

        public double GetAverage()
        {
            int ExecuteTimes = 500;

            //long operation
            //Thread.Sleep(10);

            double result = 0;

            for (int i = 0; i < ExecuteTimes; i++)
            {
                result = Repository.Instance.Visits.Where(v => v.Lesson == this).Select(v => (double)v.Mark).Average();
            }

            return result;
        }

        public Task<double> GetAverageAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return GetAverage();
            });
        }
    }
}
