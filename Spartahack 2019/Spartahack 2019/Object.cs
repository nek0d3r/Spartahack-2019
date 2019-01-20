using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SkinMatrix = System.Collections.Generic.List<System.Collections.Generic.List<Spartahack_2019.Skin>>;

namespace Spartahack_2019
{
    public class Object
    {
        protected Rectangle bounds;
        private Rectangle skinBounds;
        private Skin skin;

        public Object(Rectangle boundingBox, bool floor = true)
        {
            bounds = boundingBox;
            skinBounds = bounds;
            if (floor)
                skinBounds.Size = new Point((int)Math.Floor((double)bounds.Width / (double)Globals.SPR_DIMS.X), (int)Math.Floor((double)bounds.Height / (double)Globals.SPR_DIMS.Y));
            else
                skinBounds.Size = new Point((int)Math.Ceiling((double)bounds.Width / (double)Globals.SPR_DIMS.X), (int)Math.Ceiling((double)bounds.Height / (double)Globals.SPR_DIMS.Y));
            skin = new Skin();
        }

        public Object(Rectangle boundingBox, Point skinBox)
        {
            bounds = boundingBox;
            skinBounds = new Rectangle(boundingBox.Location, new Point(skinBox.X * Globals.SPR_DIMS.X, skinBox.Y * Globals.SPR_DIMS.Y));
            skin = new Skin();
        }

        public Rectangle Bounds
        {
            get { return bounds; }
            set { skinBounds.X += value.X - bounds.X; skinBounds.Y += value.Y - bounds.Y; bounds = value; }
        }

        public Skin Sprite
        {
            get { return skin; }
            set { skin = value; }
        }
    }
}
