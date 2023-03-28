using Xunit.Abstractions;

namespace NeteaseCloudMusicApi.Test
{
    public class TestBase
    {
        protected readonly ITestOutputHelper Output;

        public TestBase(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}
