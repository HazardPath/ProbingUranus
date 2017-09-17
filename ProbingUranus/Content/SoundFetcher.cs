using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace ProbingUranus
{
	public static class SoundFetcher
	{
		///Build Completion Sounds
        private static SoundEffect _buildDone;
        public static SoundEffect Builddone
        {
            get { return _buildDone; }
        }

        ///Not Enough Fuel Sound
        private static SoundEffect _fuelLow;
        public static SoundEffect Fuellow
        {
            get { return _fuelLow; }
        }

        ///Resource Node Depleted sound
        private static SoundEffect _nodeDone;
        public static SoundEffect Nodedone
        {
            get { return _nodeDone; }
        }

        ///Minion movement sound
        private static SoundEffect _minMove;
        public static SoundEffect Minmove
        {
            get { return _minMove; }
        }

        ///Player Character Movement sound
        private static SoundEffect _meMove;
        public static SoundEffect Memove
        {
            get { return _meMove; }
        }

        ///Start Game Button sound "Ok bend over"
        private static SoundEffect _startGame;
        public static SoundEffect Startgame
        {
            get { return _startGame; }
        }

        private static SoundEffect _pause;
        public static SoundEffect Pause
        {
            get { return _pause; }
        }

        private static SoundEffect _dead;
        public static SoundEffect Dead
        {
            get { return _dead; }
        }

        private static SoundEffect _theme;
        public static SoundEffect Theme
        {
            get { return _theme; }
        }

        public static void Initialize(ContentManager Content){
            //_buildDone = Content.Load<SoundEffect>("BuildDone");
            _fuelLow = Content.Load<SoundEffect>("FuelIsLow");
            //_nodeDone = Content.Load<SoundEffect>("NodeEmpty");
            //_minMove = Content.Load<SoundEffect>("MinionMove");
            //_meMove = Content.Load<SoundEffect>("PlayerMove");
            _startGame = Content.Load<SoundEffect>("StartGame");
            _pause = Content.Load<SoundEffect>("Pause");
            _dead = Content.Load<SoundEffect>("Dead");
            _theme = Content.Load<SoundEffect>("OpeningMusic");
        }
	}
}