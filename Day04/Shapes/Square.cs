using System;

namespace Shapes
{
    public class Square : IShape
    {
        private double _side;

        public Square(double side)
        {
            if (side < 0)
                throw new ArgumentOutOfRangeException("Side can't be < 0");
            _side = side;
        }

        public double Side { get; }

        public double Area()
        {
            return _side*_side;
        }

        public double Perimeter()
        {
            return 4*_side;
        }
    }
}
