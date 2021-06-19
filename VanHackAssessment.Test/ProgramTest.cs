using Xunit;

namespace VanHackAssessment.Test
{
    public class ProgramTest
    {
        [Fact]
        public void ShouldHandleSmallCases()
        {
            Assert.Equal("I", Program.Numerals(1));
            Assert.Equal("IV", Program.Numerals(4));
            Assert.Equal("VI", Program.Numerals(6));

            Assert.Equal("LXXXIX", Program.Numerals(89));
            Assert.Equal("XCI", Program.Numerals(91));
            Assert.Equal("MDCCCLXXXIX", Program.Numerals(1889));
        }
    }
}
