using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BLL;

namespace BLLTests
{
    public class RPNExpressionCalculatorTests
    {
        [Theory]
        [InlineData("427-52*(1818+22384/2798)/3652+7", 408)]
        [InlineData("69998+43998/(76+97548/8868*1993)-69792", 208)]
        [InlineData("(61393+3665)/32529*23*(3655-87-3557)", 506)]
        [InlineData("8*7-6/3+2^0%4", 55)]
        [InlineData("(8*(7-6)/(3+2^0))%4", 2)]
        [InlineData("5*(3*(1+2))", 45)]
        [InlineData("(3*(1+8))/4", 6.75)]
        [InlineData("((((7+2)*2)/4)+6)/0,5", 21)]



        public void CalculateRPNExpression_ReturnsCorrectAnswear(string rpnExression, double expected)
        {
            IRPNExpressionCalculator rpnCalculator = new RPNExpressionCalculator();

            var actual = rpnCalculator.CalculateRPNExpression(rpnExression);

            Assert.Equal(actual, expected);
        }
    }
}
