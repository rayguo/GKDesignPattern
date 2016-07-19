using System;
using System.Collections.Generic;
using System.Text;

namespace LogoLib
{
    public struct Location
    {
        public Location(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Location Add(float offsetX, float offsetY)
        {
            return new Location(X + offsetX, Y + offsetY);
        }

        private float x;

        public float X
        {
            get { return x; }
            private set { x = value; }
        }

        private float y;

        public float Y
        {
            get { return y; }
            private set { y = value; }
        }


    }
}
