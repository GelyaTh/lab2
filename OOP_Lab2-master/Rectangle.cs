using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Math;

namespace Lab2
{
    public class Rectangle
    {
        public Point2D point1;

        public Point2D point2;

        public Point2D point3;

        public Point2D point4;

        public double Left;
        public double Right;
        public double Top;
        public double Down;

        public static Rectangle initRectangle()
        {
            Rectangle rectangle = new Rectangle();

            rectangle.point1 = Generate.initPoint2D();           
            rectangle.point2 = Generate.initPoint2D();                    
            rectangle.point3 = Generate.initPoint2D();
            rectangle.point4 = Generate.initPoint2D();


            rectangle.point2.setX(rectangle.point4.getX());
            rectangle.point2.setY(rectangle.point1.getY());
            rectangle.point3.setX(rectangle.point1.getX());
            rectangle.point3.setY(rectangle.point4.getY());

            rectangle.Left = Math.Min(rectangle.point1.getX(), rectangle.point4.getX());
            rectangle.Right = Math.Max(rectangle.point1.getX(), rectangle.point4.getX());
            rectangle.Top = Math.Min(rectangle.point1.getY(), rectangle.point4.getY());
            rectangle.Down = Math.Max(rectangle.point1.getY(), rectangle.point4.getY());

            return rectangle;
        }
        
        public static Rectangle initRectangleSize(double height, double width)
        {
            Rectangle rectangle = new Rectangle();

            rectangle.point1 = Generate.initPoint2D();      
            rectangle.point2 = Generate.initPoint2D(); 
            rectangle.point3 = Generate.initPoint2D();
            rectangle.point4 = Generate.initPoint2D();

            rectangle.point1.setX(0);
            rectangle.point1.setY(0);

            rectangle.point2.setX(width);
            rectangle.point2.setY(rectangle.point1.getY());

            rectangle.point3.setX(rectangle.point1.getX());
            rectangle.point3.setY(height);

            rectangle.point4.setX(width);
            rectangle.point4.setY(height);

            rectangle.Left = Math.Min(rectangle.point1.getX(), rectangle.point4.getX());
            rectangle.Right = Math.Max(rectangle.point1.getX(), rectangle.point4.getX());
            rectangle.Top = Math.Min(rectangle.point1.getY(), rectangle.point4.getY());
            rectangle.Down = Math.Max(rectangle.point1.getY(), rectangle.point4.getY());
            return rectangle;
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

        public Point2D getPoint4()
        {
            return point4;
        }

        public double getArea()
        {
            return (Down-Top) * (Right - Left);
        }

        public double getPerimeter()
        {
            return ((Down - Top) + (Right - Left)) * 2;
        }

        public void shiftX(double value)
        {
            point1.shiftX(value);
            point2.shiftX(value);
            point3.shiftX(value);
            point4.shiftX(value);
        }

        public void shiftY(double value)
        {
            point1.shiftY(value);
            point2.shiftY(value);
            point3.shiftY(value);
            point4.shiftY(value);
        }
    }
}
