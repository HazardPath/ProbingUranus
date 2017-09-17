using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class Map
    {
        /// <summary>
        /// How deep is this - depth 0 is the initial map, each probe launch is 1 deeper
        /// </summary>
        public int Depth;

        /// <summary>
        /// Contains all parts of the environment - planets, moons, comets, asteroids. Even the sun's in here.
        /// </summary>
        public List<EntityEnvironmental> Environment;

        /// <summary>
        /// The sun, kept here for easy reference.
        /// </summary>
        public Sun Sun;
    }
}
