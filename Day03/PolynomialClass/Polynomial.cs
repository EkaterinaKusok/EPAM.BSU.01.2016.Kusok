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
            else if (coefficients[0].Equals(0) && coefficients.Length == 1)
                return "0";
            else
            {
                StringBuilder Expression = new StringBuilder();
                
                if(coefficients[0]!=0 && coefficients.Length!=1) Expression.Insert(0, coefficients[0]);

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

        public Polynomial Add(Polynomial rhs)
        {
            double[] result;
            if (this.coefficients == null || this.coefficients.Length == 0)
                result = rhs.coefficients;
            else if (rhs.coefficients == null || rhs.coefficients.Length == 0)
                result = this.coefficients;
            else
            {
                if (coefficients.Length >= rhs.coefficients.Length)
                {
                    result = coefficients;
                    for (int i = 0; i < rhs.coefficients.Length; i++)
                        result[i] += rhs.coefficients[i];
                }
                else
                {
                    result = rhs.coefficients;
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

        public Polynomial Multiply(Polynomial rhs)
        {
            double[] result;
            if (this.coefficients == null || rhs.coefficients == null)
                result = null;
            else if (coefficients.Length == 0 || rhs.coefficients.Length == 0)
                result = new double[0] {};
            else
            {
                result = new double[coefficients.Length + rhs.coefficients.Length-1];
                for (int i = 0; i < coefficients.Length; i++)
                    for (int j = 0; j < rhs.coefficients.Length; j++)
                        result[i + j] += coefficients[i]*rhs.coefficients[j];
            }
            return new Polynomial(result);
        }
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            return lhs.Multiply(rhs);
        }
        public static Polynomial operator *(Polynomial lhs, double rhs)
        {
            double[] result;
            if (lhs.coefficients == null)
                result = null;
            else if (lhs.coefficients.Length == 0)
                result = new double[0] { };
            else if (rhs.Equals(0.0))
                result=new double[1] {0};
            else
            {
                result = new double[lhs.coefficients.Length];
                for (int i = 0; i < lhs.coefficients.Length; i++)
                    result[i] = lhs.coefficients[i] * rhs;
            }
            return new Polynomial(result);
        }
        public static Polynomial operator *(double lhs, Polynomial rhs)
        {
            return rhs * lhs;
        }

        public Polynomial Substruct(Polynomial rhs)
        {
            double[] result;
            if (this.coefficients == null || this.coefficients.Length == 0)
                result = rhs.coefficients;
            else if (rhs.coefficients == null || rhs.coefficients.Length == 0)
                result = this.coefficients;
            else
            {
                if (coefficients.Length >= rhs.coefficients.Length)
                {
                    result = coefficients;
                    for (int i = 0; i < rhs.coefficients.Length; i++)
                        result[i] -= rhs.coefficients[i];
                }
                else
                {
                    result = rhs.coefficients;
                    for (int i = 0; i < coefficients.Length; i++)
                    {
                        result[i] = (-1)*result[i] + coefficients[i];
                    }
                    for (int i = coefficients.Length; i < rhs.coefficients.Length; i++)
                    {
                        result[i] *= (-1);
                    }
                }
            }
            return new Polynomial(result);
        }
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return lhs.Substruct(rhs);
        }
        public static Polynomial operator -(Polynomial lhs, double rhs)
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
                result[0] -= rhs;
            }
            return new Polynomial(result);
        }
        public static Polynomial operator -(double lhs, Polynomial rhs)
        {
            return (rhs - lhs)*(-1);
        }
    }
}
