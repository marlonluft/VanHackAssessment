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


        [Fact]
        public void ShouldHandleM()
        {
            Assert.True(1000 == Challenge.Decode("M"));
        }

        [Fact]
        public void ShouldHandleMCMXC()
        {
            Assert.True(1990 == Challenge.Decode("MCMXC"));
        }

        [Fact]
        public void ShouldHandleMMVIII()
        {
            Assert.True(2008 == Challenge.Decode("MMVIII"));
        }

        [Fact]
        public void ShouldHandleMDCLXVI()
        {
            Assert.True(1666 == Challenge.Decode("MDCLXVI"));
        }
    }
}
