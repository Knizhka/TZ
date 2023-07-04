using System;

namespace TZ_4
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class Figure
    {
        public abstract double getPerimeter();
        public abstract double getSquare();
        public abstract bool   isValid();
    }

    // Ромб
    class Rhombus : Figure
    {
        protected int width = 0, height = 0;
        protected double angle = 0;

        public Rhombus(int width, int height, double angle)
        {
            this.width  = width;
            this.height = height;
            this.angle  = angle;
        }

        // Площадь
        public override double getSquare()
        {
            return isValid() ? (width * height)*Math.Sin(angle*Math.PI/180) : 0; // Площадь ромба(для квадрата и прямоугольника тоже подходит) Произведение ширины на длинну и синус угла в радианах
        }

        // Периметр
        public override double getPerimeter()
        {
            return isValid() ? ((width + height) * 2) : 0;
        }

        // Валидация
        public override bool isValid()
        {
            if (width < 0 || height < 0 || angle < 0 || angle >= 180)
            {
                Console.WriteLine("Не валидные значения");

                return false;
            }

            return true;
        }
    }

    // Прямоугольник
    class Rectangle : Rhombus
    {
        public Rectangle(int width, int height) : base(width, height, 90)
        {
        }
    }

    // Квадрат
    class Square : Rhombus
    {
        public Square(int squareSide) : base(squareSide, squareSide, 90)
        {
        }
    }

    class Circle : Figure
    {
        protected int radius = 0;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        // Площадь
        public override double getSquare()
        {
            return isValid() ? (Math.PI*radius*radius) : 0; 
        }

        // Периметр
        public override double getPerimeter()
        {
            return isValid() ? (2*Math.PI*radius) : 0;
        }

        // Валидация
        public override bool isValid()
        {
            if (radius<0)
            {
                Console.WriteLine("Не валидные значения");

                return false;
            }

            return true;
        }

    }
}
