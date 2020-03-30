using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Generate
    {
        public static Point2D initPoint2D()
        {
            Point2D point;
            return point = Point2D.initPoint2D();
        }

        public static Triangle initTriangle()
        {
            Triangle triangle;
            return triangle = Triangle.initTriangle();
        }

        public static Rectangle initRectangle()
        {
            Rectangle rectangle;
            return rectangle = Rectangle.initRectangle();
        }

        public static Rectangle initRectangleSize(double height, double width)
        {
            Rectangle rectangle;
            return rectangle = Rectangle.initRectangleSize(height, width);
        }
    }
}
