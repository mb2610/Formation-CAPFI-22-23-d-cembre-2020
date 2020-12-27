using NFluent;
using NUnit.Framework;

namespace RomanNumeralsTest
{
    public class ArabicToRomanShould
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        public void Provide_a_roman_numeral_when_arabic_is_inferior_4(int arabicNumber,
            string romanNumber)
        {
            Check.That(new RomanNumerals().ToRoman(arabicNumber)).Equals(romanNumber);
        }

        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(30, "XXX")]
        [TestCase(502, "DII")]
        public void Provide_a_roman_numeral_when_arabic_is_inferior_1000(int arabicNumber,
            string romanNumber)
        {
            Check.That(new RomanNumerals().ToRoman(arabicNumber)).Equals(romanNumber);
        }

        [TestCase(1003, "MIII")]
        [TestCase(1990, "MCMXC")]
        [TestCase(1903, "MCMIII")]
        public void
            Provide_a_roman_numeral_when_arabic_is_equal_or_greater_than_1000
            (int arabicNumber, string romanNumber)
        {
            Check.That(new RomanNumerals().ToRoman(arabicNumber)).Equals(romanNumber);
        }
    }
}