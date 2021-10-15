using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz3
{
    class Triangle
    {
        public double Point1X, Point1Y, Point2X, Point2Y, Point3X, Point3Y; //座標點。

        public bool isValid() //成立判別。
        {
            double A, B;
            A = (this.Point2Y - this.Point1Y) / (this.Point2X - this.Point1X);
            B = (this.Point3Y - this.Point1Y) / (this.Point3X - this.Point1X);
            if (A == B) return true;
            else return false;
        }

        private double Length(double a, double b, double x, double y) //邊長計算。
        {
            double length;
            double A, B;
            A = a - x;
            B = b - y;
            double s;
            s = A * A + B * B;
            length = Math.Sqrt(s);
            return length;
        }

        public double Perimeter() //周長計算。
        {
            double l1 = this.Length(this.Point1X, this.Point1Y, this.Point2X, this.Point2Y);
            double l2 = this.Length(this.Point2X, this.Point2Y, this.Point3X, this.Point3Y);
            double l3 = this.Length(this.Point1X, this.Point1Y, this.Point3X, this.Point3Y);
            double len = l1 + l2 + l3;
            return len;
        }

        public double Area() //面積計算，海龍公式。
        {
            double l1 = this.Length(this.Point1X, this.Point1Y, this.Point2X, this.Point2Y);
            double l2 = this.Length(this.Point2X, this.Point2Y, this.Point3X, this.Point3Y);
            double l3 = this.Length(this.Point1X, this.Point1Y, this.Point3X, this.Point3Y);
            double area;
            double s;
            s = (l1 + l2 + l3) / 2;
            area = s * (s - l1) * (s - l2) * (s - l3);
            area = Math.Sqrt(area);
            return area;
        }

        private double Angle(double l1, double l2, double l3) //角度計算，餘弦定理。
        {
            double angle;
            double s;
            s = l3 * l3 + l2 * l2 - l1 * l1;
            s = s / (2 * l2 * l3);
            angle = Math.Acos(s);
            return angle;
        }

        public double RadiusOfCircumcircle() //角度計算，餘弦定理。
        {
            double l1 = this.Length(this.Point1X, this.Point1Y, this.Point2X, this.Point2Y);
            double l2 = this.Length(this.Point2X, this.Point2Y, this.Point3X, this.Point3Y);
            double l3 = this.Length(this.Point1X, this.Point1Y, this.Point3X, this.Point3Y);
            double radius;
            double s;
            s = l3 * l2 * l1 / 4;
            radius = s / this.Area();
            return radius;
        }

        public bool isRight() //直角判別。
        {
            double l1 = this.Length(this.Point1X, this.Point1Y, this.Point2X, this.Point2Y);
            double l2 = this.Length(this.Point2X, this.Point2Y, this.Point3X, this.Point3Y);
            double l3 = this.Length(this.Point1X, this.Point1Y, this.Point3X, this.Point3Y);
            double a1 = this.Angle(l1, l2, l3);
            double a2 = this.Angle(l2, l3, l1);
            double a3 = this.Angle(l3, l1, l2);
            if (a1 == Math.PI / 2 || a2 == Math.PI / 2 || a3 == Math.PI / 2) return true;
            else return false;
        }
    }
}
