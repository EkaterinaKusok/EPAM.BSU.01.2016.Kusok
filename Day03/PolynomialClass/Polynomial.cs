using System;
using System.Text;
using System.Configuration;

namespace PolynomialClass
{
    public sealed class Polynomial
    {
        private double[] _coefficients;
        private int _degree;
        private static double _epsilon;

        static Polynomial()
        {
            _epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);
        }

        public Polynomial(params double[] coefficients)
        {
            coefficients.CopyTo(this._coefficients, 0);
            _degree = this.Degree;
        }

        public Polynomial(Polynomial polynomial)
        {
            polynomial._coefficients.CopyTo(this._coefficients, 0);
            _degree = this.Degree;
        }

        public static double Epsilon
        {
            get { return _epsilon; }
            set { _epsilon = value; }
        }

        public int Degree
        {
            get
            {
                if (_coefficients.Length == 0)
                    return -1;
                if (_coefficients.Length == 1)
                    return 0;
                int i;
                for (i = _coefficients.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(_coefficients[i]) > _epsilon)
                        break;
                }
                return i;
            }
        }

        public double this[int number]
        {
            get
            {
                if (number >= 0 || number < _degree + 1) //проверить м.б. степень +-1
                    return _coefficients[number];
                throw new ArgumentOutOfRangeException();
            }

            private set
            {
                if (number >= 0 || number < _degree + 1)
                    this._coefficients[number] = value;
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (this._degree != other._degree)
                return false;

            for (var i = 0; i < this._degree + 1; i++)
            {
                if (!this._coefficients[i].Equals(other._coefficients[i]))
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            //if (ReferenceEquals(null, obj)) return false; // данная проверка уже есть в Equals(Polinomial)
            //if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Polynomial) obj);
        }

        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if (ReferenceEquals(lhs, null)) return false;
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString() // переписать
        {
            if (_degree == -1 || _coefficients == null)
                return "";
            if (_degree == 0)
                return _coefficients[0].ToString();
            StringBuilder Expression = new StringBuilder();
            Expression.Insert(0, ")");
            for (int i = 1; i < this._degree + 1; i++)
                Expression.Insert(0, _coefficients[i] + " ");
            Expression.Insert(0, "( ");
            return Expression.ToString();
            
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_coefficients != null ? _coefficients.GetHashCode() : 0)*397) ^ _degree;
            }
        }

        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException("lhs");
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException("rhs");
            if (lhs._coefficients.Length == 0 || rhs._coefficients.Length == 0)
                return new Polynomial(new double[0] {});
            int minDegree = Math.Min(lhs._degree, rhs._degree);
            var result = lhs._degree >= rhs._degree ? new Polynomial(lhs) : new Polynomial(rhs);
            for (int i = 0; i < minDegree; i++)
                result[i] += lhs._degree >= rhs._degree ? rhs[i] : lhs[i];
            return new Polynomial(result);
        }

        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            return Add(lhs, rhs);
        }

        public static Polynomial operator +(Polynomial lhs, double rhs)
        {
            return Add(lhs, new Polynomial(rhs));
        }

        public static Polynomial operator +(double lhs, Polynomial rhs)
        {
            return Add(new Polynomial(lhs), rhs);
        }

        public static Polynomial Substruct(Polynomial lhs, Polynomial rhs)
        {
            return Add(lhs, -rhs);
        }

        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return Substruct(lhs, rhs);
        }

        public static Polynomial operator -(Polynomial lhs, double rhs)
        {
            return Substruct(lhs, new Polynomial(rhs));
        }

        public static Polynomial operator -(double lhs, Polynomial rhs)
        {
            return Substruct(new Polynomial(lhs), rhs);
        }

        public static Polynomial operator -(Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null)) throw new ArgumentNullException("polynomial is null");
            double[] result = new double[polynomial._degree + 1];
            for (int i = 0; i < polynomial._degree + 1; i++)
                result[i] = (-1)*polynomial._coefficients[i];
            return new Polynomial(result);
        }

        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException("lhs");
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException("rhs");

            if (lhs._coefficients.Length == 0 || rhs._coefficients.Length == 0)
                return new Polynomial(new double[0] {});
            double[] result = new double[lhs._degree + rhs._degree - 1];
            for (int i = 0; i < lhs._degree; i++)
                for (int j = 0; j < rhs._degree; j++)
                    result[i + j] += lhs._coefficients[i]*rhs._coefficients[j];
            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            return Multiply(lhs, rhs);
        }

        public static Polynomial operator *(Polynomial lhs, double rhs)
        {
            return Multiply(lhs, new Polynomial(rhs));
        }

        public static Polynomial operator *(double lhs, Polynomial rhs)
        {
            return Multiply(new Polynomial(lhs), rhs);
        }
    }
}
