using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    abstract class Entity
    {
        private Location location;
        public Location Location
        {
            get { return location; }
        }
        protected Inventory inventory;
        public Inventory Inventory
        {
            get { return inventory; }
        }
        private List<Recipe> recipes;
        public List<Recipe> Recipes
        {
            get { return recipes; }
        }
        /// <summary>
        /// The art for drawing this entity on the screen.
        /// It's private with no accessor because it will never need to be
        /// changed after the Entity is constructed.
        /// </summary>
        private Texture2D myArt;
        public Texture2D Art
        {
            get { return myArt; }
            set { myArt = value; }
        }
        private double mass;
        public double Mass
        {
            get { return mass; }
            set { this.mass = value; }
        }

        private Type currentlyCrafting;
        public Type CurrentlyCrafting
        {
            get { return currentlyCrafting; }
            set { this.currentlyCrafting = value; }
        }

        public Entity(Location location, Texture2D art, List<Recipe> recipes)
        {
            this.location = location;
            this.myArt = art;
            this.inventory = new Inventory();
            this.recipes = recipes;
        }

        /// <summary>
        /// Draws the Entity based on its art at its location.
        /// </summary>
        /// <param name="sb">the thing you need to draw stuff in C#</param>
        public void drawMe(SpriteBatch sb )
        {
            sb.Draw(
                this.myArt,
                new Rectangle(
                    (int)(this.location.X / 2.0 + 0.5),
                    (int)(this.location.Y / 2.0 + 0.5),
                    this.myArt.Width, this.myArt.Height),
                Color.White);
        }

        public bool Reserve(Entity ent)
        {
            if (Inventory.IsThisReserved)
            {
                return false;
            }

            if (this == ent)
            {
                if(Inventory.ReservedResources.Values.Sum() != 0 || Inventory.IsTowingReserved || Inventory.IsThisReserved)
                {
                    return false;
                }
                else
                {
                    Inventory.IsThisReserved = true;
                    return true;
                }
            }
            else if(ent is EntityResource)
            {
                EntityResource rsc = (EntityResource)ent;
                Type type = rsc.GetType();
                if (Inventory.Resources.ContainsKey(type) && Inventory.Resources[type] >= 1)
                {
                    //we're reserving a resource
                    Inventory.Resources[type]--;
                    Inventory.ReservedResources[type]++;
                }else
                {
                    //be angry about reserving something you don't have
                    return false;
                }
            }
            else if (Inventory.Towing == ent && !Inventory.IsTowingReserved)
            {
                //we're reserving what we're towing
                Inventory.IsTowingReserved = true;
            }
            else
            {
                //be angry about reserving something you don't have
                return false;
            }
            return true;
        }
       
        public void StartBuild(Recipe recipe)
        {
            // ward against stupidity
            if (this.inventory != null)
            {
                this.inventory.ConsumeSupplies(recipe);
                this.currentlyCrafting = recipe.Result;
            }
        }
    }
}
