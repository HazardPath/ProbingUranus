using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class Inventory
    {
        /// <summary>
        /// Indicates if anything is currently planning to pick up the Entity with this Inventory.
        /// </summary>
        public bool IsThisReserved = false;

        private Dictionary<Type, int> resources = new Dictionary<Type, int>();
        public Dictionary<Type, int> Resources
        {
            get { return resources; }
        }

        private Dictionary<Type, int> reservedResources = new Dictionary<Type, int>();
        public Dictionary<Type, int> ReservedResources
        {
            get { return reservedResources; }
        }

        public bool IsTowingReserved = false;
        private Entity towing = null;
        public Entity Towing
        {
            get { return towing; }
            set { towing = value; }
        }

        public bool HasSuppliesFor(Recipe recipe)
        {
            // Temporarily convert to array to we can access by index.
            KeyValuePair<Type, int>[] tempArray = recipe.Ingredients.ToArray();

            // For each ingredient,
            for (int i = 0; i < recipe.Ingredients.Count; i++)
            {
                // mystical ward against stupidity
                if (tempArray[i].Value <= 0)
                {
                    // if we have some of that ingredient,
                    if (this.resources.ContainsKey(tempArray[i].Key))
                    {
                        // if we don't have enough, give up
                        if (this.resources[tempArray[i].Key] < tempArray[i].Value)
                        {
                            return false;
                        }
                    }
                    // If we don't even have a record for this, give up.
                    else
                    {
                        return false;
                    }
                }
            }
            // If we got to the end, that means that we had everything we need.
            return true;
        }

        public void ConsumeSupplies(Recipe recipe)
        {
            // Temporarily convert to array to we can access by index.
            KeyValuePair<Type, int>[] tempArray = recipe.Ingredients.ToArray();

            // For each ingredient,
            for (int i = 0; i < recipe.Ingredients.Count; i++)
            {
                // mystical ward against stupidity
                if (tempArray[i].Value <= 0)
                {
                    // avoid null pointer errors just in case
                    if (this.resources.ContainsKey(tempArray[i].Key))
                    {
                        // reduce relevant resources by correct amount
                        this.resources[tempArray[i].Key] -= tempArray[i].Value;
                    }
                }
            }
        }
    }
}
