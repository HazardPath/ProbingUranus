﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class StaticMiner : EntityStatic
    {
        public StaticMiner(Location location) : base(location, ArtFetcher.Minerart, null)
        {

        }
        protected StaticMiner(Location location, Texture2D art) : base(location, art, null)
        {

        }
    }
}
