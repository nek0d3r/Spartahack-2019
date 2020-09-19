using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Spartahack_2019
{
    public class Player : Object

    {
        KeyboardState state;
        KeyboardState prevState;
        public Vector2 acceleration;
        public Vector2 friction;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 direction = Vector2.Zero;
        float horizAccelRate = 25.0f;
        float maxVelocity = 3.0f;
        float frictionRate = 10.0f;
        float gravity = 0.0f;
        float maxGravity = 5.0f;
        float initialJumpVelocity = 500.0f;

        public Player(Rectangle boundingBox) : base(boundingBox)
        {
        }

        public void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            prevState = state;

            direction = Vector2.Zero;

            state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right))
                direction.X = 1;

            if (state.IsKeyDown(Keys.Left))
                direction.X = -1;

            if (state.IsKeyDown(Keys.Space) && prevState.IsKeyUp(Keys.Space))
            {
                direction.Y = -1;
                gravity = 15.0f;
            }

            acceleration.X = horizAccelRate * direction.X;
            velocity.X += acceleration.X * delta;
            velocity.Y += direction.Y * initialJumpVelocity * delta;

            if (velocity.X > 0)
                friction.X = -frictionRate;
            if (velocity.X < 0)
                friction.X = frictionRate;

            if (velocity.X > maxVelocity)
                velocity.X = maxVelocity;
            if (velocity.X < -maxVelocity)
                velocity.X = -maxVelocity;
            if (direction.Y >= -5)
                direction.Y = direction.Y+1;

            velocity.X += (Math.Abs(friction.X * delta) > Math.Abs(velocity.X)) ? -velocity.X : friction.X * delta;
            velocity.Y += gravity * delta;
            if (velocity.Y > maxGravity)
                velocity.Y = maxGravity;

            bounds.Offset(velocity);
            
            if (Bounds.Y > Globals.TILE_DIMS.Y * Globals.SPR_DIMS.Y - Bounds.Height)
            {
                Bounds = new Rectangle(Bounds.X, Globals.TILE_DIMS.Y * Globals.SPR_DIMS.Y - Bounds.Height, Bounds.Width, Bounds.Height);
            }
        }
    }
}
