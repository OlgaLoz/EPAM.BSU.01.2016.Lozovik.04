using System;

namespace Task2
{
    public abstract class Shape 
    {
        public double A { get;}

        protected Shape(double a)
        {
            if (a <= 0)
            {
                throw new ArgumentException($"{nameof(a)} must be positive!");
            }
            A = a;
        }
        
        public abstract double Area();

        public abstract double Perimetr();
    }

    public class Triangle : Shape
    {
        public double B { get;}

        public double C { get;}

        public Triangle(double a, double c, double b) : base(a)
        {
            if (b <= 0)
            {
                throw new ArgumentException($"{nameof(b)} must be positive!");
            }

            if (c <= 0)
            {
                throw new ArgumentException($"{nameof(c)} must be positive!");
            }

            if (b + a <= c || b + c <= a || c + a <= b)
            {
                throw new ArgumentException("Triangle doesn't exist!"); 
            }

            B = b;
            C = c;
        }

        public override double Area()
        {
            double p = Perimetr() / 2;
            return Math.Sqrt(p * (p - C) * (p - A) * (p - B));
        }

        public override double Perimetr()
        {
            return C + A + B;
        }
    }

    public class Ellipse : Shape
    {
        public double B { get; }

        public Ellipse(double a, double b) : base(a)
        {
            if (b <= 0)
            {
                throw new ArgumentException($"{nameof(b)} must be positive!");
            }
            B = b;
        }

        public override double Area()
        {
            return A * B * Math.PI ;
        }

        public override double Perimetr()
        {
            return 4 * (Math.PI * A * B + (A - B)) / (A + B);
        }
    }

    public class Rectangle : Shape
    {
        public double B { get; }

        public Rectangle(double a, double b) : base(a)
        {
            if (b <= 0)
            {
                throw new ArgumentException("Length of the side can't be negative!");
            }
            B = b;
        }

        public override double Area()
        {
            return A * B;
        }

        public override double Perimetr()
        {
            return 2 * (A + B);
        }
    }
}
