using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spartahack_2019
{
    public static class Globals
    {
        public static readonly Point SPR_DIMS = new Point(16, 16);
        public static readonly Point DEFAULT_WINDOW_SIZE = new Point(800, 800);
        public static readonly Point TILE_DIMS = new Point(10, 10);
    }

    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D render;

        Texture2D sprSheet;
        Rectangle renderDims;

        Level level;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = Globals.DEFAULT_WINDOW_SIZE.X;
            graphics.PreferredBackBufferHeight = Globals.DEFAULT_WINDOW_SIZE.Y;
        }
        
        protected override void Initialize()
        {
            renderDims = Rectangle.Empty;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            render = new RenderTarget2D(GraphicsDevice, Globals.SPR_DIMS.X * Globals.TILE_DIMS.X, Globals.SPR_DIMS.Y * Globals.TILE_DIMS.Y);

            sprSheet = Content.Load<Texture2D>("spritesheet2");
            level = new Level(sprSheet);
        }

        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (graphics.PreferredBackBufferWidth > graphics.PreferredBackBufferHeight)
                renderDims = new Rectangle(graphics.PreferredBackBufferWidth / 2 - graphics.PreferredBackBufferHeight / 2, 0, graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferHeight);
            else if (graphics.PreferredBackBufferHeight > graphics.PreferredBackBufferWidth)
                renderDims = new Rectangle(0, graphics.PreferredBackBufferHeight / 2 - graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferWidth);
            else
                renderDims = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            level.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(render);
            GraphicsDevice.Clear(Color.Black);

            level.Draw(GraphicsDevice, spriteBatch, render);

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw((Texture2D)render, renderDims, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
