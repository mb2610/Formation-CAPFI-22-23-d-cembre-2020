using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorTest
{
    public class StringCalculatorBuilder
    {
        private readonly string _stringNumbers;
        private List<int> Integers { get; set; }

        public StringCalculatorBuilder(string stringNumbers)
        {
            _stringNumbers = stringNumbers;
        }

        public StringCalculatorBuilder ExtractNumbers()
        {
            var delimiter = ',';
            var stringNumbers = (string) _stringNumbers.Clone();
            if (_stringNumbers.StartsWith("//"))
            {
                delimiter = stringNumbers[2];
                stringNumbers = stringNumbers.Substring(4);
            }

            Integers = stringNumbers
                .Split(new[] {delimiter, '\n'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            return this;
        }

        public StringCalculatorBuilder HandleNegativesNumbers()
        {
            if (Integers.Any(i => i < 0))
                throw new Exception($"Negatives not allowed: {string.Join(",", Integers.Where(n => n < 0))}");

            return this;
        }

        public StringCalculatorBuilder ExcludeNumberGreaterThan(int numberMax)
        {
            Integers = Integers.Where(n => n < numberMax).ToList();
            return this;
        }

        public int Sum()
        {
            return Integers.Sum();
        }
    }
}