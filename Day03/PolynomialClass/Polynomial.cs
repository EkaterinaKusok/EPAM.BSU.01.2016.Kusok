using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialClass
{
    public class Polynomial
    {
        private readonly double[] coefficients;
        //надо ли?
        public double[] Get()
        {
            return coefficients;
        }

        public Polynomial(params double[] _coefficients)
        {
            this.coefficients = _coefficients;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial))
                return false;
            else
                return this.coefficients == ((Polynomial)obj).coefficients;
        }

        public override string ToString()
        {
            if (coefficients.Length == 0 || coefficients == null)
                return "";
            else
            {
                StringBuilder Expression = new StringBuilder();
                if(coefficients[0]!=0 && coefficients.Length!=1)Expression.Insert(0, coefficients[0]);
                for (int i = 1; i < this.coefficients.Length; i++)
                {
                    if ( coefficients[i - 1] > 0)
                        Expression.Insert(0, '+'); //знак плюса перед членом
                    Expression.Insert(0, coefficients[i].ToString() + "*x^" + i.ToString());

                }
                return Expression.ToString();
            }
        }
        public override int GetHashCode()
        {
            return this.coefficients.GetHashCode();
        }

        //сложение
        public Polynomial Add(Polynomial right)
        {
            double[] result;
            if (this.coefficients == null || this.coefficients.Length == 0)
                result = right.coefficients;
            else if (right.coefficients == null || right.coefficients.Length == 0)
                result = this.coefficients;
            else
            {
                if (coefficients.Length >= right.coefficients.Length)
                {
                    result = coefficients;
                    for (int i = 0; i < right.coefficients.Length; i++)
                        result[i] += right.coefficients[i];
                }
                else
                {
                    result = right.coefficients;
                    for (int i = 0; i < coefficients.Length; i++)
                    {
                        result[i] += coefficients[i];
                    }
                }
            }
            return new Polynomial(result);
        }
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            return lhs.Add(rhs);
        }
        public static Polynomial operator +(Polynomial lhs, double rhs)
        {
            double[] result;
            if (lhs.coefficients == null || lhs.coefficients.Length == 0)
            {
                result = new double[1];
                result[0] = rhs;
            }
            else
            {
                result = lhs.coefficients;
                result[0] += rhs;
            }
            return new Polynomial(result);
        }
        public static Polynomial operator +(double lhs, Polynomial rhs)
        {
            return rhs + lhs;
        }

        // умножение
        public Polynomial Multiply(Polynomial right)
        {
            double[] result;
            if (this.coefficients == null || right.coefficients == null)
                result = null;
            else if (coefficients.Length == 0 || right.coefficients.Length == 0)
                result = new double[0] {};
            else
            {
                result = new double[coefficients.Length + right.coefficients.Length-1];
                for (int i = 0; i < coefficients.Length; i++)
                    for (int j = 0; j < right.coefficients.Length; j++)
                        result[i + j] += coefficients[i]*right.coefficients[j];
            }
            return new Polynomial(result);
        }
    }
}
