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
            player.SourceBounds = new Rectangle(new Point(0 * Globals.SPR_DIMS.X, 0 * Globals.SPR_DIMS.Y), Globals.SPR_DIMS);

            floor = new Object(new Rectangle(0, (Globals.TILE_DIMS.Y - 1) * Globals.SPR_DIMS.Y, Globals.SPR_DIMS.X * Globals.TILE_DIMS.X, Globals.SPR_DIMS.Y));
            floor.SourceBounds = new Rectangle(new Point(1 * Globals.SPR_DIMS.X, 3 * Globals.SPR_DIMS.Y), Globals.SPR_DIMS);
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, RenderTarget2D render, SpriteFont font)
        {
            graphicsDevice.SetRenderTarget(render);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

            spriteBatch.Draw(sprSheet, floor.Bounds, floor.SourceBounds, Color.White);
            spriteBatch.DrawString(
                font,$"{player.position}"
                /*$"Velocity: {player.velocity}\n" +
                    $"Acceleration: {player.acceleration}\n" +
                    $"Friction: {player.friction}\n" +
                    $"Bounds: {player.Bounds}\n" + 
                    $"{player.Bounds.Y > Globals.TILE_DIMS.Y * Globals.SPR_DIMS.Y - player.Bounds.Height}"*/,
                new Vector2(0, 1),
                Color.Red
            );

            spriteBatch.Draw(sprSheet, player.Bounds, player.SourceBounds, Color.White);

            spriteBatch.End();
        }
    }
}
