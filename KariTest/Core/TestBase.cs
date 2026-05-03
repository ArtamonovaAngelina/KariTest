using NUnit.Framework;
using KariTests.Core;

namespace KariTests.Tests
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetupTest()
        {
            app = AppManager.GetInstance();
        }
    }
}