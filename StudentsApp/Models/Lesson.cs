using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsApp.Models
{
    public class Lesson
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Room Room { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }

    }
}
