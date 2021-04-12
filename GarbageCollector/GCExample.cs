using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class GCExample
    {
        private const long maxGarbage = 100;

        public static void Run()
        {
            GCExample myGCCol = new GCExample();

            // Determine the maximum number of generations the system
            // garbage collector currently supports.
            Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);

            Console.WriteLine("Total Memory before MakeGarbage: {0}", GC.GetTotalMemory(false));

            GC.RegisterForFullGCNotification(2, 2);

            myGCCol.MakeSomeGarbage();

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));

            // Determine the best available approximation of the number
            // of bytes currently allocated in managed memory.
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

            // Perform a collection of generation 0 only.
            GC.Collect(0);

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));

            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

            // Perform a collection of all generations up to and including 2.
            GC.Collect(2);

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));                        
        }

        void MakeSomeGarbage()
        {
            string s;

            for (int i = 0; i < maxGarbage; i++)
            {
                // Create objects and release them to fill up memory
                // with unused objects.
                s = GenerateLongText();
                if (GC.WaitForFullGCApproach(10) == GCNotificationStatus.Succeeded)
                    OnFullGCNotify();
            }
        }

        public static void OnFullGCNotify()
        {

            Console.WriteLine("Request for GC.Collect");

            GC.Collect();

            Console.WriteLine("GC.Collect finished");
        }

        private static string GenerateLongText()
        {
            return new string('x', 9999999);
        }
    }
}