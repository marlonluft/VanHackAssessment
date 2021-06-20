namespace VanHackAssessment
{
    public class Challenge
    {
        public static string Numerals(int num) =>
            new Encode().Process(num);

        public static int Decode(string roman) =>
            new Decode().Process(roman);
    }
}
