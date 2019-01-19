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
        private Rectangle bounds;
        public Object()
            {
            }
        public Rectangle Bounds
        {
            get { return bounds; }
            set { Bounds = value; }
        }
    }
}
