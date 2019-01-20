using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Spartahack_2019
{
    public class Player : Object

    {
        public Vector2 acceleration;
        public Vector2 friction;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 direction = Vector2.Zero;
        float accelRate = 50.0f;
        float maxVelocity = 3.0f;
        float frictionRate = 10.0f;
        float gravity = 0.0f;
        float initialJumpVelocity = 100.0f;

        public Player(Rectangle boundingBox) : base(boundingBox)
        {
        }

        public void Update(GameTime gameTime)
        {
            direction = Vector2.Zero;

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right))
                direction.X = 1;

            if (state.IsKeyDown(Keys.Left))
                direction.X = -1;

            if (state.IsKeyDown(Keys.Space))
            {
                direction.Y = -1;
                gravity = 15.0f;
            }

            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            acceleration.X = accelRate * direction.X;
            velocity.X += acceleration.X * time;
            velocity.Y += direction.Y * initialJumpVelocity * time;

            if (velocity.X > 0)
                friction.X = -frictionRate;
            if (velocity.X < 0)
                friction.X = frictionRate;

            if (velocity.X > maxVelocity)
                velocity.X = maxVelocity;
            if (velocity.X < -maxVelocity)
                velocity.X = -maxVelocity;

            velocity.X += friction.X * time;
            velocity.Y += gravity * time;

            bounds.Offset(velocity);


        }
    }
}
