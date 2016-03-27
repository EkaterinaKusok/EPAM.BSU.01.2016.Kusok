using System;

namespace Shapes
{
    public class Rectangle : IShape
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height)
        {
            if (width < 0)
                throw new ArgumentOutOfRangeException("Width can't be < 0");
            if (height < 0)
                throw new ArgumentOutOfRangeException("Height can't be < 0");
            _width = width;
            _height = height;
        }

        public double Width
        {
            get { return _width; }
            private set { _width = value; }
        }

        public double Height
        {
            get { return this._height; }
            private set { _height = value; }
        }

        public double Area()
        {
            return _width * _height;
        }

        public double Perimeter()
        {
            return 2 * (_width + _height);
        }
    }
}
