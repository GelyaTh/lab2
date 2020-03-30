using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        private Point2D point;
        private Rectangle rectangle;
        private Triangle triangle;

        private void drawPoint(Point2D point) 
        {
            Ellipse boldPoint = new Ellipse();
            boldPoint.Width = 4;
            boldPoint.Height = 4;
            boldPoint.StrokeThickness = 2;
            boldPoint.Stroke = Brushes.Black;
            boldPoint.Margin = new Thickness(point.getX() - 2, point.getY() - 2, 0, 0);

            MainCanvas.Children.Add(boldPoint);
        }

        private void drawLine(Point2D beginPoint, Point2D endPoint)
        {
            Line line = new Line();
            line.Stroke = Brushes.DarkBlue;
            line.X1 = beginPoint.getX();
            line.Y1 = beginPoint.getY();
            line.X2 = endPoint.getX();
            line.Y2 = endPoint.getY();
            MainCanvas.Children.Add(line);
        }
        private void drawRectangle(Rectangle rectangle)
        {
            drawLine(rectangle.getPoint1(), rectangle.getPoint2());
            drawLine(rectangle.getPoint2(), rectangle.getPoint4());
            drawLine(rectangle.getPoint4(), rectangle.getPoint3());
            drawLine(rectangle.getPoint3(), rectangle.getPoint1());
        }

        private void drawTriangle(Triangle triangle)
        {
            drawLine(triangle.getPoint1(), triangle.getPoint2());
            drawLine(triangle.getPoint2(), triangle.getPoint3());
            drawLine(triangle.getPoint3(), triangle.getPoint1());
        }
        private void showRectangleInfo(Rectangle rectangle)
        {
            rectangleArea.Text = "Площадь: " + rectangle.getArea().ToString("0.00");
            rectanglePerimeter.Text = "Периметр: " + rectangle.getPerimeter().ToString("0.00");
            rectangleCoords.Text = "(" + rectangle.point1.getX().ToString("0") + ";" + rectangle.point1.getY().ToString("0") + "),"
                                + "(" + rectangle.point2.getX().ToString("0") + ";" + rectangle.point2.getY().ToString("0") + "),"
                                + "(" + rectangle.point3.getX().ToString("0") + ";" + rectangle.point3.getY().ToString("0") + "),"
                                + "(" + rectangle.point4.getX().ToString("0") + ";" + rectangle.point4.getY().ToString("0") + ")";
        }
        private void showTriangleInfo(Triangle triangle)
        {
            triangleArea.Text = "Площадь: " + triangle.getArea().ToString("0.00");
            trianglePerimeter.Text = "Периметр: " + triangle.getPerimeter().ToString("0.00");
            triangleCoords.Text = "(" + triangle.point1.getX().ToString("0") + ";" + triangle.point1.getY().ToString("0") + "),"
                                    + "(" + triangle.point2.getX().ToString("0") + ";" + triangle.point2.getY().ToString("0") + "),"
                                    + "(" + triangle.point3.getX().ToString("0") + ";" + triangle.point3.getY().ToString("0") + ")";
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Point2DBt_Click(object sender, RoutedEventArgs e)
        {
            pointInfo.Visibility = Visibility.Visible;
            triangleInfo.Visibility = Visibility.Hidden;
            rectangleInfo.Visibility = Visibility.Hidden;
            rectangleOptions.Visibility = Visibility.Hidden;

            MainCanvas.Children.Clear();
            rectangle = null;
            triangle = null;
            point = Generate.initPoint2D();


            drawPoint(point);

            pointX.Text = "X: " + point.getX().ToString("0.00");
            pointY.Text = "Y: " + point.getY().ToString("0.00");

            SliderX.Maximum = 500;
            SliderX.Value = point.getX();
            SliderY.Maximum = 300;
            SliderY.Value = point.getY();
        }

        private void RectangleBt_Click(object sender, RoutedEventArgs e)
        {
            pointInfo.Visibility = Visibility.Hidden;
            rectangleOptions.Visibility = Visibility.Visible;
            triangleInfo.Visibility = Visibility.Hidden;
            rectangleInfo.Visibility = Visibility.Visible;

            MainCanvas.Children.Clear();
            triangle = null;
            point = null;

            if (rectangleWidth.Text == "" && rectangleHeight.Text == "")
            {
                rectangle = Generate.initRectangle();
            }
            else
            {
                if (double.Parse(rectangleHeight.Text) > 300 || double.Parse(rectangleWidth.Text) > 500)
                {
                    MessageBox.Show("Введите корректные данные");
                    return;
                }
                rectangle = Generate.initRectangleSize(double.Parse(rectangleHeight.Text), double.Parse(rectangleWidth.Text));                
            }
            drawRectangle(rectangle);
            showRectangleInfo(rectangle);
            SliderX.Maximum = 500 - (rectangle.Right - rectangle.Left);
            SliderX.Value = rectangle.Left;
            SliderY.Maximum = 300 - (rectangle.Down - rectangle.Top);
            SliderY.Value = rectangle.Top;          
        }

        private void TriangleBt_Click(object sender, RoutedEventArgs e)
        {
            pointInfo.Visibility = Visibility.Hidden;
            rectangleInfo.Visibility = Visibility.Hidden;
            rectangleOptions.Visibility = Visibility.Hidden;
            triangleInfo.Visibility = Visibility.Visible;

            MainCanvas.Children.Clear();
            point = null;
            rectangle = null;
            triangle = Generate.initTriangle();


            drawTriangle(triangle);
            showTriangleInfo(triangle);
            SliderX.Maximum = 500 - (triangle.Right - triangle.Left);
            SliderX.Value = triangle.Left;
            SliderY.Maximum = 300 - (triangle.Down - triangle.Top);
            SliderY.Value = triangle.Top;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double shiftvalue = SliderX.Value;

            if (rectangle != null)
            {
                shiftvalue -= rectangle.Left;
                rectangle.shiftX(shiftvalue);
                MainCanvas.Children.Clear();
                drawRectangle(rectangle);
                showRectangleInfo(rectangle);
            }

            if (triangle != null)
            {
                shiftvalue -= triangle.Left;
                triangle.shiftX(shiftvalue);
                MainCanvas.Children.Clear();
                drawTriangle(triangle);
                showTriangleInfo(triangle);
            }

            if (point != null)
            {
                shiftvalue -= point.getTrueX();
                point.shiftX(shiftvalue);
                MainCanvas.Children.Clear();
                drawPoint(point);
                pointX.Text = "X: " + point.getX().ToString("0.00");

            }
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double shiftvalue = SliderY.Value;

            if (rectangle != null)
            {
                shiftvalue -= rectangle.Top;
                rectangle.shiftY(shiftvalue);
                MainCanvas.Children.Clear();
                drawRectangle(rectangle);
                showRectangleInfo(rectangle);

            }

            if (triangle != null)
            {
                shiftvalue -= triangle.Top;
                triangle.shiftY(shiftvalue);
                MainCanvas.Children.Clear();
                drawTriangle(triangle);
                showTriangleInfo(triangle);

            }

            if (point != null)
            {
                shiftvalue -= point.getTrueY();
                point.shiftY(shiftvalue);
                MainCanvas.Children.Clear();
                drawPoint(point);
                pointY.Text = "Y: " + point.getY().ToString("0.00");
            }
        }
    }
}
