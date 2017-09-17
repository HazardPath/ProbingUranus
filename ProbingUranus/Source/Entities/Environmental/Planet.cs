using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ProbingUranus.Source
{
    class Planet : EntityEnvironmental
    {
        private bool hasNukes = false;
        public bool HasNukes
        {
            get { return hasNukes; }
        }

        public void GiveNukes(int count)
        {
            hasNukes = true;
            Art = ArtFetcher.Planet2art;
            Inventory.Resources.Add(typeof(Nuclear), count);
        }

        public Planet(Location location) : base(location, ArtFetcher.Planet1art)
        {
        }
    }
}
