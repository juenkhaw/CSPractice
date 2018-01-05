using System;

namespace ShapeDEMO
{
    public abstract class Shape
    {
        private string ID;
        public Shape(string s)
        {
            ID = s;
        }
        public string Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public virtual double Area
        {
            get;
        }
        public virtual double Perimeter
        {
            get;
        }
        public override string ToString()
        {
            return Id + "\nAREA = " + string.Format("{0:F2}", Area) + "\nPERIMETER = " + string.Format("{0:F2}", Perimeter);
        }
    }

    public class Square: Shape
    {
        private double side;
        public Square(string id, double side):base(id)
        {
            this.side = side;
        }
        public override double Area
        {
            get
            {
                return side * side;
            }
        }
        public override double Perimeter
        {
            get
            {
                return side * 4;
            }
        }
    }
    public class Rectangle:Shape
    {
        private double sideX, sideY;
        public Rectangle(string id, double sideX, double sideY):base(id)
        {
            this.sideX = sideX;
            this.sideY = sideY;
        }
        public override double Area
        {
            get
            {
                return sideX * sideY;
            }
        }
        public override double Perimeter
        {
            get
            {
                return sideX * 2 + sideY * 2;
            }
        }
    }
    public class Circle : Shape
    {
        private double radius;
        public Circle(string id, double radius) : base(id)
        {
            this.radius = radius;
        }
        public override double Area
        {
            get
            {
                return Math.PI * radius * radius;
            }
        }
        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }
    }
    public class Triangle : Shape
    {
        private double side1, side2, side3, gamma;
        public Triangle(string id, double side1, double side2, double side3, double gamma):base(id)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
            this.gamma = gamma;
        }
        public override double Area
        {
            get
            {
                return 0.5*side1*side2*Math.Sin(gamma);
            }
        }
        public override double Perimeter
        {
            get
            {
                return side1 + side2 + side3;
            }
        }

    }

    class DemoInheritance
    {
        public static void DemoInheritanceMain()
        {
            Shape[] shape = new Shape[]
                {
                new Square("SQUARE", 6),
                new Rectangle("RECTANGLE", 2, 9),
                new Circle("CIRCLE", 32),
                new Triangle("TRIANGLE <BETA>", 5,4,3, 65)
                };
            foreach (Shape s in shape)
            {
                Console.WriteLine(s);
            }
        }
    }
}
