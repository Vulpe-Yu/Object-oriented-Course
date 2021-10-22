using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40873011H_Q4
{
    class Triangle
    {
        public double[,] Point = new double[4,2];

        public bool isValid()
        {
            double[] x = new double[2];
            double[] y = new double[2];
            for(int i = 0; i <= 1; i++)
            {
                x[i] = Point[0, 0] - Point[i + 1, 0];
            }
            for (int i = 0; i <= 1; i++)
            {
                y[i] = Point[0, 1] - Point[i + 1, 1];
            }
            double[] slope = new double[2];
            for (int i = 0; i <= 1; i++)
            {
                if(x[i] == 0) slope[i] = 1 / x[i];
                else slope[i] = y[i] / x[i];
            }
            bool error;
            if (slope[0] == slope[1]) error = true;
            else error = false;
            return error;
        }

        public double[] Length()
        {
            double[] length = new double[5];
            for (int i = 0; i <= 2; i++)
            {
                double x = Point[i, 0] - Point[i + 1, 0];
                double y = Point[i, 1] - Point[i + 1, 1];
                length[i] = Math.Sqrt(x * x + y * y);
            }
            length[3] = length[0];
            length[4] = length[1];
            return length;
        }

        public double Perimeter()
        {
            double perimeter;
            double[] length = Length();
            perimeter = length[0] + length[1] + length[2];
            return perimeter;
        }

        public double Area()
        {
            double[] length = Length();
            double s = Perimeter() / 2;
            double area = Math.Sqrt(s * (s - length[0]) * (s - length[1]) * (s - length[2]));
            return area;
        }

        public double RadiusOfCircumcircle()
        {
            double radius;
            double[] length = Length();
            radius = length[0] * length[1] * length[2] / 4 / Area();
            return radius;
        }

        public double[] Angle()
        {
            double[] angle = new double[3];
            double[] length = Length();
            for (int i = 0; i <= 2; i++)
            {
                angle[i] = Math.Acos((length[i] * length[i] + length[i + 1] * length[i + 1] - length[i + 2] * length[i + 2]) / (2 * length[i] * length[i + 1]));
            }
            return angle;
        }

        public bool isRight()
        {
            double[] angle = new double[3];
            angle = Angle();
            double a = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (angle[i] > a) a = angle[i];
            }
            bool right;
            if (a == Math.PI / 2) right = true;
            else right = false;
            return right;
        }
    }
}
