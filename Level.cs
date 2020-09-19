using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spartahack_2019
{
    public class Level
    {
        private Texture2D sprSheet;
        private Player player;
        private Object floor;

        public Level(Texture2D spriteSheet)
        {
            sprSheet = spriteSheet;

            player = new Player(new Rectangle(0, 0, Globals.SPR_DIMS.X, Globals.SPR_DIMS.Y));
            player.Sprite.Source = new Rectangle(new Point(0 * Globals.SPR_DIMS.X, 0 * Globals.SPR_DIMS.Y), Globals.SPR_DIMS);

            floor = new Object(new Rectangle(0, (Globals.TILE_DIMS.Y - 1) * Globals.SPR_DIMS.Y, Globals.SPR_DIMS.X * Globals.TILE_DIMS.X, Globals.SPR_DIMS.Y));
            floor.Sprite.Source = new Rectangle(new Point(1 * Globals.SPR_DIMS.X, 3 * Globals.SPR_DIMS.Y), Globals.SPR_DIMS);
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, RenderTarget2D render, SpriteFont font)
        {
            graphicsDevice.SetRenderTarget(render);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

            spriteBatch.Draw(sprSheet, floor.Bounds, floor.Sprite.Source, Color.White);
            spriteBatch.DrawString(font, "Velocity: " + player.velocity.ToString() + "\nAcceleration:" + player.acceleration.ToString() + "\nFriction" + player.friction.ToString() + "\nBounds" + player.Bounds.ToString() + "\n" + (player.Bounds.Y > Globals.TILE_DIMS.Y * Globals.SPR_DIMS.Y - player.Bounds.Height).ToString(), new Vector2(0, 1), Color.Red);

            spriteBatch.Draw(sprSheet, player.Bounds, player.Sprite.Source, Color.White);

            spriteBatch.End();
        }
    }
}
