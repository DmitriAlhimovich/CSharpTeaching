using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncAwait.Models
{
    public class Student : Person
    {
        public Group Group { get; set; }

     
        public double GetAverage()
        {
            //long operation
            Thread.Sleep(100);

            return Repository.Instance.Visits.Where(v => v.Student == this).Select(v => (double)v.Mark).Average();
            
        }
    }
}
