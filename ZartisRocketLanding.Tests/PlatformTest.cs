using NUnit.Framework;
using ZartisRocketLanding;

namespace ZartisRocketLanding.Tests
{
    public class PlatformTest
    {
        [Test]
        public void QueryTrajectory_PlatformAndRocketX5Y5_OkForLanding()
        {
            // Arrange
            var platform = new Platform(new Position(5,5), 10, 10);
            var rocket = new Rocket(new Position(5,5));
            
            // Act 
            var result = platform.QueryTrajectory(rocket);

            // Assert 
            Assert.AreEqual(result, LandingQueryReply.OkForLanding);
        }
    }
}