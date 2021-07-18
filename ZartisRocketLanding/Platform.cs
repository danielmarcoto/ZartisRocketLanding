namespace ZartisRocketLanding
{
    public class Platform
    {
        private Position _lastRocketPosition;
        public Platform(Position position, int width, int height) 
        {
            Position = position;
            Width = width;
            Height = height;
            _lastRocketPosition = null;
        }
        public Position Position { get; set; }
        public int Width { get; set; }
        public int Height {get; set; }

        public LandingQueryReply QueryPosition(Rocket rocket) {
            
            return LandingQueryReply.OkForLanding;
        }
    }

    public enum LandingQueryReply
    {
        OutOfPlaform = 1,
        Clash,
        OkForLanding
    }
}