using System;
using Autofac;

namespace AutofacTest
{
    class Program
    {
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Shape>().As<IShape>();
            builder.RegisterType<Polygon>().As<IPolygon>().WithParameter(new TypedParameter(typeof(int), 10));
            builder.Register(c => new Color(50, 40, 120)).As<IColor>();

            var container = builder.Build();

            var triangle = container.Resolve<IPolygon>();

            Console.WriteLine(triangle);
        }
    }

    interface IShape
    {
        IColor Color { get; }

        double CalculatePerimeter();

        double CalculateArea();
    }

    interface IPolygon : IShape
    {
        int Sides { get; }

        int SideLength { get; }
    }

    interface IColor
    {
        byte Red { get; }

        byte Green { get; }

        byte Bule { get; }
    }

    class Color : IColor
    {
        public Color(byte red, byte green, byte bule)
        {
            this.Red = red;
            this.Green = green;
            this.Bule = bule;
        }

        public byte Red { get; }

        public byte Green { get; }

        public byte Bule { get; }

        public override string ToString()
        {
            return $"Color: Red [{this.Red}], Green [{this.Green}], Blue [{this.Bule}] ";
        }
    }

    abstract class Shape : IShape
    {
        protected Shape()
        {
        }

        protected Shape(IColor color)
        {
            this.Color = color;
        }

        public IColor Color { get; }

        public abstract double CalculatePerimeter();

        public abstract double CalculateArea();
    }

    class Polygon : Shape, IPolygon
    {
        public Polygon(int sides, int sideLength)
        {
            this.Sides = sides;
            this.SideLength = sideLength;
        }

        public Polygon(int sides, int sideLength, IColor color) : base(color)
        {
            this.Sides = sides;
            this.SideLength = sideLength;
        }

        public int Sides { get; }

        public int SideLength { get; }

        public override double CalculatePerimeter()
        {
            return this.Sides * this.SideLength;
        }

        public override double CalculateArea()
        {
            return 10;
        }

        public override string ToString()
        {
            return $"Poligon. Sides: {this.Sides}, SideLength: {this.Sides}, Color: {this.Color}";
        }
    }
}
