using System;
using System.Linq;

namespace Delegates
{
    class ProgramSimple
    {
		delegate double Average(double[] numbers);

		delegate int Operation(int x, int y);
		public static void Main()
		{

			Average avg;


			var numbers = new double[] { 3, 4, 5, 6 };

			avg = GetAverageSimple;

			var resultSimple = avg(numbers);

			avg = GetAverageLinq;
			var resultLinq = avg(numbers);


			Operation operation = (x, y) => x + y;
			Console.WriteLine(operation(10, 20));       // 30
		}

		private static double GetAverageSimple(double[] numbers)
        {
			return numbers.Sum() / numbers.Count();
        }

		private static double GetAverageLinq(double[] numbers)
		{
			return numbers.Average();
		}

	}
}
