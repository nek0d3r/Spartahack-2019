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
        public Vector2 velocity = Vector2.Zero;
        public Vector2 direction;
        float accelRate = 0.2f;

        public Player(Rectangle boundingBox) : base(boundingBox)
        {
        }

        public void Update(GameTime gameTime)
        {
            direction = Vector2.Zero;

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right))
                direction = new Vector2(2, 0);

            if (state.IsKeyDown(Keys.Left))
                direction = new Vector2(-2, 0);

            if (state.IsKeyDown(Keys.Space))
                direction = new Vector2(0, -5);

            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            acceleration = accelRate * direction;
            velocity += acceleration * time;

            bounds.Offset(velocity);


        }
    }
}
