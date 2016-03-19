using System;

namespace Shapes
{
    public class Square : Shape
    {
        private double _side;

        public Square(double side)
        {
            if (side < 0)
                throw new ArgumentOutOfRangeException("Side can't be < 0");
            _side = side;
        }

        public double Side { get; }

        public override double Area()
        {
            return _side*_side;
        }

        public override double Perimeter()
        {
            return 4*_side;
        }
    }
}
