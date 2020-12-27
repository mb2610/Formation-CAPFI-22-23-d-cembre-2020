using System.Collections.Generic;

namespace RomanNumeralsTest
{
    public class RomanNumerals
    {
        private readonly Dictionary<int, string> _arabic2Roman = new Dictionary<int, string>
        {
            [1000] = "M",
            [900] = "CM",
            [500] = "D",
            [400] = "CD",
            [100] = "C",
            [90] = "XC",
            [50] = "L",
            [40] = "XL",
            [10] = "X",
            [9] = "IX",
            [5] = "V",
            [4] = "IV",
            [1] = "I"
        };

        private readonly Dictionary<string, int> _roman2Arabic = new Dictionary<string, int>
        {
            ["M"] = 1000,
            ["CM"] = 900,
            ["D"] = 500,
            ["CD"] = 400,
            ["C"] = 100,
            ["XC"] = 90,
            ["L"] = 50,
            ["XL"] = 40,
            ["X"] = 10,
            ["IX"] = 9,
            ["V"] = 5,
            ["IV"] = 4,
            ["I"] = 1
        };

        public int ToArabic(string romanNumeral)
        {
            var arabicNumeral = 0;
            while (romanNumeral.Length != 0)
                foreach (var token in _roman2Arabic.Keys)
                    if (romanNumeral.StartsWith(token))
                    {
                        romanNumeral = romanNumeral.Substring(token.Length);
                        arabicNumeral += _roman2Arabic[token];
                    }

            return arabicNumeral;
        }

        public string ToRoman(int arabicNumeral)
        {
            var romanNumeral = string.Empty;

            foreach (var arabicFigure in _arabic2Roman.Keys)
                while (arabicNumeral >= arabicFigure)
                {
                    romanNumeral += _arabic2Roman[arabicFigure];
                    arabicNumeral -= arabicFigure;
                }

            return romanNumeral;
        }
    }
}