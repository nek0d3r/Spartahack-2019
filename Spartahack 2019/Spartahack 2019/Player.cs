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
        float maxFrictionVelocity = 3.0f;
       

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
                direction.Y = -5;

            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            acceleration = accelRate * direction;
            velocity += acceleration * time;

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

            velocity += friction * time;

            bounds.Offset(velocity);


        }
    }
}
