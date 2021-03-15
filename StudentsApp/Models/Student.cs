using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsApp.Models
{
    public class Student : Person
    {
        public Group Group { get; set; }
    }
}
