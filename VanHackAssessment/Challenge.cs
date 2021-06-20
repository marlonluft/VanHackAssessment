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
            ProcessNumericalPlaces();

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

        private void ProcessNumericalPlaces()
        {
            foreach (var numericalPlace in NumericalPlaces)
            {
                if (numericalPlace != 0)
                {
                    if (TryExactRomanNumeral(numericalPlace, out string romanNumber))
                    {
                        RomanNumeral = $"{romanNumber}{RomanNumeral}";
                    }
                    else if (TryDecreaseRomanNumeral(numericalPlace, out romanNumber))
                    {
                        RomanNumeral = $"{romanNumber}{RomanNumeral}";
                    }
                    else if (TryIncreaseRomanNumeral(numericalPlace, out romanNumber))
                    {
                        RomanNumeral = $"{romanNumber}{RomanNumeral}";
                    }
                }
            }
        }

        private bool TryExactRomanNumeral(int number, out string romanNumeral)
        {
            var numberText = number.ToString();

            if (number == 1 || (numberText.StartsWith("5") || (numberText.StartsWith("1") && number >= 10)))
            {
                foreach (var key in _romanNumerals.Keys)
                {
                    int remainder = number % key;

                    if (remainder != number)
                    {
                        romanNumeral = _romanNumerals[key].ToString();

                        if (TryExactRomanNumeral(remainder, out string romanNumeralComplement))
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

        private bool TryIncreaseRomanNumeral(int number, out string romanNumeral)
        {
            var romanNumeralBelowCurrentNumber = _romanNumerals.Keys
                .Where(x => x < number)
                .OrderBy(x => x)
                .LastOrDefault();

            if (romanNumeralBelowCurrentNumber > 0)
            {
                var sum = romanNumeralBelowCurrentNumber;
                romanNumeral = _romanNumerals[romanNumeralBelowCurrentNumber].ToString();

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

        private bool TryDecreaseRomanNumeral(int number, out string romanNumeral)
        {
            var romanNumeralAboveCurrentNumber = _romanNumerals.Keys
                .Where(x => x > number)
                .OrderBy(x => x)
                .FirstOrDefault();

            if (romanNumeralAboveCurrentNumber > 0)
            {
                var sub = romanNumeralAboveCurrentNumber;
                romanNumeral = _romanNumerals[romanNumeralAboveCurrentNumber].ToString();

                foreach (var keySub in _romanNumerals.Keys)
                {
                    if (romanNumeralAboveCurrentNumber - keySub == number)
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
