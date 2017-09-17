using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace ProbingUranus
{
	public static class ArtFetcher
	{
		///private static SpriteFont _font;
		///public static SpriteFont Font
		///{
		///	get { return _font; }
		///}

        ///These are buttons you can press in the game
		private static Texture2D _startgameButt;
		public static Texture2D Startgamebutt
        {
			get{ return _startgameButt; }
		}
        private static Texture2D _pausegameButt;
        public static Texture2D Pausegamebutt
        {
            get { return _pausegameButt; }
        }
        private static Texture2D _playgameButt;
        public static Texture2D Playgamebutt
        {
            get { return _playgameButt; }
        }
        private static Texture2D _readygameButt;
        public static Texture2D Readygamebutt
        {
            get { return _readygameButt; }
        }
        private static Texture2D _lostgameButt;
        public static Texture2D Lostgamebutt
        {
            get { return _lostgameButt; }
        }
        private static Texture2D _wingameButt;
        public static Texture2D Wingamebutt
        {
            get { return _wingameButt; }
        }

        /// <summary>
        /// This is a text block that lets you know the game is paused
        /// </summary>
        private static Texture2D _gameisPaused;
        public static Texture2D Gameispaused
        {
            get { return _gameisPaused; }
        }

        /// <summary>
        /// This is the starry background
        /// </summary>
        private static Texture2D _playBackground;
        public static Texture2D Playbackground
        {
            get { return _playBackground; }
        }

        /// <summary>
        /// This is the player creation items art
        /// </summary>
        private static Texture2D _playerArt;
        public static Texture2D Playerart
        {
            get { return _playerArt; }
        }
        private static Texture2D _minionArt;
        public static Texture2D Minionart
        {
            get { return _minionArt; }
        }
        private static Texture2D _staticfactoryArt;
        public static Texture2D Staticfactoryart
        {
            get { return _staticfactoryArt; }
        }
        private static Texture2D _staticrefineryArt;
        public static Texture2D Staticrefineryart
        {
            get { return _staticrefineryArt; }
        }
        private static Texture2D _minerArt;
        public static Texture2D Minerart
        {
            get { return _minerArt; }
        }

        /// <summary>
        /// This is the planetary art
        /// </summary>
        private static Texture2D _sunArt;
        public static Texture2D Sunart
        {
            get { return _sunArt; }
        }
        private static Texture2D _planet1Art;
        public static Texture2D Planet1art
        {
            get { return _planet1Art; }
        }
        private static Texture2D _planet2Art;
        public static Texture2D Planet2art
        {
            get { return _planet2Art; }
        }
        private static Texture2D _asteroid1Art;
        public static Texture2D Asteroid1art
        {
            get { return _asteroid1Art; }
        }
        private static Texture2D _asteroid2Art;
        public static Texture2D Asteroid2art
        {
            get { return _asteroid2Art; }
        }
        private static Texture2D _cometArt;
        public static Texture2D Cometart
        {
            get { return _cometArt; }
        }
        private static Texture2D _moon1Art;
        public static Texture2D Moon1art
        {
            get { return _moon1Art; }
        }
        private static Texture2D _moon2Art;
        public static Texture2D Moon2art
        {
            get { return _moon2Art; }
        }
        private static Texture2D _moon3Art;
        public static Texture2D Moon3art
        {
            get { return _moon3Art; }
        }

        /// <summary>
        /// This is the resource art
        /// </summary>
        private static Texture2D _fuelArt;
        public static Texture2D Fuelart
        {
            get { return _fuelArt; }
        }
        private static Texture2D _mineralsArt;
        public static Texture2D Mineralsart
        {
            get { return _mineralsArt; }
        }
        private static Texture2D _ironArt;
        public static Texture2D Ironart
        {
            get { return _ironArt; }
        }
        private static Texture2D _nuke1Art;
        public static Texture2D Nuke1art
        {
            get { return _nuke1Art; }
        }
        private static Texture2D _nuke2Art;
        public static Texture2D Nuke2art
        {
            get { return _nuke2Art; }
        }
        private static Texture2D _steelArt;
        public static Texture2D Steelart
        {
            get { return _steelArt; }
        }

        //Play Screen Menu Icon Art
        private static Texture2D _buildIcon;
        public static Texture2D Buildicon
        {
            get { return _buildIcon; }
        }
        private static Texture2D _buildfactoryIcon;
        public static Texture2D Buildfacticon
        {
            get { return _buildfactoryIcon; }
        }
        private static Texture2D _buildrefineryIcon;
        public static Texture2D Buildreficon
        {
            get { return _buildrefineryIcon; }
        }
        private static Texture2D _buildminionIcon;
        public static Texture2D Buildminicon
        {
            get { return _buildminionIcon; }
        }
        private static Texture2D _buildnormalminionIcon;
        public static Texture2D Buildnormminicon
        {
            get { return _buildnormalminionIcon; }
        }
        private static Texture2D _buildbetterminionIcon;
        public static Texture2D Buildbettminicon
        {
            get { return _buildbetterminionIcon; }
        }
        private static Texture2D _buildspaceshipIcon;
        public static Texture2D Buildshipicon
        {
            get { return _buildspaceshipIcon; }
        }
        private static Texture2D _movethingIcon;
        public static Texture2D Movethingicon
        {
            get { return _movethingIcon; }
        }
        private static Texture2D _collectreturnIcon;
        public static Texture2D Collectreturnicon
        {
            get { return _collectreturnIcon; }
        }

        private static Texture2D _minerIcon;
        public static Texture2D Minericon
        {
            get { return _minerIcon; }
        }
        private static Texture2D _minernormalIcon;
        public static Texture2D Minernormicon
        {
            get { return _minernormalIcon; }
        }
        private static Texture2D _minerbetterIcon;
        public static Texture2D Minerbetticon
        {
            get { return _minerbetterIcon; }
        }

        private static Texture2D _refineIcon;
        public static Texture2D Refineicon
        {
            get { return _refineIcon; }
        }
        private static Texture2D _refinesteelIcon;
        public static Texture2D Refinesteelicon
        {
            get { return _refinesteelIcon; }
        }
        private static Texture2D _refinerodIcon;
        public static Texture2D Refinerodicon
        {
            get { return _refinerodIcon; }
        }

       


        public static void Initialize(ContentManager Content){
            //correct art asset for buttons
			_startgameButt = Content.Load<Texture2D>("Start_Button");
            _playgameButt = Content.Load<Texture2D>("Play_Button");
            _readygameButt = Content.Load<Texture2D>("Explore");
            _pausegameButt = Content.Load<Texture2D>("Pause_Button");
                //TODO: add correct art assets for buttons
            _lostgameButt = Content.Load<Texture2D>("LostGameButt");
            _wingameButt = Content.Load<Texture2D>("WinGameButt");

            //TODO: add correct art assets for misc.
            _gameisPaused = Content.Load<Texture2D>("GameIsPaused");
            _playBackground = Content.Load<Texture2D>("PlayBackground");

                //TODO: add correct art assets for player creation items art
            _playerArt = Content.Load<Texture2D>("PlayerArt");
            _minionArt = Content.Load<Texture2D>("MinionArt");
            _staticfactoryArt = Content.Load<Texture2D>("StaticFactoryArt");
            _staticrefineryArt = Content.Load<Texture2D>("StaticRefineryArt");
            _minerArt = Content.Load<Texture2D>("MinerArt");

                //TODO: add correct art assets for planetary stuff
            _sunArt = Content.Load<Texture2D>("SunArt");
            //correct art assets for planetary stuff
            _planet1Art = Content.Load<Texture2D>("Planet1Art");
            _planet2Art = Content.Load<Texture2D>("Planet2");

            //These are the correct art assets for planetary stuff
            _asteroid1Art = Content.Load<Texture2D>("Asteroid");
            _asteroid2Art = Content.Load<Texture2D>("asteroid2");
            _cometArt = Content.Load<Texture2D>("Comet");

                //TODO: add correct art assets for planetary stuff
            _moon1Art = Content.Load<Texture2D>("Moon1");
            _moon2Art = Content.Load<Texture2D>("Moon2");
            _moon3Art = Content.Load<Texture2D>("Moon3");

                //TODO: add correct art assets for resources
            _fuelArt = Content.Load<Texture2D>("FuelArt");
            _mineralsArt = Content.Load<Texture2D>("MineralsArt");
            _ironArt = Content.Load<Texture2D>("IronArt");
            _nuke1Art = Content.Load<Texture2D>("Nuke1");
            _nuke2Art = Content.Load<Texture2D>("Nuke2");
            _steelArt = Content.Load<Texture2D>("SteelArt");

                //TODO: add correct art assets for play screen icons
            _buildIcon = Content.Load<Texture2D>("BuildArt");
            _buildfactoryIcon = Content.Load<Texture2D>("BuildFactArt");
            _buildrefineryIcon = Content.Load<Texture2D>("BuildRefArt");
            _buildminionIcon = Content.Load<Texture2D>("BuildMinArt");
            //There are two types of minions
            _buildnormalminionIcon = Content.Load<Texture2D>("BuildNormMinArt");
            _buildbetterminionIcon = Content.Load<Texture2D>("BuildBettMinArt");
            //This is a new copy of me
            _buildspaceshipIcon = Content.Load<Texture2D>("BuildShipArt");

            _movethingIcon = Content.Load<Texture2D>("MoveThingArt");
            _collectreturnIcon = Content.Load<Texture2D>("CollectReturnArt");

            _minerIcon = Content.Load<Texture2D>("BuildMinerArt");
            _minernormalIcon = Content.Load<Texture2D>("MinerNormArt");
            _minerbetterIcon = Content.Load<Texture2D>("MinerBettArt");


            _refineIcon = Content.Load<Texture2D>("RefineArt");
            _refinesteelIcon = Content.Load<Texture2D>("RefineSteelArt");
            _refinerodIcon = Content.Load<Texture2D>("RefineRodArt");


            ///_font = Content.Load<SpriteFont>("Arial");

            //TODO: load other art
        }

        //TODO: make art fetching functions here
    }
}