using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Spartahack_2019
{
    public static class Globals
    {
        public static readonly Point SPR_DIMS = new Point(16, 16);                                  // Set sprite/tile size
        public static readonly Point TILE_DIMS = new Point(30, 30);                                 // Render size in tiles
        public static Point DEFAULT_WINDOW_SIZE = new Point(800, 800);                              // Size of buffer
        public static Rectangle renderDims = new Rectangle(Point.Zero, DEFAULT_WINDOW_SIZE);        // How to apply render to buffer
    }

    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D render;

        Song theme;
        Texture2D sprSheet;
        SpriteFont debug;

        Level level;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;

            // Set buffer size to default
            graphics.PreferredBackBufferWidth = Globals.DEFAULT_WINDOW_SIZE.X;
            graphics.PreferredBackBufferHeight = Globals.DEFAULT_WINDOW_SIZE.Y;

            // Allow user to resize window, add event handler
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += WindowChanged;
        }


        /***
         * Thrown on resizing the window.
         * Attempts to fill the buffer while maintaining aspect ratio.
         * TODO: Handling window maximizing. Currently the last buffer dimensions are stretched to fit the window, but doesn't update to fill or fit properly.
         */
        public void WindowChanged(object sender, EventArgs e)
        {
            // Update buffer bounds
            Globals.DEFAULT_WINDOW_SIZE.X = graphics.PreferredBackBufferWidth;
            Globals.DEFAULT_WINDOW_SIZE.Y = graphics.PreferredBackBufferHeight;

            // If width is greater, fill to height
            if (Globals.DEFAULT_WINDOW_SIZE.X > Globals.DEFAULT_WINDOW_SIZE.Y)
                Globals.renderDims = new Rectangle(Globals.DEFAULT_WINDOW_SIZE.X / 2 - Globals.DEFAULT_WINDOW_SIZE.Y / 2, 0, Globals.DEFAULT_WINDOW_SIZE.Y, Globals.DEFAULT_WINDOW_SIZE.Y);
            // If height is greater, fill to width
            else if (Globals.DEFAULT_WINDOW_SIZE.Y > Globals.DEFAULT_WINDOW_SIZE.X)
                Globals.renderDims = new Rectangle(0, Globals.DEFAULT_WINDOW_SIZE.Y / 2 - Globals.DEFAULT_WINDOW_SIZE.X / 2, Globals.DEFAULT_WINDOW_SIZE.X, Globals.DEFAULT_WINDOW_SIZE.X);
            // Buffer is square, fill to bounds
            else
                Globals.renderDims = new Rectangle(0, 0, Globals.DEFAULT_WINDOW_SIZE.X, Globals.DEFAULT_WINDOW_SIZE.Y);
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            render = new RenderTarget2D(GraphicsDevice, Globals.SPR_DIMS.X * Globals.TILE_DIMS.X, Globals.SPR_DIMS.Y * Globals.TILE_DIMS.Y);

            theme = Content.Load<Song>("theme");
            sprSheet = Content.Load<Texture2D>("spritesheet2");
            debug = Content.Load<SpriteFont>("debug");
            level = new Level(sprSheet);
            MediaPlayer.Play(theme);
            MediaPlayer.IsRepeating = true;
        }

        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            level.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(render);
            GraphicsDevice.Clear(Color.Black);

            level.Draw(GraphicsDevice, spriteBatch, render, debug);

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw((Texture2D)render, Globals.renderDims, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
