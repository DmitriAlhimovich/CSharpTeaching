using System;
using System.Collections.Generic;
using System.Linq;

namespace GarbageCollector
{    
    class Program
    {
        
        static void Main(string[] args)
        {
            GCExample.Run();

            MemoryLeakageExample.Run();

            Console.WriteLine("Press a key to quit");
            Console.ReadLine();
        }        
    }
}
