using System;
using BLL;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            RPNTranslater rpnService = new RPNTranslater();
            Console.WriteLine(rpnService.ExpressionInRPN(input));
        }
    }
}
