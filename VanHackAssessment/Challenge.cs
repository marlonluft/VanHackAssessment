using System;
using System.Collections.Generic;
using System.Linq;

namespace VanHackAssessment
{
    public class Challenge
    {
        private static readonly Dictionary<int, char> _romanNumerals = new()
        {
            { 1000, 'M' },
            { 500, 'D' },
            { 100, 'C' },
            { 50, 'L' },
            { 10, 'X' },
            { 5, 'V' },
            { 1, 'I' },
        };

        private List<int> NumericalPlaces { get; set; }
        private string RomanNumeral { get; set; }

        public string Numerals(int num)
        {
            RomanNumeral = string.Empty;

            ExtractNumericalPlaces(num);
            ProcessNumbers();

            return RomanNumeral;
        }

        private void ExtractNumericalPlaces(int number)
        {
            var numberToExtractString = number.ToString();

            for (int i = 1; i <= numberToExtractString.Length; i++)
            {
                var numericalPlaceString = numberToExtractString.Substring(numberToExtractString.Length - i, 1);
                var numericalPlace = int.Parse(numericalPlaceString) * (int)Math.Pow(10, i - 1);

                NumericalPlaces.Add(numericalPlace);
            }
        }

        private void ProcessNumbers()
        {
            foreach (var number in NumericalPlaces)
            {
                if (number != 0)
                {
                    if (TryUniqueRomanNumeral(number, out string romanNumber))
                    {
                        RomanNumeral = $"{romanNumber}{RomanNumeral}";
                    }
                    else if (TryDecrease(number, out romanNumber))
                    {
                        RomanNumeral = $"{romanNumber}{RomanNumeral}";
                    }
                    else if (TryIncrease(number, out romanNumber))
                    {
                        RomanNumeral = $"{romanNumber}{RomanNumeral}";
                    }
                }
            }
        }

        private bool TryUniqueRomanNumeral(int number, out string romanNumeral)
        {
            var lastNumberText = number.ToString();

            if (number == 1 || (lastNumberText.StartsWith("5") || (lastNumberText.StartsWith("1") && number >= 10)))
            {
                foreach (var key in _romanNumerals.Keys)
                {
                    int resto = number % key;

                    if (resto != number)
                    {
                        romanNumeral = _romanNumerals[key].ToString();

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
            var firstLowerThenNumber = _romanNumerals.Keys
                .Where(x => x < number)
                .OrderBy(x => x)
                .LastOrDefault();

            if (firstLowerThenNumber > 0)
            {
                var sum = firstLowerThenNumber;
                romanNumeral = _romanNumerals[firstLowerThenNumber].ToString();

                for (int i = 3; i >= 1; i--)
                {
                    foreach (var keySum in _romanNumerals.Keys)
                    {
                        if (sum + keySum * i <= number)
                        {
                            sum += keySum * i;
                            romanNumeral += new string(_romanNumerals[keySum], i);
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
            var firstHigherThenNumber = _romanNumerals.Keys
                .Where(x => x > number)
                .OrderBy(x => x)
                .FirstOrDefault();

            if (firstHigherThenNumber > 0)
            {
                var sub = firstHigherThenNumber;
                romanNumeral = _romanNumerals[firstHigherThenNumber].ToString();

                foreach (var keySub in _romanNumerals.Keys)
                {
                    if (firstHigherThenNumber - keySub == number)
                    {
                        romanNumeral = _romanNumerals[keySub] + romanNumeral;
                        return true;
                    }
                }
            }

            romanNumeral = null;
            return false;
        }
    }
}
