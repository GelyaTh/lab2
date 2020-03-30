using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab2
{
    public class Triangle
    {
        public Point2D point1;

        public Point2D point2;

        public Point2D point3;
        public double Left;
        public double Right;
        public double Top;
        public double Down;

        public static Triangle initTriangle()
        {
            Triangle triangle = new Triangle();

            triangle.point1 = Generate.initPoint2D();
            
            triangle.point2 = Generate.initPoint2D();
            
            triangle.point3 = Generate.initPoint2D();

            triangle.Top = Math.Min(triangle.point1.getY(), Math.Min(triangle.point2.getY(), triangle.point3.getY()));
            triangle.Down = Math.Max(triangle.point1.getY(), Math.Max(triangle.point2.getY(), triangle.point3.getY()));
            triangle.Left = Math.Min(triangle.point1.getX(), Math.Min(triangle.point2.getX(), triangle.point3.getX()));
            triangle.Right = Math.Max(triangle.point1.getX(), Math.Max(triangle.point2.getX(), triangle.point3.getX()));

            return triangle;
        }

        public Point2D getPoint1()
        {
            return point1;
        }

        public Point2D getPoint2()
        {
            return point2;
        }

        public Point2D getPoint3()
        {
            return point3;
        }

        public double getPerimeter()
        {
            double first = point1.getDistance(point2);
            double second = point2.getDistance(point3);
            double third = point3.getDistance(point1);

            return first + second + third;
        }

        public double getArea()
        {
            double halfPerimeter = getPerimeter()/2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - point1.getDistance(point2)) * (halfPerimeter - point2.getDistance(point3)) * (halfPerimeter - point3.getDistance(point1)));

        }

        public void shiftX(double value)
        {
            point1.shiftX(value);
            point2.shiftX(value); 
            point3.shiftX(value);
        }

        public void shiftY(double value)
        {
            point1.shiftY(value);
            point2.shiftY(value);
            point3.shiftY(value);
        }
    }
}
