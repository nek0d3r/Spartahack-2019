using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spartahack_2019
{
    public class Skin
    {
        private Rectangle source;

        public Skin()
        {
        }

        public Rectangle Source
        {
            get { return source; }
            set { source = value; }
        }
    }
}
