using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    public class Vektor
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vektor()
        {

        }

        public Vektor(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vektor operator +(Vektor v1, Vektor v2)
        {
            return new Vektor(v1.X + v2.X, v1.Y + v2.Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

    }
}
