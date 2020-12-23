using System.Threading;
using NFluent;
using NUnit.Framework;

namespace RPNCalculatorTest
{
    public class RPNCalculatorShould
    {
        [Test]
        public void Display_same_digit_when_digit_has_been_sent()
        {
            var rpnCalculator = new RpnCalculator();
            string expected = rpnCalculator.Evaluate("1");
            Check.That(expected).IsEqualTo("1");
        }

        [Test]
        public void Add_when_expression_contains_plus_operator()
        {
            var rpnCalculator = new RpnCalculator();
            var expected = rpnCalculator.Evaluate("1 2 +");
            Check.That(expected).IsEqualTo("3");
        }

        [Test]
        public void Subtract_when_expression_contain_slash_operator()
        {
            var rpnCalculator = new RpnCalculator();
            var expected = rpnCalculator.Evaluate("4 2 -");
            Check.That(expected).IsEqualTo("2");
        }

        [Test]
        public void Multiply_when_expression_contain_star_operator()
        {
            var rpnCalculator = new RpnCalculator();
            var expected = rpnCalculator.Evaluate("2 3 *");
            Check.That(expected).IsEqualTo("6");
        }

        [Test]
        public void Divide_when_expression_contain_star_operator()
        {
            var rpnCalculator = new RpnCalculator();
            var expected = rpnCalculator.Evaluate("20 4 /");
            Check.That(expected).IsEqualTo("5");
        }
    }
}
