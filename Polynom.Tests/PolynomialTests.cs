using NUnit.Framework;

namespace Polynom.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void Evaluate()
        {
            var polynom = new Polynomial(4, 0, 4, 6);
            Assert.AreEqual(68, polynom.Evaluate(2));
        }

        [Test]
        public void Add()
        {
            var polynom1 = new Polynomial(4, 0, 4, 6);
            var polynom2 = new Polynomial(4, 1, 4);
            var expected = new Polynomial(8, 1, 8, 6);
            Assert.AreEqual(expected, polynom1 + polynom2);
        }

        [Test]
        public void Subtract()
        {
            var polynom1 = new Polynomial(4, 0, 4, 6);
            var polynom2 = new Polynomial(4, 1, 4);
            var expected = new Polynomial(0, -1, 0, 6);
            Assert.AreEqual(expected, polynom1 - polynom2);
        }

        [Test]
        public void Multiply()
        {
            var polynom1 = new Polynomial(4, 2);
            var polynom2 = new Polynomial(6, 3);
            var expected = new Polynomial(24, 24, 6);
            Assert.AreEqual(expected, polynom1 * polynom2);
        }

        [Test]
        public void MultiplyByNumber()
        {
            var polynom1 = new Polynomial(4, 2, 1, 5);
            var expected = new Polynomial(8, 4, 2, 10);
            Assert.AreEqual(expected, polynom1 * 2);
        }

        [Test]
        public void Minus()
        {
            var polynom1 = new Polynomial(4, 2, -1, 5);
            var expected = new Polynomial(-4, -2, 1, -5);
            Assert.AreEqual(expected, -polynom1);
        }

        [Test]
        public void Degree()
        {
            var polynom1 = new Polynomial(4, 2, -1, 5);
            Assert.AreEqual(3, polynom1.Degree);
        }

        [Test]
        public void Coefs()
        {
            var polynom1 = new Polynomial(4, 2, -1, 5);
            var expected = new double[] { 4, 2, -1, 5 };
            Assert.AreEqual(expected, polynom1.Coefs);
        }

        [Test]
        public void CoefsZero()
        {
            var polynom1 = new Polynomial(4, 2, -1, 5, 0, 0);
            var expected = new double[] { 4, 2, -1, 5 };
            Assert.AreEqual(expected, polynom1.Coefs);
            Assert.AreEqual(3, polynom1.Degree);
        }

        [Test]
        public void StringRepresentation()
        {
            var polynom1 = new Polynomial(4, 2, -1, 5);
            string expected = "5*x^3 + -1*x^2 + 2*x^1 + 4";
            Assert.AreEqual(expected, polynom1.ToString());
        }
    }
}
