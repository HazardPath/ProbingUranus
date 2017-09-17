using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class MapGenerator
    {
        /// <summary>
        /// Minimum number of planets to add to the depth when generating.
        /// </summary>
        const int MIN_PLANETS_MODIFIER = 2;
        /// <summary>
        /// Maximum number of planets to add to the depth when generating.
        /// </summary>
        const int MAX_PLANETS_MODIFIER = 5;

        /// <summary>
        /// Minimum distance from the sun to a planet.
        /// </summary>
        const double PLANET_RADIUS_MIN = 0.1;
        /// <summary>
        /// Maximum distance form the sun to a planet.
        /// </summary>
        const double PLANET_RADIUS_MAX = 1;

        /// <summary>
        /// When calculating a body's theta (rotational offset), multiply a number between 0 and 1 by this.
        /// </summary>
        const double THETA_SCALING = 2 * Math.PI;

        /// <summary>
        /// Maximum distance from the sun a nuke-bearing planet can be at.
        /// </summary>
        const double PLANET_NUKES_MAX_DISTANCE = 0.3;

        /// <summary>
        /// Minimum number of nukes to have in a map.
        /// </summary>
        const int MIN_NUKE_AMOUNT = 10;
        /// <summary>
        /// Maximum number of nukes to have in a map.
        /// </summary>
        const int MAX_NUKE_AMOUNT = 20;

        /// <summary>
        /// Minimum number of moons for a given planet.
        /// </summary>
        const int MIN_MOON_PER_PLANET = 0;
        /// <summary>
        /// Maximum number of moons for a given planet.
        /// </summary>
        const int MAX_MOON_PER_PLANET = 3;

        /// <summary>
        /// Minimum radius of a moon from its planet.
        /// </summary>
        const double MIN_MOON_RADIUS = 0.02;
        /// <summary>
        /// Maximum radius of a moon from its planet.
        /// </summary>
        const double MAX_MOON_RADIUS = 0.05;

        private static Random rng = new Random();

        public static Map GenerateMap(Map previousMap)
        {
            //Set simple stuff, like the depth and the sun.
            Map map = new Map();
            map.Depth = previousMap.Depth + 1;
            map.Sun = new Sun();

            //Figure out how many planets we've got
            int planetCount = map.Depth;
            planetCount += RngBetween(MIN_PLANETS_MODIFIER, MAX_PLANETS_MODIFIER);

            //Make those planets
            List<Planet> planets = new List<Planet>();
            List<Planet> nukeCandidates = new List<Planet>(); //keep track of those within nuke range
            Planet closestToSun = null; //keep track of this in case there's nobody in nuke range, so we can move it in closer
            double closestRadius = -1;
            for (int i=0; i<planetCount; i++)
            {
                double radius = RngBetween(PLANET_RADIUS_MIN, PLANET_RADIUS_MAX);
                OrbitalLocation loc = new OrbitalLocation(map.Sun, radius, THETA_SCALING*rng.NextDouble());
                Planet noobie = new Planet(loc);

                if(radius <= PLANET_NUKES_MAX_DISTANCE)
                {
                    nukeCandidates.Add(noobie);
                }
                if(closestToSun==null || closestRadius > radius)
                {
                    closestToSun = noobie;
                    closestRadius = radius;
                }

                planets.Add(noobie);
            }

            //If nobody's within nuke range, move the closest one in
            if(nukeCandidates.Count == 0)
            {
                planets.Remove(closestToSun);
                double radius = RngBetween(PLANET_RADIUS_MIN, PLANET_NUKES_MAX_DISTANCE);
                OrbitalLocation loc = new OrbitalLocation(map.Sun, radius, THETA_SCALING * rng.NextDouble());
                Planet noobie = new Planet(loc);
                nukeCandidates.Add(noobie);
                planets.Add(noobie);
            }

            //Randomly pick among the candidates some number of planets to have nukes on them
            int nukePlanets = RngBetween(1, nukeCandidates.Count);
            int amountOfNukes = RngBetween(MIN_NUKE_AMOUNT, MAX_NUKE_AMOUNT);
            for(int i=0; i<nukePlanets; i++)
            {
                int indexToNuke = RngBetween(0, nukeCandidates.Count - 1);
                Planet planetToNuke = nukeCandidates[indexToNuke];

                //nuber of nukes is random between 1 and the total number of undistributed
                //nukes, minus one for each planet we haven't given a nuke to yet (to guarantee
                //everyone will get at least one nuke)
                int numberOfNukes = RngBetween(1, amountOfNukes - (nukePlanets - i));

                planetToNuke.GiveNukes(numberOfNukes);
                nukeCandidates.RemoveAt(indexToNuke);
            }

            //For each planet, generate some moons
            List<Moon> moons = new List<Moon>();
            for(int i=0; i<planets.Count; i++)
            {
                Planet parent = planets[i];
                double radius = RngBetween(MIN_MOON_RADIUS, MAX_MOON_RADIUS);
                OrbitalLocation loc = new OrbitalLocation(parent, radius, THETA_SCALING * rng.NextDouble());
                Moon babby = new Moon(loc);
                moons.Add(babby);
            }

            //TODO Also generate some asteroids/comets to float around

            //TODO For all the moons and asteroids, divide up the 3 resources among them all

            return map;
        }

        /// <summary>
        /// Generate a random number between min and max, inclusive.
        /// </summary>
        private static int RngBetween(int min, int max)
        {
            return rng.Next() % (max+1 - min) + min;
        }

        /// <summary>
        /// Generate a random number between min and max. Getting min is theoretically possible; getting max is not.
        /// </summary>
        private static double RngBetween(double min, double max)
        {
            if (min == max) return 0;
            return rng.NextDouble() % (max - min) + min;
        }
    }
}
