using BLL;
using System;

namespace ConsoleUI
{
    class StartApp
    {
        internal void UserInput()
        {
            while (true)
            {
                Console.Write("Write your expression: ");
                string input = Console.ReadLine();
                IRPNExpressionCalculator rpn = new RPNExpressionCalculator();
                Console.WriteLine(rpn.CalculateRPNExpression(input));
            }
        }
    }
}
