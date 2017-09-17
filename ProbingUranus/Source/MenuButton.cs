using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProbingUranus
{
	public class MenuButton
	{
		private Rectangle buttonsize;
		public Rectangle ButtonSize 
		{
			get{ return buttonsize; }
			set{ buttonsize = value; }
		}

		public MenuButton(Rectangle buttonsize, Texture2D art)
		{
			this.buttonsize = buttonsize;
		}
	}
}

