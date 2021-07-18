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
            Assert.AreEqual(LandingQueryReply.OkForLanding, result);
        }


        [Test]
        public void QueryTrajectory_PlatformAndRocketMoving_OkForLanding()
        {
            // Arrange
            var platform = new Platform(new Position(5,5), 10, 10);
            var rocket = new Rocket(new Position(4,3));
            
            // Act 
            var result1 = platform.QueryTrajectory(rocket);
            rocket.Position = new Position(4,4);
            var result2 = platform.QueryTrajectory(rocket);
            rocket.Position = new Position(5,5);
            var result3 = platform.QueryTrajectory(rocket);

            // Assert 
            Assert.AreEqual(LandingQueryReply.OutOfPlaform, result1);
            Assert.AreEqual(LandingQueryReply.OutOfPlaform, result2);
            Assert.AreEqual(LandingQueryReply.OkForLanding, result3);
        }

        [Test]
        public void QueryTrajectory_PlatformX5Y5W10H10RocketX16Y15_OutOfPlaform()
        {
            // Arrange
            var platform = new Platform(new Position(5,5), 10, 10);
            var rocket = new Rocket(new Position(16,15));
            
            // Act 
            var result = platform.QueryTrajectory(rocket);

            // Assert 
            Assert.AreEqual(LandingQueryReply.OutOfPlaform, result);
        }

        [Test]
        public void QueryTrajectory_PlatformX5Y5W10H10RocketX60Y76_OutOfPlaform()
        {
            // Arrange
            var platform = new Platform(new Position(5,5), 10, 10);
            var rocket = new Rocket(new Position(60,76));
            
            // Act 
            var result = platform.QueryTrajectory(rocket);

            // Assert 
            Assert.AreEqual(LandingQueryReply.OutOfPlaform, result);
        }

        [Test]
        public void QueryTrajectory_PlatformX5Y5W10H10Rocket1X4Y4Rocket2X4Y4_Clash()
        {
            // Arrange
            var platform = new Platform(new Position(5,5), 10, 10);
            var rocket1 = new Rocket(new Position(4,4));
            var rocket2 = new Rocket(new Position(4,4));
            
            // Act 
            var result1 = platform.QueryTrajectory(rocket1);
            var result2 = platform.QueryTrajectory(rocket2);

            // Assert 
            Assert.AreEqual(LandingQueryReply.OutOfPlaform, result1);
            Assert.AreEqual(LandingQueryReply.Clash, result2);
        } 

        [TestCase(12, 7, 12, 7)]
        [TestCase(12, 7, 11, 6)]
        [TestCase(12, 7, 11, 7)]
        [TestCase(12, 7, 11, 8)]
        [TestCase(12, 7, 12, 6)]
        [TestCase(12, 7, 12, 8)]
        [TestCase(12, 7, 13, 6)]
        [TestCase(12, 7, 13, 7)]
        [TestCase(12, 7, 13, 8)]
        public void QueryTrajectory_PlatformX5Y5W10H10Rocket1OkRocket2_Clash(int rocket1X, int rocket1Y, int rocket2X, int rocket2Y)
        {
            // Arrange
            var platform = new Platform(new Position(5,5), 10, 10);
            var rocket1 = new Rocket(new Position(rocket1X, rocket1Y));
            var rocket2 = new Rocket(new Position(rocket2X, rocket2Y));
            
            // Act 
            var result1 = platform.QueryTrajectory(rocket1);
            var result2 = platform.QueryTrajectory(rocket2);

            // Assert 
            Assert.AreEqual(LandingQueryReply.OkForLanding, result1);
            Assert.AreEqual(LandingQueryReply.Clash, result2);
        } 
    }
}