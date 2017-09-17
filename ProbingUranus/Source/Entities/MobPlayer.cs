using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class MobPlayer : EntityMobile
    {
        public MobPlayer(Location location) : base(location, ArtFetcher.Playerart, new List<Recipe>())
        {
            this.Recipes.Add(Recipe.GetMinionRecipe());
            this.Recipes.Add(Recipe.GetProbeRecipe());
            this.Recipes.Add(Recipe.GetRefineryRecipe());
            this.Recipes.Add(Recipe.GetFactoryRecipe());
            this.Recipes.Add(Recipe.GetMinerRecipe());
            this.Recipes.Add(Recipe.GetMinionHeavyRecipe());
            this.Recipes.Add(Recipe.GetMinerHeavyRecipe());
            this.Recipes.Add(Recipe.GetSteelRecipe());
            this.Recipes.Add(Recipe.GetFuelRodsRecipe());
        }
    }
}
