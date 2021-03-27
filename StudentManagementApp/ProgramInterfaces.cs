using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementApp
{

    class ProgramInterfaces
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input output mode. 1 - Console, 2 - text file");

            var mode = Console.ReadLine();

            IOutput output;
            if (mode == "1")
                output = new ConsoleOutput();
            else
                output = new FileOutput();


            Student student1 = new Student { ID = "1", FirstName = "Ivan", LastName = "Ivanov" };
            Student student2 = new Student { ID = "2", FirstName = "Petr", LastName = "Petrov" };

            DataStorage.Instance.Students.Add(student1);
            DataStorage.Instance.Students.Add(student2);

            DataStorage.Instance.Groups.Add(new Group { Number = "01" });
            DataStorage.Instance.Groups.Add(new Group { Number = "02" });
            DataStorage.Instance.Groups.Add(new Group { Number = "07" });

            while (true)
            {

                output.WriteLine("Input command. \n 1 - list students, " +
                    "\n 2 - add student, 3 - edit student, \n 4 - list groups, 5 - add group Q - quit");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        PrintStudents(DataStorage.Instance.Students, output);
                        break;
                    case "2":
                        var newStudent = InputNewStudent(output);
                        DataStorage.Instance.Students.Add(newStudent);
                        break;
                    case "3":
                        EditStudent(output);
                        break;

                    case "4":
                        PrintGroups(DataStorage.Instance.Groups, output);
                        break;
                    case "5":
                        var newGroup = InputNewGroup(output);
                        DataStorage.Instance.Groups.Add(newGroup);
                        break;

                    case "Q":
                    case "q":
                        return;

                }
            }
        }

        private static void EditStudent(IOutput output)
        {
            PrintStudents(DataStorage.Instance.Students, output);

            output.WriteLine("Input student ID:");

            var id = Console.ReadLine();

            var studentToUpdate = DataStorage.Instance.Students.FirstOrDefault(s => s.ID == id);

            if (studentToUpdate == null)
            {
                output.WriteLine("Student not found");
                return;
            }

            output.WriteLine("Input new data for the student.");

            output.WriteLine("Input student first name (Enter to skip): ");

            var firstName = Console.ReadLine();

            output.WriteLine("Input student last name (Enter to skip): ");

            var lastName = Console.ReadLine();

            PrintGroups(DataStorage.Instance.Groups, output);

            output.WriteLine("Input student group number (Enter to skip): ");

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
                    output.WriteLine("Group not found");
                    return;
                }

                studentToUpdate.Group = newGroup;
            }


            PrintStudents(DataStorage.Instance.Students, output);


        }

        private static Student InputNewStudent(IOutput output)
        {
            output.WriteLine("Input first name:");
            var firstName = Console.ReadLine();

            output.WriteLine("Input last name:");
            var lastName = Console.ReadLine();

            Student student = new Student { FirstName = firstName, LastName = lastName };

            return student;
        }

        private static void PrintStudents(List<Student> students, IOutput output)
        {
            output.WriteLine("Students:");
            foreach (var student in students)
            {
                output.WriteLine($"{student.ID}. {student.FirstName} {student.LastName} " +
                    $"({student.Group?.Number})");
            }
        }

        private static Group InputNewGroup(IOutput output)
        {
            output.WriteLine("Input group number:");
            var number = Console.ReadLine();

            var group = new Group { Number = number };

            return group;
        }

        private static void PrintGroups(List<Group> groups, IOutput output)
        {
            output.WriteLine("Groups:");
            foreach (var group in groups)
            {
                output.WriteLine($"{group.Number}");
            }
        }
    }

}

