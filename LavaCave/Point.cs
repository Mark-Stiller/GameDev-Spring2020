using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaCave
{
    class Point
    {
        //setting public to avoid coding set and get methods
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //add modifying coords
        public Point Add(Point other)
        {
            return new Point(this.x + other.x, this.y + other.y);
        }
    }
}
