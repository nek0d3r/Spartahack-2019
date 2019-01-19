using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spartahack_2019
{
    public class Main : Game
    {
        readonly Point SPR_DIMS = new Point(16, 16);
        readonly Point DEFAULT_WINDOW_SIZE = new Point(800, 800);
        readonly Point TILE_DIMS = new Point(10, 10);

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D render;

        Texture2D sprSheet;
        Rectangle playerDims;
        Rectangle playerOrigin;
        Rectangle renderDims;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = DEFAULT_WINDOW_SIZE.X;
            graphics.PreferredBackBufferHeight = DEFAULT_WINDOW_SIZE.Y;
        }
        
        protected override void Initialize()
        {
            renderDims = Rectangle.Empty;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            render = new RenderTarget2D(GraphicsDevice, SPR_DIMS.X * TILE_DIMS.X, SPR_DIMS.Y * TILE_DIMS.Y);

            sprSheet = Content.Load<Texture2D>("spritesheet2");
            playerDims = new Rectangle(0, 0, SPR_DIMS.X, SPR_DIMS.Y);
            playerOrigin = new Rectangle(new Point(0 * SPR_DIMS.X, 0 * SPR_DIMS.Y), SPR_DIMS);
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

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(render);
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            spriteBatch.Draw(sprSheet, playerDims, playerOrigin, Color.White);

            spriteBatch.End();


            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw((Texture2D)render, renderDims, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
