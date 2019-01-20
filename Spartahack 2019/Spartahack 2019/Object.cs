using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spartahack_2019
{
    public class Object
    {
        protected Rectangle bounds;
        private Skin skin;

        public Object()
        {
            skin = new Skin();
        }

        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public Skin Sprite
        {
            get { return skin; }
            set { skin = value; }
        }
    }
}
