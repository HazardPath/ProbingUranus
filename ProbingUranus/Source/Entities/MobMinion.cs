using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class MobMinion : EntityMobile
    {
        public MobMinion(Location location) : base(location, ArtFetcher.Minionart, null)
        {

        }

        protected MobMinion(Location location, Texture2D art) : base(location, art, null)
        {

        }

        public bool Give(Entity giving, Entity target)
        {
            if (giving is EntityResource)
            {
                EntityResource rsc = (EntityResource)giving;
                Type type = rsc.GetType();
                if (Inventory.ReservedResources.ContainsKey(type) && Inventory.ReservedResources[type] >= 1)
                {
                    //we're giving a resource
                    Inventory.ReservedResources[type]--;
                    target.Inventory.Resources[type]++;
                }
            }
            else if (Inventory.Towing == giving && target.Inventory.Towing == null)
            {
                //we're giving what we're towing
                Inventory.Towing = null;
                Inventory.IsTowingReserved = false;
                target.Inventory.Towing = giving;
            }
            else
            {
                //be angry about this
                return false;
            }
            return true;
        }

        public bool Collect(Entity toGet, Entity target)
        {
            if (toGet == target)
            {
                //we're picking up the target
                inventory.Towing = target;
                target.Inventory.IsThisReserved = false;
                //TODO whatever you need to do, if anything, to notify the target it's been towed
            }
            else if (toGet is EntityResource)
            {
                EntityResource rsc = (EntityResource)toGet;
                Type type = rsc.GetType();
                if (target.Inventory.ReservedResources.ContainsKey(type) && target.Inventory.ReservedResources[type] >= 1)
                {
                    //we're getting a resource from the target
                    target.Inventory.ReservedResources[type]--;
                    Inventory.Resources[type]++;
                }
                else
                {
                    //be angry about taking something they don't have
                    return false;
                }
            }
            else if (target.Inventory.Towing == toGet)
            {
                //we're getting what the target is towing
                target.Inventory.Towing = null;
                target.Inventory.IsTowingReserved = false;
                Inventory.Towing = toGet;
            }
            else
            {
                //be angry about taking something they don't have
                return false;
            }
            return true;
        }
    }
}
