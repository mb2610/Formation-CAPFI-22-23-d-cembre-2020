using System.Collections.Generic;

namespace FizzBuzzTest
{
    public class FizzBuzz
    {
        private readonly IDictionary<int, string> _figures;

        // Parameterized Constructor
        public FizzBuzz() : this(new Dictionary<int, string>
        {
            [3] = "Fizz",
            [5] = "Buzz",
        })
        {
        }

        public FizzBuzz(IDictionary<int, string> figures)
        {
            _figures = figures;
        }

        public string Generate(int number)
        {
            var result = FizzBuzzRules(number);

            return result == string.Empty ? number.ToString() : result;
        }

        private string FizzBuzzRules(int number)
        {
            var result = string.Empty;

            foreach (var (key, value) in _figures)
                if (number % key == 0)
                    result += value;

            return result;
        }
    }
}