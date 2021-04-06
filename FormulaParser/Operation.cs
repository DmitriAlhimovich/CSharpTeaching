using System;

namespace FormulaParser
{
    public class Operation
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public char Operator { get; set; }

        private double? result = null;

        public Operation NextOperation { get; set; }

        public Operation(double operand1, double operand2, char @operator)
        {
            Operand1 = operand1;
            Operand2 = operand2;
            Operator = @operator;
        }

        public void Calculate()
        {
            result = Operator switch
            {
                '+' => Operand1 + Operand2,
                '-' => Operand1 - Operand2,
                '*' => Operand1 * Operand2,
                '/' => Operand1 / Operand2,
                _ => throw new ArgumentException($"Unknown operator {Operator}"),
            };

            NextOperation.Operand1 = result.Value;
        }

        public double? Result
        {
            get
            {
                return result;
            }
        }
    }

}
