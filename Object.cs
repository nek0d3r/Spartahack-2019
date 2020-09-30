using System;
using Microsoft.Xna.Framework;

namespace Spartahack_2019
{
    public class Object
    {
        protected Rectangle bounds;
        protected Rectangle skinBounds;

        public Object(Rectangle boundingBox, bool floor = true)
        {
            bounds = boundingBox;
            skinBounds = bounds;
            if (floor)
                skinBounds.Size = new Point((int)Math.Floor((double)bounds.Width / (double)Globals.SPR_DIMS.X), (int)Math.Floor((double)bounds.Height / (double)Globals.SPR_DIMS.Y));
            else
                skinBounds.Size = new Point((int)Math.Ceiling((double)bounds.Width / (double)Globals.SPR_DIMS.X), (int)Math.Ceiling((double)bounds.Height / (double)Globals.SPR_DIMS.Y));
        }

        public Object(Rectangle boundingBox, Point skinBox)
        {
            bounds = boundingBox;
            skinBounds = new Rectangle(boundingBox.Location, new Point(skinBox.X * Globals.SPR_DIMS.X, skinBox.Y * Globals.SPR_DIMS.Y));
        }

        public Rectangle Bounds
        {
            get { return bounds; }
            set { skinBounds.X += value.X - bounds.X; skinBounds.Y += value.Y - bounds.Y; bounds = value; }
        }

        public Rectangle SourceBounds
        {
            get { return skinBounds; }
            set { skinBounds = value; }
        }
    }
}
