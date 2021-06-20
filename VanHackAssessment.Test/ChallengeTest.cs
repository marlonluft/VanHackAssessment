using Xunit;

namespace VanHackAssessment.Test
{
    public class ChallengeTest
    {
        [Fact]
        public void ShouldBeI()
        {
            var challenge = new Challenge();
            var roman = challenge.Numerals(1);

            Assert.True("I" == roman, $"Roman numeral {roman} for 1 is incorrect");
        }

        [Fact]
        public void ShouldBeIV()
        {
            var challenge = new Challenge();
            var roman = challenge.Numerals(4);

            Assert.True("IV" == roman, $"Roman numeral {roman} for 4 is incorrect");
        }

        [Fact]
        public void ShouldBeVI()
        {
            var challenge = new Challenge();
            var roman = challenge.Numerals(6);

            Assert.True("VI" == roman, $"Roman numeral {roman} for 6 is incorrect");
        }

        [Fact]
        public void ShouldBeLXXXIX()
        {
            var challenge = new Challenge();
            var roman = challenge.Numerals(89);

            Assert.True("LXXXIX" == roman, $"Roman numeral {roman} for 89 is incorrect");
        }

        [Fact]
        public void ShouldBeXCI()
        {
            var challenge = new Challenge();
            var roman = challenge.Numerals(91);

            Assert.True("XCI" == roman, $"Roman numeral {roman} for 91 is incorrect");
        }

        [Fact]
        public void ShouldBeMDCCCLXXXIX()
        {
            var challenge = new Challenge();
            var roman = challenge.Numerals(1889);

            Assert.True("MDCCCLXXXIX" == roman, $"Roman numeral {roman} for 1889 is incorrect");
        }
    }
}
