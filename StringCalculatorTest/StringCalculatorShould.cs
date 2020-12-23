using System;
using NFluent;
using NUnit.Framework;

namespace StringCalculatorTest
{
    public class StringCalculatorShould
    {
        [Test]
        public void Return_zero_when_string_is_empty()
        {
            Check.That(StringCalculator.Add(string.Empty)).IsEqualTo(0);
        }

        [Test]
        public void return_number_when_string_contains_one_number()
        {
            Check.That(StringCalculator.Add("1")).IsEqualTo(1);
        }

        [Test]
        public void Sum_when_string_contains_two_numbers()
        {
            Check.That(StringCalculator.Add("1,2")).IsEqualTo(3);
        }

        [Test]
        public void Sum_when_string_contains_unknown_number()
        {
            Check.That(StringCalculator.Add("1,2,3")).IsEqualTo(6);
        }

        [Test]
        public void Sum_when_new_line_is_used_as_comma()
        {
            Check.That(StringCalculator.Add("1,2\n3")).IsEqualTo(6);
        }

        [Test]
        public void Sum_when_defined_a_custom_delimiter()
        {
            Check.That(StringCalculator.Add("//;\n1;2")).IsEqualTo(3);
        }

        [Test]
        public void Raise_exception_when_string_contains_one_negative_number()
        {
            Check.ThatCode(() => StringCalculator.Add("-1,2")).Throws<Exception>()
                .WithMessage("Negatives not allowed: -1");
        }

        [Test]
        public void Raise_exception_when_string_contains_several_negatives()
        {
            Check.ThatCode(() => StringCalculator.Add("-1,2,-3,-4")).Throws<Exception>()
                .WithMessage("Negatives not allowed: -1,-3,-4");
        }

        [Test]
        public void Ignore_number_bigger_than_one_thousand()
        {
            Check.That(StringCalculator.Add("1001,2")).IsEqualTo(2);
        }
    }
}
