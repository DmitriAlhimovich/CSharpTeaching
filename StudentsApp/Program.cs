using StudentsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsApp
{
    class Program
    {


        static void Main(string[] args)
        {
            Repository repository = new Repository();
            Seed(repository);

            SeedLessons(repository);

            Console.WriteLine("Прошедшие занятия");
            foreach (var lesson in repository.Lessons.OrderBy(l => l.StartTime))
            {
                Console.WriteLine($"{lesson.Subject.Title} (преп. {lesson.Teacher.FullName}): {lesson.StartTime}-{lesson.EndTime} (ком. {lesson.Room})");

                Console.WriteLine("--Присутствовали:");

                repository.Visits.Where(v => v.Lesson == lesson).ToList()
                    .ForEach(v => Console.WriteLine($"{v.Student.FullName} {(v.Mark > 0 ? v.Mark.ToString() : "-")}"));

                Console.WriteLine("-------------------");
            }            
        }

        static void Seed(Repository repository)
        {
            var group1 = new Group { Number = "01" };
            repository.Students.Add(
                        new Student()
                        {
                            Name = "Leha",
                            Surname = "Vasechkin",
                            Group = group1
                        });
            repository.Students.Add(
                        new Student()
                        {
                            Name = "Sanya",
                            Surname = "Vetrov",
                            Group = group1
                        });

            var group2 = new Group { Number = "02" };
            repository.Students.Add(
                        new Student()
                        {
                            Name = "Gosha",
                            Surname = "Kucenco",
                            Group = group2
                        });
            repository.Students.Add(
                        new Student()
                        {
                            Name = "Masha",
                            Surname = "Medvedova",
                            Group = group2
                        });

            var group3 = new Group { Number = "03" };

            repository.Students.Add(
                        new Student()
                        {
                            Name = "Mosya",
                            Surname = "Kachimov",
                            Group = group3
                        });
            repository.Students.Add(
                        new Student()
                        {
                            Name = "Kate",
                            Surname = "Maruga",
                            Group = group3
                        });
            repository.Students.Add(
                        new Student()
                        {
                            Name = "Seva",
                            Surname = "Ignatovski",
                            Group = group3
                        }
                        );

            repository.Teachers.AddRange(
                new List<Teacher>() {
                    new Teacher { Name = "Igor", Surname = "Fedosevich" },
                    new Teacher { Name = "Oleg", Surname = "Drozd" } });

            repository.Rooms.AddRange(
                new List<Room>() {
                    new Room { Number="k15" },
                    new Room { Number="k17" },
                    new Room { Number="k21" },
                    new Room { Number="k22"} });

            repository.Subjects.AddRange(
                new List<Subject>() {
                    new Subject { Title ="Math" },
                    new Subject { Title="C#" },
                    new Subject { Title="Design Patterns" },
                    new Subject { Title="Machine Learning"} });

        }

        private static void SeedLessons(Repository repository)
        {
            int numberOfLessons = 5;
            Random random = new Random(DateTime.Now.Millisecond);

            foreach (var group in repository.Students.Select(s => s.Group).Distinct())
            {
                foreach (var subject in repository.Subjects)
                {
                    for (int i = 0; i < numberOfLessons; i++)
                    {
                        Lesson lesson = new Lesson
                        {
                            StartTime = DateTime.Today.AddDays(-i).AddHours(9 + i),
                            EndTime = DateTime.Today.AddDays(-i).AddHours(9 + i + 1),
                            Subject = subject,

                            Room = repository.Rooms[random.Next(repository.Rooms.Count)],
                            Teacher = repository.Teachers[random.Next(repository.Teachers.Count)],


                        };
                        repository.Lessons.Add(lesson);

                        foreach (var student in repository.Students)
                        {
                            if (random.Next(5) != 0)
                            {
                                StudentVisit visit = new StudentVisit { Lesson = lesson, Student = student };
                                if (random.Next(3) == 0)
                                    visit.Mark = (byte)random.Next(3, 10);

                                repository.Visits.Add(visit);
                            }
                        }

                    }
                }
            }
        }
    }
}
