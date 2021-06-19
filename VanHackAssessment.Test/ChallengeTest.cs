using Xunit;

namespace VanHackAssessment.Test
{
    public class ChallengeTest
    {
        [Fact]
        public void ShouldHandleSmallCases()
        {
            var challenge = new Challenge();

            Assert.True("I" == challenge.Numerals(1), "Roman numeral for 1 is incorrect");
            Assert.True("IV" == challenge.Numerals(4), "Roman numeral for 4 is incorrect");
            Assert.True("VI" == challenge.Numerals(6), "Roman numeral for 6 is incorrect");

            Assert.True("LXXXIX" == challenge.Numerals(89), "Roman numeral for 89 is incorrect");
            Assert.True("XCI" == challenge.Numerals(91), "Roman numeral for 91 is incorrect");
            Assert.True("MDCCCLXXXIX" == challenge.Numerals(1889), "Roman numeral for 1889 is incorrect");
        }
    }
}
