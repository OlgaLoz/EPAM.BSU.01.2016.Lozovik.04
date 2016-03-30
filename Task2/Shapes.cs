using System;

namespace Task2
{
    public interface IShape 
    {
        double Area();
        double Perimetr();
    }

    public class Triangle : IShape
    {
        public double A { get; }

        public double B { get;}

        public double C { get;}

        public Triangle(double a, double c, double b) 
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Triangle sides must be positive!");
            }

            if (b + a <= c || b + c <= a || c + a <= b)
            {
                throw new ArgumentException("Triangle doesn't exist!"); 
            }

            A = a;
            B = b;
            C = c;
        }

        public double Area()
        {
            double p = Perimetr() / 2;
            return Math.Sqrt(p * (p - C) * (p - A) * (p - B));
        }

        public double Perimetr()
        {
            return C + A + B;
        }
    }

    public class Ellipse : IShape
    {
        public double Radius1 { get; }

        public double Radius2 { get; }

        public Ellipse(double radius1, double radius2)
        {
            if (radius1 <= 0 || radius2 <= 0)
            {
                throw new ArgumentException("Ellipse radius must be positive!");
            }

            Radius1 = radius1;
            Radius2 = radius2;
        }

        public double Area()
        {
            return Radius1 * Radius2 * Math.PI ;
        }

        public double Perimetr()
        {
            return 4 * (Math.PI * Radius1 * Radius2 + (Radius1 - Radius2)) / (Radius1 + Radius2);
        }
    }

    public class Rectangle : IShape
    {
        public double A { get; }

        public double B { get; }

        public Rectangle(double a, double b)  
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException("Rectangle sides must be positive!");
            }
            A = a;
            B = b;
        }

        public double Area()
        {
            return A * B;
        }

        public double Perimetr()
        {
            return 2 * (A + B);
        }
    }
}
