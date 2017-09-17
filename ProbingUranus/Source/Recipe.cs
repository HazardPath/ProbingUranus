using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class Recipe
    {
        private readonly Type result;
        public Type Result
        {
            get { return result; }
        }

        private readonly Dictionary<Type, int> ingredients;
        public Dictionary<Type, int> Ingredients
        {
            get { return ingredients; }
        }

        public Recipe (Type result)
        {
            this.result = result;
            this.ingredients = new Dictionary<Type, int>();
        }

        /// <summary>
        /// Makes a new instance of a recipe for making a minion.
        /// </summary>
        /// <returns>a recipe for making a minion</returns>
        public static Recipe GetMinionRecipe()
        {
            Recipe temp = new Recipe(typeof(MobMinion));
            temp.ingredients.Add(typeof(Iron), 1);
            temp.ingredients.Add(typeof(Minerals), 1);
            return temp;
        }

        public static Recipe GetProbeRecipe()
        {
            Recipe temp = new Recipe(typeof(MobProbe));
            temp.ingredients.Add(typeof(Steel), 6);
            temp.ingredients.Add(typeof(Minerals), 6);
            temp.ingredients.Add(typeof(FuelRods), 6);
            temp.ingredients.Add(typeof(StaticFactory), 6);
            temp.ingredients.Add(typeof(StaticMiner), 6);
            temp.ingredients.Add(typeof(StaticRefinery), 6);
            return temp;
        }

        public static Recipe GetRefineryRecipe()
        {
            Recipe temp = new Recipe(typeof(StaticRefinery));
            temp.ingredients.Add(typeof(Iron), 2);
            temp.ingredients.Add(typeof(Minerals), 2);
            return temp;
        }

        public static Recipe GetFactoryRecipe()
        {
            Recipe temp = new Recipe(typeof(StaticFactory));
            temp.ingredients.Add(typeof(Iron), 1);
            temp.ingredients.Add(typeof(Minerals), 2);
            return temp;
        }

        public static Recipe GetMinerRecipe()
        {
            Recipe temp = new Recipe(typeof(StaticMiner));
            temp.ingredients.Add(typeof(Iron), 2);
            temp.ingredients.Add(typeof(Minerals), 1);
            return temp;
        }

        public static Recipe GetMinionHeavyRecipe()
        {
            Recipe temp = new Recipe(typeof(MobMinionHeavy));
            temp.ingredients.Add(typeof(MobMinion), 1);
            temp.ingredients.Add(typeof(Steel), 1);
            return temp;
        }

        public static Recipe GetMinerHeavyRecipe()
        {
            Recipe temp = new Recipe(typeof(StaticMinerHeavy));
            temp.ingredients.Add(typeof(StaticMiner), 1);
            temp.ingredients.Add(typeof(Steel), 1);
            return temp;
        }

        public static Recipe GetSteelRecipe()
        {
            Recipe temp = new Recipe(typeof(Steel));
            temp.ingredients.Add(typeof(Iron), 1);
            temp.ingredients.Add(typeof(Minerals), 1);
            return temp;
        }

        public static Recipe GetFuelRodsRecipe()
        {
            Recipe temp = new Recipe(typeof(FuelRods));
            temp.ingredients.Add(typeof(Minerals), 1);
            temp.ingredients.Add(typeof(Nuclear), 1);
            return temp;
        }
    }
}