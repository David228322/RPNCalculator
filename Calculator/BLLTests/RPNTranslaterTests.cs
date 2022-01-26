using Xunit;
using BLL;

namespace BLLTests
{
    public class RPNTranslaterTests
    {
        [Theory]
        [InlineData("2962+3001-10*991/(47211-17*2777)", "2962 3001 + 10 991 * 47211 17 2777 * - / -")]
        [InlineData("69998+43998/(76+97548/8868*1993)-69792", "69998 43998 76 97548 8868 / 1993 * + / + 69792 -")]
        [InlineData("(61393+3665)/32529*23*(3655-87-3557)", "61393 3665 + 32529 / 23 * 3655 87 - 3557 - *")]
        [InlineData("427-52*(1818+22384/2798)/3652+7", "427 52 1818 22384 2798 / + * 3652 / - 7 +")]
        [InlineData("8*7-6/3+2^0", "8 7 * 6 3 / - 2 0 ^ +")]
        public void ExpressionInRPN_ReturnTranslatedExpressions(string inputExpressions, string expected)
        {
            var rpnTranslater = new RPNTranslater();

            var actual = rpnTranslater.ExpressionInRPN(inputExpressions);

            Assert.Equal(expected, actual);
        }

    }
}
