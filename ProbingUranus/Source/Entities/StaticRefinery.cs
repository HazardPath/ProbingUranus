using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class StaticRefinery : EntityStatic
    {
        public StaticRefinery(Location location) : base(location, ArtFetcher.Staticrefineryart, null)
        {

        }
    }
}
