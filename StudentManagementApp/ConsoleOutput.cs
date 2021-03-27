using System;

namespace StudentManagementApp
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }

}

