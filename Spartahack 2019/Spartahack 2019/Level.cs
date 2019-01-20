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

        public Level(Texture2D spriteSheet)
        {
            sprSheet = spriteSheet;
            player = new Player();
            player.Bounds = new Rectangle(0, 0, Globals.SPR_DIMS.X, Globals.SPR_DIMS.Y);
            player.Sprite.Source = new Rectangle(new Point(0 * Globals.SPR_DIMS.X, 0 * Globals.SPR_DIMS.Y), Globals.SPR_DIMS);
            player.Sprite.SpriteSheet = spriteSheet;
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, RenderTarget2D render)
        {
            graphicsDevice.SetRenderTarget(render);
            spriteBatch.Begin();

            spriteBatch.Draw(sprSheet, player.Bounds, player.Sprite.Source, Color.White);

            spriteBatch.End();
        }
    }
}
