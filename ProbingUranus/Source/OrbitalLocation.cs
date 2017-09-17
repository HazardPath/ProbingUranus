using System;
using Microsoft.Xna.Framework;

namespace ProbingUranus.Source
{
    class OrbitalLocation : Location
    {
        private EntityEnvironmental parentBody;
        private double semimajorAxis;
        private double trueAnomaly;
        
        public override void Update(GameTime gameTime)
        {
            double radius;
            double newTheta;
            
            //Circle version
            radius = semimajorAxis;
            double velocity = Math.Sqrt(Constants.GRAVITATIONAL_CONSTANT * parentBody.Mass / radius);
            newTheta = trueAnomaly + velocity * gameTime.ElapsedGameTime.TotalSeconds;
          
            this.x = parentBody.Location.X + (radius * Math.Cos(newTheta));
            this.y = parentBody.Location.Y + (radius * Math.Sin(newTheta));
        }

        public OrbitalLocation(EntityEnvironmental parent, double radius, double theta)
        {
            this.parentBody = parent;
            this.semimajorAxis = radius;
            this.trueAnomaly = theta;

            this.x = parent.Location.X + (radius * Math.Cos(theta));
            this.y = parent.Location.Y + (radius * Math.Sin(theta));
        }
    }
}
