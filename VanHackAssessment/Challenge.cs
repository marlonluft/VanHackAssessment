using System.Collections.Generic;

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

        private string _romanNumeral;
        private int _lastNumber;

        public string Numerals(int num)
        {
            _romanNumeral = string.Empty;
            _lastNumber = num;

            foreach (var key in romanNumerals.Keys)
            {
                var lastNumberText = _lastNumber.ToString();

                if (_lastNumber == 1 || (lastNumberText.StartsWith("5") || (lastNumberText.StartsWith("1") && _lastNumber >= 10)))
                {
                    _romanNumeral = TryUniqueRomanNumeral(key);
                }
                else
                {
                    _romanNumeral += _lastNumber >= 10 ?
                    TryIncrease(key) : TryDecrease(key);
                }

                if (_lastNumber == 0)
                {
                    break;
                }
            }

            return _romanNumeral;
        }

        private string TryUniqueRomanNumeral(int romanNumber)
        {
            int resto = _lastNumber % romanNumber;

            if (resto != _lastNumber)
            {
                _lastNumber = resto;
                var reRunResult = TryUniqueRomanNumeral(romanNumber);
                return romanNumerals[romanNumber] + reRunResult;
            }

            return string.Empty;
        }

        private string TryIncrease(int romanNumber)
        {
            var romanNumeral = string.Empty;

            foreach (var key in romanNumerals.Keys)
            {
                for (int i = 3; i >= 1; i--)
                {
                    var sum = romanNumber + key * i;

                    if (sum <= _lastNumber)
                    {
                        _lastNumber -= sum;
                        romanNumeral += new string(romanNumerals[key], i);

                        return romanNumeral;
                    }
                }
            }

            return string.Empty;
        }

        private string TryDecrease(int romanNumber)
        {
            foreach (var key in romanNumerals.Keys)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (romanNumber - key * i == _lastNumber)
                    {
                        _lastNumber = 0;
                        return new string(romanNumerals[key], i) + romanNumerals[romanNumber];
                    }
                }
            }

            return string.Empty;
        }
    }
}
