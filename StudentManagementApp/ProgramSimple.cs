using System;
using System.Collections.Generic;

namespace StudentManagementApp
{
    class ProgramSimple
    {
        static void Main1(string[] args)
        {

            Student student1 = new Student { FirstName = "Ivan", LastName="Ivanov" };
            Student student2 = new Student { FirstName = "Petr", LastName = "Petrov" };
            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            

            while (true)
            {

                Console.WriteLine("Input command. 1 - list students, 2 - add student, Q - quit");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        PrintStudents(students);
                        break;
                    case "2":
                        var newStudent = InputNewStudent();
                        students.Add(newStudent);
                        break;

                    case "Q":
                    case "q":
                        return;

                }
            }
        }

        private static Student InputNewStudent()
        {
            Console.WriteLine("Input first name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Input last name:");
            var lastName = Console.ReadLine();

            Student student = new Student { FirstName = firstName, LastName = lastName };

            return student;
        }

        private static void PrintStudents(List<Student> students)
        {
            foreach(var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} ");
            }    
        }
    }

    
}
