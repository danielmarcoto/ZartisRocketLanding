namespace ZartisRocketLanding
{
    public class Platform
    {
        private Rocket _lastRocket;
        public Platform(Position position, int width, int height) 
        {
            Position = position;
            Width = width;
            Height = height;
            _lastRocket = null;
        }
        public Position Position { get; set; }
        public int Width { get; set; }
        public int Height {get; set; }

        public LandingQueryReply QueryTrajectory(Rocket rocket) {

            // Checks the last rocket position
            if(_lastRocket != null && _lastRocket != rocket)
            {
                if((rocket.Position.X == _lastRocket.Position.X 
                    || rocket.Position.X == (_lastRocket.Position.X + 1)
                    || rocket.Position.X == (_lastRocket.Position.X - 1)) 
                    && (rocket.Position.Y == _lastRocket.Position.Y 
                    || rocket.Position.Y == (_lastRocket.Position.Y + 1)
                    || rocket.Position.Y == (_lastRocket.Position.Y - 1)))
                    return LandingQueryReply.Clash;
            }
            
            // Updates last rocket
            _lastRocket = rocket;

            // Ok for Landing condition
            if(rocket.Position.X >= Position.X 
                && rocket.Position.X < (Position.X + Width)
                && rocket.Position.Y >= Position.Y 
                && rocket.Position.Y < (Position.Y + Height)) 
            {
                return LandingQueryReply.OkForLanding;
            }

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