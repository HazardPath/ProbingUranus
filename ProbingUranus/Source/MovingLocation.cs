using System;
using Microsoft.Xna.Framework;

namespace ProbingUranus.Source
{
    class MovingLocation : Location
    {
        private Location here;
        public Location Here
        {
            get { return this.here; }
        }

        private Location there;
        public Location There
        {
            get { return this.there; }
        }

        private double x;
        public double X
        {
            get { return x; }
        }

        private double y;
        public double Y
        {
            get { return y; }
        }

        private double totalTime;
        public double TotalTime
        {
            get { return TotalTime; }
        }

        private double t0;

        public override void Update(GameTime gameTime)
        {
            double progress = (gameTime.ElapsedGameTime.TotalSeconds - t0) / totalTime;
            this.x = progress * this.there.X + (1 - progress) * this.here.X;
            this.y = progress * this.there.Y + (1 - progress) * this.here.Y;
        }

        public MovingLocation(Location here, Location there, GameTime gameTime)
        {
            double dX = Math.Abs(there.X - here.X);
            double dY = Math.Abs(there.Y - here.Y);
            this.totalTime = 2 * Math.Sqrt(Math.Sqrt(dX * dX + dY * dY) / 9.81);
            this.t0 = gameTime.ElapsedGameTime.TotalSeconds;
            this.here = here;
            this.there = there;
        }
    }
}
