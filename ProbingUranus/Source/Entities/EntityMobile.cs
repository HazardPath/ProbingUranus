﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    abstract class EntityMobile : Entity 
    {
        public EntityMobile(Location location, Texture2D art, List<Recipe> recipes) : base(location, art, recipes)
        {

        }
        public void MoveTo(Entity target)
        {
            //TODO
        }
    }
}
