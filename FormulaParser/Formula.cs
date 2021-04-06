using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaParser
{
    public class Formula
    {
        private const char OpenBracketSymbol = '[';
        private const char CloseBracketSymbol = ']';
        private static readonly char[] allOperators = new char[] { '+', '-', '*', '/' };

        private static readonly char[] operatorsWithPriority = new char[] { '*', '/' };

        private readonly List<char> operatorsList;
        private readonly List<string> operandsList;

        private Dictionary<string, double> parametersDictionary;

        public Formula(string formulaString)
        {
            (operatorsList, operandsList) = ParseFormulaString(formulaString);
        }

        private (List<char> operators, List<string> operands) ParseFormulaString(string formulaString)
        {
            var operatorsList = formulaString.Where(c => allOperators.Contains(c)).ToList();
            var operandsList = formulaString.Split(allOperators).Select(s => s.Replace(" ", "").Trim()).ToList();

            if (operandsList.Count != operatorsList.Count + 1)
                throw new InvalidFormulaException("Operands count should be operators count + 1.");

            return (operators: operatorsList, operands: operandsList);
        }

        public double Calculate(Dictionary<string, double> parameters)
        {

            parametersDictionary = parameters;
            double operand1 = GetOperandValue(operandsList[0]);
            double operand2;
            for (int i = 0; i < operatorsList.Count; i++)
            {
                operand2 = GetOperandValue(operandsList[i + 1]);

                operand1 = Calculate(operand1, operand2, operatorsList[i]);
            }

            return operand1;
        }

        public double Calculate(double operand1, double operand2, char @operator)
        {
            return @operator switch
            {
                '+' => operand1 + operand2,
                '-' => operand1 - operand2,
                '*' => operand1 * operand2,
                '/' => operand1 / operand2,
                _ => throw new ArgumentException($"Unknown operator {@operator}"),
            };
        }        

        private double GetOperandValue(string key)
        {
            if (key.StartsWith(OpenBracketSymbol) && key.EndsWith(CloseBracketSymbol))
            {
                if (parametersDictionary.TryGetValue(key.Trim(OpenBracketSymbol, CloseBracketSymbol), out double value))
                    return value;
                else
                    throw new InvalidFormulaException($"Parameter {key} not found");
            }
            else
            {
                if (double.TryParse(key, out double value))
                    return value;
                else
                    throw new InvalidFormulaException($"Operand {key} can't be parsed");
            }
        }
    }

}
