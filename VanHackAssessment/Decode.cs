using System.Collections.Generic;

namespace VanHackAssessment
{
    public class Decode
    {
        private static readonly Dictionary<string, int> _romanNumerals = new Dictionary<string, int>()
        {
            { "M", 1000 },
            { "D", 500 },
            { "C", 100 },
            { "L", 50 },
            { "X", 10 },
            { "V", 5 },
            { "I", 1 },
        };

        public int Process(string roman)
        {
            return ExtractRomanPlaces(roman);
        }

        /// <summary>
        /// Extract each symbol from the roman number to post-process separately
        /// </summary>
        /// <param name="number">Number to extract</param>
        private int ExtractRomanPlaces(string romanNumber)
        {
            int value = 0;

            for (int i = romanNumber.Length - 1; i >= 0; i--)
            {
                int nextValueIndex = i - 1;

                var currentPlaceString = romanNumber.Substring(i, 1);
                var nextPlaceString = nextValueIndex >= 0 ? romanNumber.Substring(nextValueIndex, 1) : null;

                var currentValue = _romanNumerals[currentPlaceString];
                var nextValue = nextPlaceString != null ? (int?)_romanNumerals[nextPlaceString] : null;

                if (nextValue.HasValue && nextValue.Value < currentValue)
                {
                    value += currentValue - nextValue.Value;
                    i = nextValueIndex;
                }
                else
                {
                    int sum = currentValue + (nextValue ?? 0);
                    var process = true;
                    while (process)
                    {                        
                        nextValueIndex --;
                        i = nextValueIndex;

                        nextPlaceString = nextValueIndex >= 0 ? romanNumber.Substring(nextValueIndex, 1) : null;
                        nextValue = nextPlaceString != null ? (int?)_romanNumerals[nextPlaceString] : null;

                        if (!nextValue.HasValue || nextValue.Value < currentValue)
                        {
                            process = false;
                        }
                        else
                        {
                            sum += nextValue.Value;                            
                        }
                    }

                    value += sum;
                }
            }

            return value;
        }
    }
}
