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

        public LandingQueryReply QueryTrajectory(Rocket rocket) {

            // Ok for Landing condition
            if((rocket.Position.X >= Position.X 
                && rocket.Position.X < (Position.X + Width))
                && rocket.Position.Y >= Position.Y 
                && rocket.Position.Y < (Position.Y + Height))
                return LandingQueryReply.OkForLanding;
            
            return LandingQueryReply.OutOfPlaform;
        }
    }

    public enum LandingQueryReply
    {
        OkForLanding = 1,
        OutOfPlaform,
        Clash,
        
    }
}