using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ProbingUranus.Source
{
    class Sun : EntityEnvironmental
    {
        public Sun() : base(new StaticLocation(0,0), ArtFetcher.Sunart)
        {
        }
    }
}
