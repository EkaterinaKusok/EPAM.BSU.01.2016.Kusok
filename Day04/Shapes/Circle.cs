using System;

namespace Shapes
{
    public class Circle : IShape
    {
        private double _radius;

        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException("Radius can't be < 0");
            _radius = radius;
        }

        public double Radius { get;}

        public double Area()
        {
            return 3.14159265359 * _radius * _radius;
        }

        public double Perimeter()
        {
            return 2 * 3.14159265359 * _radius;
        }
    }
}
