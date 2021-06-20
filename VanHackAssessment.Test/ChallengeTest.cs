using Xunit;

namespace VanHackAssessment.Test
{
    public class ChallengeTest
    {
        [Fact]
        public void ShouldBeI()
        {
            var roman = Challenge.Numerals(1);
            Assert.True("I" == roman, $"Roman numeral {roman} for 1 is incorrect");
        }

        [Fact]
        public void ShouldBeIV()
        {
            var roman = Challenge.Numerals(4);
            Assert.True("IV" == roman, $"Roman numeral {roman} for 4 is incorrect");
        }

        [Fact]
        public void ShouldBeVI()
        {
            var roman = Challenge.Numerals(6);
            Assert.True("VI" == roman, $"Roman numeral {roman} for 6 is incorrect");
        }

        [Fact]
        public void ShouldBeLXXXIX()
        {
            var roman = Challenge.Numerals(89);
            Assert.True("LXXXIX" == roman, $"Roman numeral {roman} for 89 is incorrect");
        }

        [Fact]
        public void ShouldBeXCI()
        {
            var roman = Challenge.Numerals(91);
            Assert.True("XCI" == roman, $"Roman numeral {roman} for 91 is incorrect");
        }

        [Fact]
        public void ShouldBeMDCCCLXXXIX()
        {
            var roman = Challenge.Numerals(1889);
            Assert.True("MDCCCLXXXIX" == roman, $"Roman numeral {roman} for 1889 is incorrect");
        }

        [Fact]
        public void ShouldBeXXI()
        {
            var roman = Challenge.Numerals(21);
            Assert.True("XXI" == roman, $"Roman numeral {roman} for 21 is incorrect");
        }
    }
}
