using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsApp.Models
{
    public class Teacher:Person
    {
        public List<Subject> Subjects { get; set; }
    }
}
