using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LINQ
{
    public class Mark
    {
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public string Subject { get; set; }
        public byte Value { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, typeof(Mark));
        }

    }
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }

    }

    public static class CharExtensions

    {
        public static char ToUpper(this char c)
        {
            return char.ToUpper(c);
        }
    }
    class Program
    {
        private const int CountOfMarks = 200;
        private const int CountOfStudents = 20;

        static void Main(string[] args)
        {
            var tuple = GenerateData();

            var students = tuple.Students;
            var marks = tuple.Marks;
            FindAverageMarksByGroupsAndSubjects(students, marks);
            FindAverageMarksByStudentsAndSubjects(students, marks);

            FindWordByFirstAndLastLetter();
        }

        private static void FindAverageMarksByStudentsAndSubjects(List<Student> students, List<Mark> marks)
        {
            //Select average mark for every student by subject

            var studentAverageMarkList = marks.GroupBy(m => (m.Student, m.Subject))
                .OrderBy(g => int.Parse(g.Key.Student.Name.Substring(1)))
                .ThenBy(g => g.Key.Subject)
                .Select(g => $"{g.Key.Student.Name}, {g.Key.Subject} - {g.Average(m => m.Value)}");


            var firstStudentByFirstSubject = marks.Where(m => m.Student == students[0] && m.Subject == "Math")
                .Select(m => m.Value).ToList();
            Console.WriteLine(students[0].Name + " " + "Math " + string.Join(",", firstStudentByFirstSubject));
            Console.WriteLine(string.Join("\n", studentAverageMarkList));
        }

        private static void FindAverageMarksByGroupsAndSubjects(List<Student> students, List<Mark> marks)
        {
            var groupCounts = students.GroupBy(s => s.Group).Select(g => $"{g.Key} - {g.Count()}").ToList();

            // Select average mark for every group by subject for previuos month

            var groupAverageMarkList = marks.Where(m => IsPreviousMonth(m.Date))
                .GroupBy(m => (m.Student.Group, m.Subject)).
               Select(g => $"{g.Key.Group}, {g.Key.Subject} - {g.Average(m => m.Value)}");

            Console.WriteLine(string.Join("\n", groupAverageMarkList));
        }

        private static bool IsPreviousMonth(DateTime date)
        {
            var today = DateTime.Today;

            var firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);

            var firstDayOfPrevMonth = firstDayOfCurrentMonth.AddMonths(-1);

            return date >= firstDayOfPrevMonth && date < firstDayOfCurrentMonth;
        }

        private static void FindWordByFirstAndLastLetter()
        {
            string[] capitals = new string[]
                        {
                "Moscow",
                "Rome",
                "Minsk",
                "Paris",
                "retre"
                        };

            char firstLetter = 'r', lastLetter = 'e';

            var result = capitals.Where(capital => capital[0].ToUpper() == firstLetter.ToUpper()
            && capital[capital.Length - 1].ToUpper() == lastLetter.ToUpper())
                .Select(c => $"{c} starts with {firstLetter} and ends with {lastLetter}");

            Console.WriteLine(string.Join("\n", result));
        }

        private static (List<Student> Students, List<Mark> Marks) GenerateData()
        {
            string[] subjects = new string[] { "Math", "English", "Biology" };
            string[] groups = new string[] { "gr1", "gr2", "gr3" };
            List<Student> students = new List<Student>();
            Random random = new Random();
            for (int i = 0; i < CountOfStudents; i++)
            {

                var student = new Student
                {
                    Name = "s" + random.Next(100),
                    Group = groups[random.Next(groups.Length)]
                };
                students.Add(student);
            }
            DateTime start = DateTime.Today.AddMonths(-1);
            var hours = (DateTime.Today - start).TotalHours / CountOfMarks;

            List<Mark> marks = new List<Mark>();
            for (int i = 0; i < CountOfMarks; i++)
            {
                var mark = new Mark
                {
                    Date = start.AddHours(hours),
                    Student = students[random.Next(students.Count)],
                    Subject = subjects[random.Next(subjects.Length)],
                    Value = (byte)random.Next(1, 10)
                };
                marks.Add(mark);

            }

            return (Students: students, Marks: marks);

        }
    }
}