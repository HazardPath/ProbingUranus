using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class MenuController
    {
        public enum Screen
        {
            //Start the game on the menu screen.
            Menu,
            //Playing the level screen
            Play,
            //You dead
            Lose,
            //You beat the level
            Win

        };

        private Screen currentScreen = Screen.Menu;
        /// <summary>
        /// Gets or sets the current screen.
        /// </summary>
        /// <value>The current screen.</value>
        public Screen CurrentScreen
        {
            get { return currentScreen; }
            set { currentScreen = value; }
        }

        private static bool IsPaused = false;
        private static bool IsBuildOn = false;
        private static bool IsBuildMinionOn = false;
        private static bool IsBuildMinerOn = false;
        private static bool IsRefineOn = false;


        ///This has the correct art.
        ///
        ///Start playing the game button
        private MenuButton StartGameButt = new MenuButton(new Rectangle(400, 400, 400, 100), ArtFetcher.Startgamebutt);
        ///Pause the current game button
        private MenuButton PauseGameButt = new MenuButton(new Rectangle(1200, 900, 40, 40), ArtFetcher.Pausegamebutt);
        ///Unpause the current game button
        private MenuButton PlayGameButt = new MenuButton(new Rectangle(1200, 900, 40, 40), ArtFetcher.Playgamebutt);      

        ///This does not have the correct art.
        ///
        ///Leave the level and move on to a new level
        private MenuButton ReadyGameButt = new MenuButton(new Rectangle(50, 890, 64, 64), ArtFetcher.Readygamebutt);

        ///On the lose screen and needs to return to the main menu
        private MenuButton LostGameButt = new MenuButton(new Rectangle(300, 100, 300, 200), ArtFetcher.Lostgamebutt);
        ///On the win screen and needs to return to the main menu
        private MenuButton WinGameButt = new MenuButton(new Rectangle(300, 100, 300, 200), ArtFetcher.Wingamebutt);


        ///This is a pop up screen that says your game is paused, just text
        private MenuButton GameIsPaused = new MenuButton(new Rectangle(250, 100, 200, 200), ArtFetcher.Gameispaused);

        //This the starry background
        private MenuButton PlayBackground = new MenuButton(new Rectangle(0, 0, 1500, 1000), ArtFetcher.Playbackground);


        private MenuButton BuildButt = new MenuButton(new Rectangle(1150, 900, 40, 40), ArtFetcher.Buildicon);
        /// <summary>
        /// If you press the build button you can choose to build a factory, a refinery, a minion, or a ship.
        /// </summary>
        private MenuButton BuildFactButt = new MenuButton(new Rectangle(1150, 850, 40, 40), ArtFetcher.Buildfacticon);
        private MenuButton BuildRefButt = new MenuButton(new Rectangle(1150, 800, 40, 40), ArtFetcher.Buildreficon);

        private MenuButton BuildMinButt = new MenuButton(new Rectangle(1150, 750, 40, 40), ArtFetcher.Buildminicon);
        //There are two types of minions. Normal and Better
        private MenuButton BuildNormMinButt = new MenuButton(new Rectangle(1150, 700, 40, 40), ArtFetcher.Buildnormminicon);
        private MenuButton BuildBettMinButt = new MenuButton(new Rectangle(1150, 650, 40, 40), ArtFetcher.Buildbettminicon);

        private MenuButton BuildMinerButt = new MenuButton(new Rectangle(1100, 750, 40, 40), ArtFetcher.Minericon);
        //There are two types of miners. Normal and Better
        private MenuButton BuildNormMinerButt = new MenuButton(new Rectangle(1150, 700, 40, 40), ArtFetcher.Minernormicon);
        private MenuButton BuildBettMinerButt = new MenuButton(new Rectangle(1150, 650, 40, 40), ArtFetcher.Minerbetticon);

        private MenuButton RefineButt = new MenuButton(new Rectangle(1000, 900, 40, 40), ArtFetcher.Refineicon);
        //There are two type of refining. Steel and Fuel Rods
        private MenuButton RefineSteelButt = new MenuButton(new Rectangle(1000, 700, 40, 40), ArtFetcher.Refinesteelicon);
        private MenuButton RefineRodButt = new MenuButton(new Rectangle(1000, 650, 40, 40), ArtFetcher.Refinerodicon);

        //This is a new copy of me
        private MenuButton BuildShipButt = new MenuButton(new Rectangle(1150, 600, 40, 40), ArtFetcher.Buildshipicon);
        //This tells a minion to move a thing from one place to another
        private MenuButton MoveButt = new MenuButton(new Rectangle(1100, 900, 40, 40), ArtFetcher.Movethingicon);
        //This is the collection button for minions to take from sources
        private MenuButton CollectButt = new MenuButton(new Rectangle(1050, 900, 40, 40), ArtFetcher.Collectreturnicon);

       


        //TODO: Add the art asset for the menu screen that has the game name  KIRA IS DOING THIS


        private bool AmIListening = false;
        private Point MouseDownPosition;
        private MouseState mouseState;


        private Game1 game;

        public MenuController(Game1 game)
        {
            this.game = game;
            game.IsMouseVisible = true;
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();



            //You start the game on the Menu Screen and press the start button in order to begin. When you press the start button you move to the Play Screen.
            if (CurrentScreen == Screen.Menu)
            {
                if (AmIListening)
                {
                    if (mouseState.LeftButton == ButtonState.Released)
                    {
                        AmIListening = false;
                        if (StartGameButt.ButtonSize.Contains(MouseDownPosition) && StartGameButt.ButtonSize.Contains(mouseState.Position))
                        {
                            SoundFetcher.Startgame.Play();
                            currentScreen = Screen.Play;
                        }
                    }
                }
                else
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        AmIListening = true;
                        MouseDownPosition = new Point(mouseState.Position.X, mouseState.Position.Y);
                    }
                }
            }


            //While playing the game you have the option to Pause the game. 
            //You also have the option to proceed to the next level. This connects to the menu screen. 
            //TODO: Make the Ready Game Button start a new map.
            else if (CurrentScreen == Screen.Play)
            {
                if (AmIListening)
                {
                    if (mouseState.LeftButton == ButtonState.Released)
                    {
                        AmIListening = false;
                        ///Code for the Pause/Play Buttons
                        if (IsPaused)
                        {
                            if (PlayGameButt.ButtonSize.Contains(MouseDownPosition) && PlayGameButt.ButtonSize.Contains(mouseState.Position))
                            {
                                IsPaused = false;
                            }
                        }
                        else
                        {
                            if (PauseGameButt.ButtonSize.Contains(MouseDownPosition) && PauseGameButt.ButtonSize.Contains(mouseState.Position))
                            {
                                //TODO: This should pause the game instead of restarting it.
                                IsPaused = true;
                                SoundFetcher.Pause.Play();

                            }
                        }
                        ///Code for the ready to proceed to next level buttons
                        if (ReadyGameButt.ButtonSize.Contains(MouseDownPosition) && ReadyGameButt.ButtonSize.Contains(mouseState.Position))
                        {
                            //TODO: This should start a new map at a new level
                            SoundFetcher.Fuellow.Play();

                            //TODO: These features are just a place holder and should be tied to actually losing the game.
                            currentScreen = Screen.Lose;
                            SoundFetcher.Dead.Play();
                        }
    
                        ///Code for I want to Build Shit buttons
                        if (IsBuildOn)
                        {
                            if (BuildMinButt.ButtonSize.Contains(MouseDownPosition) && BuildMinButt.ButtonSize.Contains(mouseState.Position))
                            {
                                IsBuildMinionOn = true;
                            }
                            else if (BuildMinerButt.ButtonSize.Contains(MouseDownPosition) && BuildMinerButt.ButtonSize.Contains(mouseState.Position))
                            {
                                IsBuildMinerOn = true;
                            }

                        }
                        else
                        {
                            if (BuildButt.ButtonSize.Contains(MouseDownPosition) && BuildButt.ButtonSize.Contains(mouseState.Position))
                            {
                                SoundFetcher.Theme.Play();
                                IsBuildOn = true;
                            }

                        }

                        ///Code for the I want to gather shit buttons
                        if (CollectButt.ButtonSize.Contains(MouseDownPosition) && CollectButt.ButtonSize.Contains(mouseState.Position))
                        {
                            SoundFetcher.Theme.Play();
                        }

                        ///Code for the I want to make fuel rods or steel buttons
                        if (RefineButt.ButtonSize.Contains(MouseDownPosition) && RefineButt.ButtonSize.Contains(mouseState.Position))
                        {
                            IsRefineOn = true;
                        }

                    }
                }
                else
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        AmIListening = true;
                        MouseDownPosition = new Point(mouseState.Position.X, mouseState.Position.Y);
                    }
                }
            }


            //If you lose the game there will be a button which indicates you lost the game. When you click the button it takes you back to the Menu Screen.
            else if (CurrentScreen == Screen.Lose)
            {
                if (AmIListening)
                {
                    if (mouseState.LeftButton == ButtonState.Released)
                    {
                        AmIListening = false;
                        if (LostGameButt.ButtonSize.Contains(MouseDownPosition) && LostGameButt.ButtonSize.Contains(mouseState.Position))
                        {
                            currentScreen = Screen.Menu;
                            SoundFetcher.Theme.Play();

                        }
                    }
                }
                else
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        AmIListening = true;
                        MouseDownPosition = new Point(mouseState.Position.X, mouseState.Position.Y);
                    }
                }
            }

            //The win screen is meant to show up when you've beaten the entire game. 
            else if (CurrentScreen == Screen.Win)
            {
                if (AmIListening)
                {
                    if (mouseState.LeftButton == ButtonState.Released)
                    {
                        AmIListening = false;
                        if (LostGameButt.ButtonSize.Contains(MouseDownPosition) && LostGameButt.ButtonSize.Contains(mouseState.Position))
                        {
                            currentScreen = Screen.Menu;
                        }
                    }
                }
                else
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        AmIListening = true;
                        MouseDownPosition = new Point(mouseState.Position.X, mouseState.Position.Y);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice GraphicsDevice = game.GraphicsDevice;
            ContentManager Content = game.Content;


            if (currentScreen == Screen.Menu)
            {
                GraphicsDevice.Clear(Color.White);
                IsPaused = false;
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Playbackground, PlayBackground.ButtonSize, Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Startgamebutt, StartGameButt.ButtonSize, Color.White);
            }

            else if (currentScreen == Screen.Play)
            {
                GraphicsDevice.Clear(Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Playbackground, PlayBackground.ButtonSize, Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Pausegamebutt, PauseGameButt.ButtonSize, Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Readygamebutt, ReadyGameButt.ButtonSize, Color.White);
                ///Icon Art
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Refineicon, RefineButt.ButtonSize, Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Buildicon, BuildButt.ButtonSize, Color.White);
                if (IsBuildOn)
                {
                    ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Buildfacticon, BuildFactButt.ButtonSize, Color.White);
                    ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Buildreficon, BuildRefButt.ButtonSize, Color.White);
                    ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Buildminicon, BuildMinButt.ButtonSize, Color.White);
                    ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Minericon, BuildMinerButt.ButtonSize, Color.White);
                    ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Buildshipicon, BuildShipButt.ButtonSize, Color.White);

                    if (IsBuildMinerOn)
                    {
                        ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Minernormicon, BuildNormMinerButt.ButtonSize, Color.White);
                        ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Minerbetticon, BuildBettMinerButt.ButtonSize, Color.White);
                    }
                    else if (IsBuildMinionOn)
                    {
                        ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Buildnormminicon, BuildNormMinButt.ButtonSize, Color.White);
                        ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Buildbettminicon, BuildBettMinButt.ButtonSize, Color.White);
                    }
                   
                }
                if (IsRefineOn)
                {
                        ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Refinesteelicon, RefineSteelButt.ButtonSize, Color.White);
                        ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Refinerodicon, RefineRodButt.ButtonSize, Color.White);
                }

                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Movethingicon, MoveButt.ButtonSize, Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Collectreturnicon, CollectButt.ButtonSize, Color.White);


                if (IsPaused)
                {
                    ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Gameispaused, GameIsPaused.ButtonSize, Color.White);
                    ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Playgamebutt, PlayGameButt.ButtonSize, Color.White);
                }
            }

            else if (currentScreen == Screen.Lose)
            {
                GraphicsDevice.Clear(Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Playbackground, PlayBackground.ButtonSize, Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Lostgamebutt, LostGameButt.ButtonSize, Color.White);
            }

            else if (CurrentScreen == Screen.Win)
            {
                GraphicsDevice.Clear(Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Playbackground, PlayBackground.ButtonSize, Color.White);
                ArtFetcher.Initialize(Content); spriteBatch.Draw(ArtFetcher.Wingamebutt, WinGameButt.ButtonSize, Color.White);

            }
        }
    }
}
