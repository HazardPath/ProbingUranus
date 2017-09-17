using Microsoft.Xna.Framework;

namespace ProbingUranus.Source
{
    abstract class Location
    {
        protected double x;
        public double X
        {
            get { return this.x; }
        }

        protected double y;
        public double Y
        {
            get { return this.y; }
        }

        public abstract void Update(GameTime gameTime);
    }

    class StaticLocation : Location
    {
        public StaticLocation(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override void Update(GameTime gameTime) { /*Nothing happens.*/ }
    }
}
