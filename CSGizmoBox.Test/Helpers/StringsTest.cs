using CSGizmoBox.Helpers;

namespace CSGizmoBox.Test.Helpers
{
    public class StringsTest
    {

        [Fact]
        public void GetDefaultTest_Null()
        {
            Assert.Equal("", strings.GetDefault(null));
            Assert.Equal("0", strings.GetDefault(null, "0"));
            Assert.Equal(" ", strings.GetDefault(null, " "));
        }


        [Fact]
        public void GetDefaultTest_Whitespace_or_Empty()
        {
            Assert.Equal("", strings.GetDefault(""));
            Assert.Equal("0", strings.GetDefault("", "0"));
            Assert.Equal(" ", strings.GetDefault(" ", "0"));
        }

    }
}
