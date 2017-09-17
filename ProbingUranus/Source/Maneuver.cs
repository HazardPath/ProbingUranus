using System.Collections.Generic;

namespace ProbingUranus.Source
{
    class Maneuver
    {
        private List<Burn> burns;

        private double deltaV;
        public double DeltaV { get { return this.deltaV; } }

        public Maneuver(Location here, Location there)
        {
            //TODO:
        }
    }

    class Burn
    {
        Location newLocation;
        double deltaV;

        public Burn(Location here, Location there)
        {

        }
    }
}
