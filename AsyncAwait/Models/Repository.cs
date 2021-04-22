using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncAwait.Models
{
    public class Repository
    {
        private static Repository instance;
        public static Repository Instance
        {
            get
            {
                if (instance == null)
                    instance = new Repository();
                return instance;
            }
        }
        private Repository()
        { }



        public List<Student> Students { get; set; } = new List<Student>();

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public List<StudentVisit> Visits { get; set; } = new List<StudentVisit>();
    }
}
