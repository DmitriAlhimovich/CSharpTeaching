using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementApp
{
    class Program
    {
        static void Main1(string[] args)
        {
            Student student1 = new Student { ID = "1", FirstName = "Ivan", LastName = "Ivanov" };
            Student student2 = new Student { ID = "2", FirstName = "Petr", LastName = "Petrov" };

            DataStorage.Instance.Students.Add(student1);
            DataStorage.Instance.Students.Add(student2);

            while (true)
            {

                Console.WriteLine("Input command. \n 1 - list students, " +
                    "\n 2 - add student, 3 - edit student, \n 4 - list groups, 5 - add group Q - quit");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        PrintStudents(DataStorage.Instance.Students);
                        break;
                    case "2":
                        var newStudent = InputNewStudent();
                        DataStorage.Instance.Students.Add(newStudent);
                        break;
                    case "3":
                        EditStudent();
                        break;

                    case "4":
                        PrintGroups(DataStorage.Instance.Groups);
                        break;
                    case "5":
                        var newGroup = InputNewGroup();
                        DataStorage.Instance.Groups.Add(newGroup);
                        break;

                    case "Q":
                    case "q":
                        return;

                }
            }
        }

        private static void EditStudent()
        {
            PrintStudents(DataStorage.Instance.Students);

            Console.WriteLine("Input student ID:");

            var id = Console.ReadLine();

            var studentToUpdate = DataStorage.Instance.Students.FirstOrDefault(s => s.ID == id);

            if (studentToUpdate == null)
            {
                Console.WriteLine("Student not found");
                return;
            }

            Console.WriteLine("Input new data for the student.");

            Console.WriteLine("Input student first name (Enter to skip): ");

            var firstName = Console.ReadLine();

            Console.WriteLine("Input student last name (Enter to skip): ");

            var lastName = Console.ReadLine();

            PrintGroups(DataStorage.Instance.Groups);

            Console.WriteLine("Input student group number (Enter to skip): ");

            var groupNumber = Console.ReadLine();

            if (firstName != "")
                studentToUpdate.FirstName = firstName;

            if (lastName != "")
                studentToUpdate.LastName = lastName;

            if (groupNumber != "")
            {
                var newGroup = DataStorage.Instance.Groups.FirstOrDefault(g => g.Number == groupNumber);

                if (newGroup == null)
                {
                    Console.WriteLine("Group not found");
                    return;
                }

                studentToUpdate.Group = newGroup;
            }

            PrintStudents(DataStorage.Instance.Students);
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
            Console.WriteLine("Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.ID}. {student.FirstName} {student.LastName} " +
                    $"({student.Group?.Number})");
            }
        }

        private static Group InputNewGroup()
        {
            Console.WriteLine("Input group number:");
            var number = Console.ReadLine();

            var group = new Group { Number = number };

            return group;
        }

        private static void PrintGroups(List<Group> groups)
        {
            Console.WriteLine("Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Number}");
            }
        }
    }
}

