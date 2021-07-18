using NUnit.Framework;
using System;

namespace ZartisRocketLanding
{
    [TestFixture]
    public class PositionTest
    {
        [Test]
        public void Constructor_X0Y0_Valid() 
        {
            // Arrange / Act
            var position = new Position(0, 0);

            // Assert
            Assert.AreEqual(0, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [Test]
        public void Constructor_X100Y100_Valid() 
        {
            // Arrange / Act
            var position = new Position(100, 100);

            // Assert
            Assert.AreEqual(100, position.X);
            Assert.AreEqual(100, position.Y);
        }

        [Test]
        public void Constructor_X101Y101_Exception() 
        {
            // Arrange / Act
            Assert.Throws<ArgumentOutOfRangeException>(() => new Position(101, 101));
        }

        [Test]
        public void Constructor_XNegativeYNegative_Exception() 
        {
            // Arrange / Act
            Assert.Throws<ArgumentOutOfRangeException>(() => new Position(-1, -1));
        }
    }
}