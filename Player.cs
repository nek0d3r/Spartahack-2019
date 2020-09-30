using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Spartahack_2019
{
    public class Player : Object

    {
        public Vector2 velocity;
        public Vector2 position;
        KeyboardState state;
        KeyboardState prevState;
        Vector2 gravity = new Vector2(0.0f, 800f);
        float maxVelocity = 800.0f;
        float delta;

        public Player(Rectangle boundingBox) : base(boundingBox)
        {
        }

        public void Update(GameTime gameTime)
        {
            // Get the amount of time since the last frame was drawn
            delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

            // Update state of controls
            prevState = state;
            state = Keyboard.GetState();

            // Velocity affected by gravity over time
            velocity += gravity * delta;
            
            // Clamp terminal velocity to given threshold
            var terminalClamp = Math.Sqrt(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2));
            if(terminalClamp > maxVelocity)
            {
                velocity *= (float) (maxVelocity / terminalClamp);
            }
            
            // Update position with velocity over time
            position += velocity * delta;

            // Update buffer with player position
            bounds.Location = position.ToPoint();
        }
    }
}
