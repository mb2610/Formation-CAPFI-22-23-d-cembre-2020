
using System.Collections.Generic;
using NFluent;
using NUnit.Framework;

namespace FizzBuzzTest
{
    public class FizzBuzzShould
    {
        private readonly Dictionary<int, string> _figures = new Dictionary<int, string>
        {
            [3] = "Fizz",
            [5] = "Buzz",
        };

        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz(_figures);
        }
        
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        public void Return_number_when_number_is_regular(int number, string expected)
        {
            string actual = _fizzBuzz.Generate(number); // Act
            Check.That(actual).IsEqualTo(expected); // Assert
        }

        [Test]
        public void Return_Fizz_when_number_is_divisible_by_3()
        {
            var actual = _fizzBuzz.Generate(3);
            Check.That(actual).IsEqualTo("Fizz");
        }

        [Test]
        public void Return_Buzz_when_number_is_divisible_by_5()
        {
            var actual = _fizzBuzz.Generate(5);
            Check.That(actual).IsEqualTo("Buzz");
        }

        [Test]
        public void Return_FizzBuzz_when_number_is_divisible_by_3_and_by_5()
        {
            var fizzBuzz = new FizzBuzz();
            var actual = fizzBuzz.Generate(15);
            Check.That(actual).IsEqualTo("FizzBuzz");
        }
    }
}
