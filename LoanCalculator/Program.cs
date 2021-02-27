using System;

namespace ConsoleApp1
{
    class Program
    {
        private const string IncorrectInputMessage = "Incorrect input. Retry please.";

        static void Main(string[] args)
        {
            const byte MonthsInYear = 12;

            do
            {
                decimal loanAmount = InputDecimal("Input loan amount:");
                double interestForYear = InputDouble("Input interest rate:");

                int loanDuration = InputInt("Input number of months for the loan:");

                var interestRate = interestForYear / MonthsInYear / 100;
                var overpayAmount = 0m;

                for (int month = 1; month <= MonthsInYear; month++)
                {
                    var basePayment = loanAmount / loanDuration;
                    var interestPayment = (loanAmount - basePayment * (month - 1)) * (decimal)interestRate;

                    var payment = basePayment + interestPayment;
                    overpayAmount += interestPayment;

                    Console.WriteLine($"Payment for month {month} : {payment:0.00}, " +
                        $"inc. base payment: {basePayment:0.00}, interest payment: {interestPayment:0.00}");

                }
                Console.WriteLine("-------------");
                Console.WriteLine($"Overpay amount is {overpayAmount: 0.00}");

                Console.WriteLine("-------------");
                Console.WriteLine("Continue? (Y - yes, N - no)");
            }
            while (Console.ReadLine().Equals("y", StringComparison.CurrentCultureIgnoreCase));
        }

        private static double InputDouble(string inputMessage)
        {
            Console.WriteLine(inputMessage);

            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(IncorrectInputMessage);
            }

            return result;
        }

        private static decimal InputDecimal(string inputMessage)
        {
            Console.WriteLine(inputMessage);
            decimal result;
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(IncorrectInputMessage);
            }

            return result;
        }

        private static int InputInt(string inputMessage)
        {
            Console.WriteLine(inputMessage);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(IncorrectInputMessage);
            }

            return result;
        }
    }
}
