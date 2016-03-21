using System;
using NUnit.Framework;

namespace Task2.NUnit.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [TestCase(0, -14, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, 1, 2, ExpectedException = typeof(ArgumentException))]
        [TestCase(8, -10, 4, ExpectedException = typeof(ArgumentException))]
        [TestCase(2, 8, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, 1, 10, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, 115, 196, ExpectedException = typeof(ArgumentException))]
        public void TriangleConstructor_Test(double a, double b, double c)
        {
            new Triangle(a, b, c);
        }

        [TestCase(3, 4, 5, Result = 6)]
        public double TriangleArea_Test(double a, double b, double c)
        {
            return new Triangle(a, b, c).Area();
        }

        [TestCase(3, 5, 4, Result = 12)]
        public double TrianglePerimetr_Test(double a, double b, double c)
        {
            return new Triangle(a, b, c).Perimetr();
        }
    }

    [TestFixture]
    public class RectangleTests
    {
        [TestCase(0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(8, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(-2, 8, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, -1, ExpectedException = typeof(ArgumentException))]
        public void RactangleConstructor_Test(double a, double b)
        {
            new Rectangle(a, b);
        }

        [TestCase(3, 4, Result = 12)]
        public double RectangleArea_Test(double a, double b)
        {
            return new Rectangle(a, b).Area();
        }

        [TestCase(3, 4, Result = 14)]
        public double RectanglePerimetr_Test(double a, double b)
        {
            return new Rectangle(a, b).Perimetr();
        }
    }

    [TestFixture]
    public class EllipseTests
    {
        [TestCase(0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(8, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(-2, 8, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, -1, ExpectedException = typeof(ArgumentException))]
        public void EllipseConstructor_Test(double a, double b)
        {
            new Ellipse(a, b);
        }

        [TestCase(3, 4, Result = true)]
        public bool EllipseArea_Test(double a, double b)
        {
            double eps = 0.01;
            double expected = 37.699;
            double act = new Ellipse(a, b).Area();
            return Math.Abs(expected - act) < eps;

        }

        [TestCase(3, 4, Result = true)]
        public bool EllipsePerimetr_Test(double a, double b)
        {
            double eps = 0.01;
            double expected = 20.970;
            double act = new Ellipse(a, b).Perimetr();
            return Math.Abs(expected - act) < eps;
        }
    }
}
