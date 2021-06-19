using Xunit;

namespace VanHackAssessment.Test
{
    public class ChallengeTest
    {
        [Fact]
        public void ShouldBeI()
        {
            var challenge = new Challenge();
            Assert.True("I" == challenge.Numerals(1), "Roman numeral for 1 is incorrect");
        }

        [Fact]
        public void ShouldBeIV()
        {
            var challenge = new Challenge();
            Assert.True("IV" == challenge.Numerals(4), "Roman numeral for 4 is incorrect");
        }

        [Fact]
        public void ShouldBeVI()
        {
            var challenge = new Challenge();
            Assert.True("VI" == challenge.Numerals(6), "Roman numeral for 6 is incorrect");
        }

        [Fact]
        public void ShouldBeLXXXIX()
        {
            var challenge = new Challenge();
            Assert.True("LXXXIX" == challenge.Numerals(89), "Roman numeral for 89 is incorrect");
        }

        [Fact]
        public void ShouldBeXCI()
        {
            var challenge = new Challenge();
            Assert.True("XCI" == challenge.Numerals(91), "Roman numeral for 91 is incorrect");
        }

        [Fact]
        public void ShouldBeMDCCCLXXXIX()
        {
            var challenge = new Challenge();
            Assert.True("MDCCCLXXXIX" == challenge.Numerals(1889), "Roman numeral for 1889 is incorrect");
        }
    }
}
