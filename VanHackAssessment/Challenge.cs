using System;
using System.Collections.Generic;
using System.Linq;

namespace VanHackAssessment
{
    public class Challenge
    {
        static readonly Dictionary<int, char> romanNumerals = new()
        {
            { 1000, 'M' },
            { 500, 'D' },
            { 100, 'C' },
            { 50, 'L' },
            { 10, 'X' },
            { 5, 'V' },
            { 1, 'I' },
        };

        List<int> numbers = new List<int>();

        private string _romanNumeral;

        public string Numerals(int num)
        {
            var numText = num.ToString();

            for (int i = 1; i <= numText.Length; i++)
            {
                var numberText = numText.Substring(numText.Length - i, 1);
                numbers.Add(int.Parse(numberText) * (int)Math.Pow(10, i - 1));
            }

            _romanNumeral = string.Empty;

            foreach (var number in numbers)
            {
                if (number != 0)
                {
                    if (TryUniqueRomanNumeral(number, out string romanNumber))
                    {
                        _romanNumeral = $"{romanNumber}{_romanNumeral}";
                    }
                    else if (TryDecrease(number, out romanNumber))
                    {
                        _romanNumeral = $"{romanNumber}{_romanNumeral}";
                    }
                    else if (TryIncrease(number, out romanNumber))
                    {
                        _romanNumeral = $"{romanNumber}{_romanNumeral}";
                    }
                }
            }

            return _romanNumeral;
        }

        private bool TryUniqueRomanNumeral(int number, out string romanNumeral)
        {
            var lastNumberText = number.ToString();

            if (number == 1 || (lastNumberText.StartsWith("5") || (lastNumberText.StartsWith("1") && number >= 10)))
            {
                foreach (var key in romanNumerals.Keys)
                {
                    int resto = number % key;

                    if (resto != number)
                    {
                        romanNumeral = romanNumerals[key].ToString();

                        if (TryUniqueRomanNumeral(resto, out string romanNumeralComplement))
                        {
                            romanNumeral += romanNumeralComplement;
                        }

                        return true;
                    }
                }
            }

            romanNumeral = null;
            return false;
        }

        private bool TryIncrease(int number, out string romanNumeral)
        {
            var firstLowerThenNumber = romanNumerals.Keys
                .Where(x => x < number)
                .OrderBy(x => x)
                .LastOrDefault();

            if (firstLowerThenNumber > 0)
            {
                var sum = firstLowerThenNumber;
                romanNumeral = romanNumerals[firstLowerThenNumber].ToString();

                for (int i = 3; i >= 1; i--)
                {
                    foreach (var keySum in romanNumerals.Keys)
                    {
                        if (sum + keySum * i <= number)
                        {
                            sum += keySum * i;
                            romanNumeral += new string(romanNumerals[keySum], i);
                        }
                    }
                }

                return true;
            }

            romanNumeral = null;
            return false;
        }

        private bool TryDecrease(int number, out string romanNumeral)
        {
            var firstHigherThenNumber = romanNumerals.Keys
                .Where(x => x > number)
                .OrderBy(x => x)
                .FirstOrDefault();

            if (firstHigherThenNumber > 0)
            {
                var sub = firstHigherThenNumber;
                romanNumeral = romanNumerals[firstHigherThenNumber].ToString();

                foreach (var keySub in romanNumerals.Keys)
                {
                    if (firstHigherThenNumber - keySub == number)
                    {
                        romanNumeral = romanNumerals[keySub] + romanNumeral;
                        return true;
                    }
                }
            }

            romanNumeral = null;
            return false;
        }
    }
}
