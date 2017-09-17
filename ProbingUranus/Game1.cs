using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProbingUranus.Source;
using System.Collections.Generic;

namespace ProbingUranus
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MenuController menuController;

        private List<Entity> stuffToDraw = new List<Entity>();

        /// <summary>
        /// The key is a reference to the entity doing the building; the value
        /// the when the build started. Entities track what they're building.
        /// </summary>
        private static Dictionary<Entity, double> buildsInProgress = new Dictionary<Entity, double>();
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 960;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            menuController = new MenuController(this);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ArtFetcher.Initialize(Content);
            SoundFetcher.Initialize(Content);


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            menuController.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            menuController.Draw(spriteBatch);

            foreach (Entity temp in stuffToDraw)
            {
                temp.drawMe(spriteBatch);
            }

            // TODO: Add your drawing code here

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public static bool StartABuild(Entity requestor, Recipe request, GameTime gameTime)
        {
            // Check that the requestor isn't busy building something else.
            if (Game1.buildsInProgress.ContainsKey(requestor)) {
                return false;
            }
            // Check that the requester has recipes and has this recipe in particular.
            if (requestor.Recipes != null)
            {
                if (!requestor.Recipes.Contains(request))
                {
                    return false;
                }
            } else
            {
                return false;
            }
            // Check that requestor has an inventory and has the necessary ingredients.
            if (requestor.Inventory != null)
            {
                if (!requestor.Inventory.HasSuppliesFor(request))
                {
                    return false;
                }
            } else
            {
                return false;
            }
            // Actually kick off the build.
            requestor.StartBuild(request);
            Game1.buildsInProgress.Add(requestor, gameTime.TotalGameTime.TotalSeconds);
            return true;
        }
    }
}
