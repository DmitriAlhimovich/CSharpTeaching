using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 5; i++)
            {
                Reader reader = new Reader(i);
            }

            Console.WriteLine("Finished");            
        }
    }

    class Reader
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(5, 5);
        Thread myThread;
        int count = 3;// счетчик чтения

        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Читатель {i}";
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                sem.Release();

                count--;
                Thread.Sleep(1000);
            }
        }
    }
}
