using System;

namespace ZartisRocketLanding
{
    public class Position
    {
        public Position(int x, int y) {
            if(x < 0 || y < 0)
                throw new ArgumentOutOfRangeException("Position should be a positive value");
            if(x > 100 || y > 100)
                throw new ArgumentOutOfRangeException("Position has a limit of 100");
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}