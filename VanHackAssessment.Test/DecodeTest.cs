using Xunit;

namespace VanHackAssessment.Test
{
    public class DecodeTest
    {
        [Fact]
        public void ShouldWorkForIndividualCharacters()
        {
            Assert.True(1 == Challenge.Decode("I"));
        }

        [Fact]
        public void ShouldHandleDescendingValues()
        {
            Assert.True(21 == Challenge.Decode("XXI"));
        }

        [Fact]
        public void ShouldHandleAscendingValues()
        {
            Assert.True(4 == Challenge.Decode("IV"));
        }
    }
}
