using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GarbageCollector
{
    public class Student
    {
        public string Name { get; set; }
        public List<int> Marks { get; set; } = new List<int>();

        public Student(string name)
        {
            Name = name;
        }

        public void OnTeacherNotify(string text)
        {
            Console.WriteLine($"Notification: {text}");
        }
    }

    public class Teacher
    {
        public delegate void EventHandler(string message);
        public event EventHandler Notify;

        public void AddMark(int mark)
        {
            Notify($"Student received new mark: {mark}");
        }
    }
    public class MemoryLeakageExample
    {
        public static void Run()
        {
            
            Console.WriteLine("\n-------- Memory Leakage Example ------");

            Console.WriteLine("Total Memory before students subscriptions: {0}", GC.GetTotalMemory(false));

            Teacher teacher2 = new Teacher();

            for (int i = 0; i < 100000; i++)
            {
                var student = new Student("name" + i);

                teacher2.Notify += student.OnTeacherNotify;

                teacher2.Notify -= student.OnTeacherNotify;
            }

            GC.Collect(2); //try comment-uncomment

            Console.WriteLine("WITH Unsubscribe - Total Memory after students subscriptions: {0}", GC.GetTotalMemory(false));
           
            Console.WriteLine();

            Console.WriteLine("Total Memory before students subscriptions: {0}", GC.GetTotalMemory(false));

            Teacher teacher = new Teacher();

            for (int i = 0; i < 100000; i++)
            {
                var student = new Student("name" + i);

                teacher.Notify += student.OnTeacherNotify;

                //teacher.Notify -= student.OnTeacherNotify; // try comment-uncomment
            }

            GC.Collect(2); //try uncomment

            Console.WriteLine("Without Unsubscribe - Total Memory after students subscriptions: {0}", GC.GetTotalMemory(false));

        }
    }
}
