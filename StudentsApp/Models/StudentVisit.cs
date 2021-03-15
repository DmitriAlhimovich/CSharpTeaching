using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsApp.Models
{
    public class StudentVisit
    {
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public byte Mark { get; set; }
    }
}
