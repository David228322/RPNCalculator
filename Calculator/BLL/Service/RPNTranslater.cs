using System.Collections.Generic;
using System.Text;

namespace BLL
{
    /// <summary>
    /// Class with method ExpressionInRPN.
    /// </summary>
    public class RPNTranslater
    {
        /// <summary>
        /// Translate expresssion from input in RPN format for calculating.
        /// </summary>
        /// <param name="inputExpression">input user's expression.</param>
        /// <returns>return string expression in RPN format.</returns>
        public string ExpressionInRPN(string inputExpression)
        {
            Stack<char> operators = new Stack<char>();
            StringBuilder output = new StringBuilder();
            StringBuilder numberOutput = new StringBuilder();

            for (int i = 0; i < inputExpression.Length; i++)
            {
                char curChar = inputExpression[i];
                if (char.IsDigit(curChar) || curChar == ',')
                {
                    numberOutput.Append(curChar);
                }
                else if (operators.Count == 0)
                {
                    this.ResetNumberOutput(output, numberOutput);

                    operators.Push(curChar);
                }
                else
                {
                    this.ResetNumberOutput(output, numberOutput);

                    this.CompareOperPrecedence(operators, output, curChar);
                }
            }

            this.ResetNumberOutput(output, numberOutput);

            while (operators.Count != 0)
            {
                output.Append($"{operators.Pop()} ");
            }

            return output.ToString().Trim();
        }

        private void CompareOperPrecedence(Stack<char> operators, StringBuilder output, char curChar)
        {
            if (this.IsCurlyBracket(curChar))
            {
                this.CurclyBracketsImplementation(operators, output, curChar);
            }
            else
            {
                int operPriority = this.GetOperatorPriority(curChar);
                int operStackPriority = this.GetOperatorPriority(operators.Peek());
                while (operStackPriority >= operPriority && operators.Count > 0)
                {
                    output.Append($"{operators.Pop()} ");
                    if (operators.Count != 0)
                    {
                        operStackPriority = this.GetOperatorPriority(operators.Peek());
                    }
                }

                operators.Push(curChar);
            }
        }

        private void CurclyBracketsImplementation(Stack<char> operators, StringBuilder output, char curChar)
        {
            if (curChar == '(')
            {
                operators.Push(curChar);
            }
            else
            {
                do
                {
                    if (operators.Peek() != '(' && operators.Peek() != ')')
                    {
                        output.Append($"{operators.Pop()} ");
                    }
                    else
                    {
                        operators.Pop();
                    }
                }
                while (operators.Peek() != '(');

                operators.Pop();
            }
        }

        private bool IsCurlyBracket(char curChar) => curChar == '(' || curChar == ')';

        private void ResetNumberOutput(StringBuilder output, StringBuilder number)
        {
            if (!string.IsNullOrEmpty(number.ToString()))
            {
                output.Append($"{number} ");
                number.Clear();
            }
        }

        private int GetOperatorPriority(char oper)
        {
            Dictionary<char, int> operatorPriority = new Dictionary<char, int>()
            {
                { '(', 0 },
                { '+', 1 },
                { '-', 1 },
                { '*', 2 },
                { '/', 2 },
                { '%', 2 },
                { '^', 2 },
            };
            return operatorPriority[oper];
        }
    }
}
