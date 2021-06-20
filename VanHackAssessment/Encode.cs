using System;
using System.Collections.Generic;
using System.Linq;

namespace VanHackAssessment
{
    public class Encode
    {
        private static readonly Dictionary<int, char> _romanNumerals = new Dictionary<int, char>()
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

        public Encode()
        {
            RomanNumeral = string.Empty;
            NumericalPlaces = new List<int>();
        }

        public static string Numerals(int num) =>
            new Encode().Process(num);

        /// <summary>
        /// Converts from a integer number to Roman numerals
        /// </summary>
        /// <param name="num">Number to convert</param>
        /// <returns>Number in Roman numerals</returns>
        public string Process(int num)
        {
            ExtractNumericalPlaces(num);
            ProcessNumericalPlaces();

            return RomanNumeral;
        }

        /// <summary>
        /// Extract each decimal place from the number to post-process separately
        /// </summary>
        /// <param name="number">Number to extract</param>
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

        /// <summary>
        /// Process each decimal place extracted, converting to Roman numeral
        /// </summary>
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
                    else if (TrySubtractingRomanNumeral(numericalPlace, out romanNumber))
                    {
                        RomanNumeral = $"{romanNumber}{RomanNumeral}";
                    }
                    else if (TrySummingRomanNumeral(numericalPlace, out romanNumber))
                    {
                        RomanNumeral = $"{romanNumber}{RomanNumeral}";
                    }
                }
            }
        }

        /// <summary>
        /// Try to convert the number to an exact Roman numeral without subtracting or summing; Ex: 10 = X
        /// </summary>
        /// <param name="number">decimal place number</param>
        /// <param name="romanNumeral">return the roman numeral</param>
        /// <returns>Indicates if it was successul of not</returns>
        private bool TryExactRomanNumeral(int number, out string romanNumeral)
        {
            foreach (var key in _romanNumerals.Keys)
            {
                var quantity = Math.DivRem(number, key, out int remainder);

                if (remainder == 0 && quantity <= 3)
                {
                    romanNumeral = new string(_romanNumerals[key], quantity);

                    return true;
                }
            }

            romanNumeral = null;
            return false;
        }

        /// <summary>
        /// Try converting the number to a Roman numeral by summing; Ex: 7 = VII
        /// </summary>
        /// <param name="number">decimal place number</param>
        /// <param name="romanNumeral">return the roman numeral</param>
        /// <returns>Indicates if it was successul of not</returns>        
        private bool TrySummingRomanNumeral(int number, out string romanNumeral)
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

        /// <summary>
        /// Try converting the number to a Roman numeral by subtracting; Ex: 4 = IV
        /// </summary>
        /// <param name="number">decimal place number</param>
        /// <param name="romanNumeral">return the roman numeral</param>
        /// <returns>Indicates if it was successul of not</returns>
        private bool TrySubtractingRomanNumeral(int number, out string romanNumeral)
        {
            var romanNumeralAboveCurrentNumber = _romanNumerals.Keys
                .Where(x => x > number)
                .OrderBy(x => x)
                .FirstOrDefault();

            if (romanNumeralAboveCurrentNumber > 0)
            {
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
