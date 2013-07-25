using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace MyRPG
{
	public class AnimatedSpriteBase : DrawableGameComponent
	{
		int frameWidth;
		int frameHeight;
		int frameOffset = 0;
		string baseAssetName;

		int frameTime;
		int elapsedTime = 0;

		Texture2D tex;
		SpriteBatch spriteBatch;

		public int X { get; set; }
		public int Y { get; set; }
		public int VOffset { get; set; }

		public AnimatedSpriteBase (Game game, string baseAssetName, int frameWidth, int frameHeight, double frameTime)
			: base(game)
		{
			this.frameHeight = frameHeight;
			this.frameWidth = frameWidth;
			this.baseAssetName = baseAssetName;
			this.frameTime = (int)(1000 * frameTime);
		}

		protected override void LoadContent ()
		{
			tex = Game.Content.Load<Texture2D> (baseAssetName);
			spriteBatch = new SpriteBatch (Game.GraphicsDevice);
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);

			elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
			if (elapsedTime > frameTime) {
				elapsedTime = 0;
				frameOffset += frameWidth;
				if (frameOffset >= tex.Width)
					frameOffset = 0;
			}
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			spriteBatch.Begin (SpriteSortMode.Deferred, BlendState.AlphaBlend,
			                   SamplerState.PointClamp, DepthStencilState.None,
			                   RasterizerState.CullCounterClockwise);
			spriteBatch.Draw (tex, 
			                 new Rectangle (X, Y, frameWidth * 2, frameHeight * 2),
			                 new Rectangle (frameOffset, VOffset, frameWidth, frameHeight),
			                 Color.White);
			spriteBatch.End ();
		}
	}
}

