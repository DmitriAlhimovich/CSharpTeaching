using System.Collections.Generic;

namespace StudentManagementApp
{
    public class Student
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Group Group { get; set; }

        public List<int> Marks { get; set; }
    }
}

