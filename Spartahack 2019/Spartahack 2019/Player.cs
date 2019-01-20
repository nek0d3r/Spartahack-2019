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
        public Player(Rectangle boundingBox) : base(boundingBox)
        {
        }

        public void Update(GameTime gameTime)
        {
            Vector2 acceleration;
            Vector2 velocity = Vector2.Zero;
            Vector2 direction = Vector2.Zero;
            float accelRate = 100.0f;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
                direction = new Vector2(1, 0);

            if (state.IsKeyDown(Keys.Left))
                direction = new Vector2(-1, 0);

            if (state.IsKeyDown(Keys.Space))
                direction = new Vector2(1, -1);


            acceleration = direction * accelRate;
            velocity += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;

            bounds.Offset(velocity);


        }
    }
}
