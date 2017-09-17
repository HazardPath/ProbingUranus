using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ProbingUranus.Source
{
    class Moon : EntityEnvironmental
    {
        public Moon(Location location) : base(location, ArtFetcher.Moon1art)
        {
        }
    }
}
