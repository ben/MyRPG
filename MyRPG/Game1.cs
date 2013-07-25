#region File Description
//-----------------------------------------------------------------------------
// MyRPGGame.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

#endregion

namespace MyRPG
{
	/// <summary>
	/// Default Project Template
	/// </summary>
	public class Game1 : Game
	{

	#region Fields
		GraphicsDeviceManager graphics;
	#endregion

	#region Initialization

        public Game1()  
        {

			graphics = new GraphicsDeviceManager(this);
			
			Content.RootDirectory = "Content";

			graphics.IsFullScreen = false;
		}

		/// <summary>
		/// Overridden from the base Game.Initialize. Once the GraphicsDevice is setup,
		/// we'll use the viewport to initialize some values.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();

			this.Components.Add (new AnimatedSpriteBase (this, "Characters/tokinoiori04", 32, 48, 1f / 8) { X=100, Y=100 });
		}


	#endregion

	#region Update and Draw

		/// <summary>
		/// This is called when the game should draw itself. 
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			// Clear the backbuffer
			this.GraphicsDevice.Clear (Color.Black);
			base.Draw(gameTime);
		}

	#endregion
	}
}
