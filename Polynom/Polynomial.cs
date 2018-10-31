using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynom
{
    public sealed class Polynomial : IEquatable<Polynomial>
    {
        private readonly double[] _coefs;

        /// <summary>
        /// Initializes a new instance of <see cref="Polynomial"/>. 
        /// </summary>
        /// <param name="coefs">The coefficients of the polynomial in the order from the lowest to the highest degree (c0, c1, ... , cN).</param>
        public Polynomial(params double[] coefs)
        {
            if (coefs == null)
            {
                throw new ArgumentNullException(nameof(coefs));
            }

            if (coefs.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty", nameof(coefs));
            }

            for (int i = coefs.Length - 1; i > 0; i--)
            {
                if (Math.Abs(coefs[i]) > double.Epsilon)
                {
                    _coefs = coefs.Take(i + 1).ToArray();
                    break;
                }
            }

            if (_coefs == null)
            {
                _coefs = new[] { coefs[0] };
            }
        }

        public IReadOnlyList<double> Coefs => _coefs;

        public int Degree => _coefs.Length - 1;

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException(nameof(p1));
            }

            if (p2 == null)
            {
                throw new ArgumentNullException(nameof(p2));
            }

            int min = Math.Min(p1._coefs.Length, p2._coefs.Length);

            int max = Math.Max(p1._coefs.Length, p2._coefs.Length);

            double[] coefs = new double[max];

            for (int i = 0; i < max; i++)
            {
                if (i < min)
                {
                    coefs[i] = p1._coefs[i] + p2._coefs[i];
                }
                else
                {
                    coefs[i] = p1._coefs.Length > p2._coefs.Length ? p1._coefs[i] : p2._coefs[i];
                }
            }

            return new Polynomial(coefs);
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException(nameof(p1));
            }

            if (p2 == null)
            {
                throw new ArgumentNullException(nameof(p2));
            }

            int min = Math.Min(p1._coefs.Length, p2._coefs.Length);

            int max = Math.Max(p1._coefs.Length, p2._coefs.Length);

            double[] coefs = new double[max];

            for (int i = 0; i < max; i++)
            {
                if (i < min)
                {
                    coefs[i] = p1._coefs[i] - p2._coefs[i];
                }
                else
                {
                    coefs[i] = p1._coefs.Length > p2._coefs.Length ? p1._coefs[i] : -p2._coefs[i];
                }
            }

            return new Polynomial(coefs);
        }

        public static Polynomial operator -(Polynomial p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            double[] coefs = new double[p._coefs.Length];

            for (int i = 0; i < p._coefs.Length; i++)
            {
                coefs[i] = -p._coefs[i];
            }

            return new Polynomial(coefs);
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException(nameof(p1));
            }

            if (p2 == null)
            {
                throw new ArgumentNullException(nameof(p2));
            }

            double[] coefs = new double[p1._coefs.Length + p2._coefs.Length - 1];

            for (int i = 0; i < p1._coefs.Length; i++)
            {
                for (int j = 0; j < p2._coefs.Length; j++)
                {
                    coefs[i + j] += p1._coefs[i] * p2._coefs[j];
                }
            }

            return new Polynomial(coefs);
        }

        public static Polynomial operator *(Polynomial p, double c)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            double[] coefs = new double[p._coefs.Length];

            for (int i = 0; i < p._coefs.Length; i++)
            {
                coefs[i] = c * p._coefs[i];
            }

            return new Polynomial(coefs);
        }

        public static Polynomial operator *(double c, Polynomial p) => p * c;

        public static Polynomial Add(Polynomial p1, Polynomial p2) => p1 + p2;

        public static Polynomial Subtract(Polynomial p1, Polynomial p2) => p1 - p2;

        public static Polynomial Multiply(Polynomial p1, Polynomial p2) => p1 * p2;

        public static Polynomial Multiply(Polynomial p1, double c) => p1 * c;

        public static bool operator ==(Polynomial left, Polynomial right)
        {
            return object.Equals(left, right);
        }

        public static bool operator !=(Polynomial left, Polynomial right)
        {
            return !object.Equals(left, right);
        }

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _coefs.SequenceEqual(other._coefs);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Polynomial)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                foreach (var coef in _coefs)
                {
                    hashCode = (31 * hashCode) + coef.GetHashCode();
                }

                return hashCode;
            }
        }

       public override string ToString()
        {
            if (_coefs.Length == 1)
            {
                return _coefs[0].ToString();
            }

            StringBuilder builder = new StringBuilder();

            for (int i = _coefs.Length - 1; i > 0; i--)
            {
                if (Math.Abs(_coefs[i]) > double.Epsilon)
                {
                    builder.AppendFormat("{0}*x^{1} + ", _coefs[i], i);
                }
            }

            if (Math.Abs(_coefs[0]) < double.Epsilon)
            {
                builder.Remove(builder.Length - 3, 3);
            }
            else
            {
                builder.Append(_coefs[0]);
            }

            return builder.ToString();
        }

        public double Evaluate(double x)
        {
            double result = _coefs[0];

            for (int i = 1; i < _coefs.Length; i++)
            {
                result += _coefs[i] * Math.Pow(x, i);
            }

            return result;
        }
    }
}
