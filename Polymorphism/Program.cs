using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Polymorphism
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual string GetTitle()
        {
            return $"Employee: {FirstName} {LastName}";
        }

        public string GetTitle_NoVirtual()
        {
            return $"Employee: {FirstName} {LastName}";
        }
    }

    public class Manager : Employee
    {
        public override string GetTitle()
        {
            return $"Manager: mr. {FirstName} {LastName}";
        }

        public string GetTitle_NoVirtual()
        {
            return $"Manager: mr. {FirstName} {LastName}";
        }
    }

    public class Developer : Employee
    {
        public override string GetTitle()
        {
            return $"Developer: {FirstName} {LastName}";
        }

        public string GetTitle_NoVirtual()
        {
            return $"Developer: {FirstName} {LastName}";
        }
    }

    public class DotNetDeveloper : Employee
    {
        public override string GetTitle()
        {
            return $".Net Developer: {FirstName} {LastName}";
        }

        public string GetTitle_NoVirtual()
        {
            return $".Net Developer: {FirstName} {LastName}";
        }
    }

    public class FullStackDotNetDeveloper : DotNetDeveloper
    {
        public new string GetTitle()
        {
            return $"Full-stack .Net Developer: {FirstName} {LastName}";
        }

        public string GetTitle_NoVirtual()
        {
            return $".Net Developer: {FirstName} {LastName}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<Employee> employees = new List<Employee>
            {
                new Manager { FirstName = "mName", LastName = "mLastname" },
                new Developer { FirstName = "devName", LastName = "devLastname" },
                new DotNetDeveloper { FirstName = ".net devName", LastName = ".net devLastname" },
                new DotNetDeveloper { FirstName = ".net devName", LastName = ".net devLastname" },
                new FullStackDotNetDeveloper() { FirstName = "full devName", LastName = "full devLastname" }
            };

            Console.WriteLine("Virtual methods:");

            employees.ForEach(e => Console.WriteLine(e.GetTitle()));

            Console.WriteLine("\n ---- \n");

            Console.WriteLine("No virtual methods:");

            Employee currentEmployee = new Employee() { FirstName = "empName", LastName = "empLastName" };

            Console.WriteLine(currentEmployee.GetTitle_NoVirtual());

            currentEmployee = new Manager { FirstName = "managerName", LastName = "managerLastname" };
            Console.WriteLine(currentEmployee.GetTitle_NoVirtual());

            currentEmployee = new Manager { FirstName = "devName", LastName = "devLastname" };
            Console.WriteLine(currentEmployee.GetTitle_NoVirtual());

            currentEmployee = new DotNetDeveloper { FirstName = ".net devName", LastName = ".net devLastname" };
            Console.WriteLine(currentEmployee.GetTitle_NoVirtual());

            currentEmployee = new FullStackDotNetDeveloper()
                {FirstName = "full devName", LastName = "full devLastname"};
            Console.WriteLine(currentEmployee.GetTitle());
        }
    }
}
