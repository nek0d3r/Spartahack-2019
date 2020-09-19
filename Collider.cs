using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spartahack_2019
{
    public static class Collider
    {
        public static bool AABBTestCollision(Rectangle object1, Rectangle object2)
        {
            if (object1.Intersects(object2))
                return true;
            return false;
        }
    }
}
