using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class RPNTranslater
    {
        public string ExpressionInRPN(string inputExpression)
        {
            Stack<char> operators = new Stack<char>();
            StringBuilder output = new StringBuilder("Converted expression in RPN:");
            StringBuilder numberOutput = new StringBuilder();

            for (int i = 0; i < inputExpression.Length; i++)
            {
                char curChar = inputExpression[i];
                if (inputExpression.IsDigit(i) || curChar == '.')
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

            return output.ToString();
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
                output.Remove(output.Length - 1, 1);
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
                        output.Remove(output.Length - 1, 1);
                        operators.Pop();
                    }
                }
                while (operators.Contains('('));
            }
        }

        private bool IsCurlyBracket(char curChar) => curChar == '(' || curChar == ')';

        private void ResetNumberOutput(StringBuilder output, StringBuilder number)
        {
            output.Append($"{number} ");
            number.Clear();
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
            };
            return operatorPriority[oper];
        }
    }
}
