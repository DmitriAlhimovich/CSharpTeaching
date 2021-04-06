using System;
using System.Collections.Generic;
using System.Linq;

namespace FormulaParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var formulaStr = "[Price]/[Months]*[Interest] + [Comission] - 5";

            Dictionary<string, double> keyValues = new Dictionary<string, double> {
                {"Price", 100 } ,
                {"Months", 6 },
                {"Interest", 1.11 },
                {"Comission", 3 }
            };

            Formula formula = new Formula(formulaStr);

            var result = formula.Calculate(keyValues);

            Console.WriteLine(result);

            Console.WriteLine(100.0 / 6 * 1.11 + 3 - 5);

        }
    }
}
