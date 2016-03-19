using System;

namespace Shapes
{
    public class Triangle : Shape
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (_sideA < 0 || _sideB<0 ||_sideC<0)
                throw new ArgumentOutOfRangeException("Side can't be < 0");
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }

        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public override double Area()
        {
            double semiPer = Perimeter()/2.0;
            return Math.Sqrt(semiPer*(semiPer-_sideA)*(semiPer-_sideB)*(semiPer-_sideC));
        }

        public override double Perimeter()
        {
            return _sideA+_sideB+_sideC;
        }
    }
}
