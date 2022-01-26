using System.Collections.Generic;
using System;

namespace BLL
{
    /// <summary>
    /// Class for translating and calculating expression.
    /// </summary>
    public class RPNExpressionCalculator : RPNTranslater, IRPNExpressionCalculator
    {
        /// <summary>
        /// Calculate user input and return result
        /// </summary>
        /// <param name="inputExpression">Input user input expression</param>
        /// <returns>return answear on expression</returns>
        public double CalculateRPNExpression(string inputExpression)
        {
            Stack<double> numbers = new Stack<double>();
            var expression = this.ExpressionInRPN(inputExpression).Split(" ");
            foreach (var item in expression)
            {
                bool isDigit = double.TryParse(item, out double number);
                if (isDigit)
                {
                    numbers.Push(number);
                }
                else
                {
                    this.Calculate2Operands(numbers, item);
                }
            }

            return numbers.Pop();
        }

        private void Calculate2Operands(Stack<double> numbers, string item)
        {
            double operand1 = numbers.Pop();
            double operand2 = numbers.Pop();

            CalculatorService calc = new CalculatorService(operand1, operand2);
            double result;

            switch (item)
            {
                case "+":
                    result = calc.Sum();
                    numbers.Push(result);
                    break;
                case "-":
                    result = calc.Sub();
                    numbers.Push(result);
                    break;
                case "*":
                    result = calc.Multiply();
                    numbers.Push(result);
                    break;
                case "/":
                    result = calc.Divide();
                    numbers.Push(result);
                    break;
                case "%":
                    result = calc.Remainder();
                    numbers.Push(result);
                    break;
                case "^":
                    result = calc.Power();
                    numbers.Push(result);
                    break;
            }
        }
    }
}
