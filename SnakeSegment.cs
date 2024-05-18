using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeSegment
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SnakeSegment(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
