using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz4
{
    class Triangle
    {
        public double[,] Coord = new double[3, 2]; //宣告二維陣列，座標點。
        public double[] Length() //邊長陣列。
        {
            double[] length = new double[3];
            length[0] = Math.Sqrt(Math.Pow(Coord[0, 0] - Coord[1, 0], 2) + Math.Pow(Coord[0, 1] - Coord[1, 1], 2));
            length[1] = Math.Sqrt(Math.Pow(Coord[1, 0] - Coord[2, 0], 2) + Math.Pow(Coord[1, 1] - Coord[2, 1], 2));
            length[2] = Math.Sqrt(Math.Pow(Coord[2, 0] - Coord[0, 0], 2) + Math.Pow(Coord[2, 1] - Coord[0, 1], 2));
            return length;
        }
        public double LenSum() //周長。
        {
            double[] length = Length();
            double lensum = length[0] + length[1] + length[2];
            return lensum;
        }
        public double[] Slope() //斜率陣列。
        {
            double[] slope = new double[3];
            double[] x = new double[3];
            double[] y = new double[3];
            x[0] = Coord[0, 0] - Coord[1, 0];
            y[0] = Coord[0, 1] - Coord[1, 1];
            x[1] = Coord[1, 0] - Coord[2, 0];
            y[1] = Coord[1, 1] - Coord[2, 1];
            x[2] = Coord[2, 0] - Coord[0, 0];
            y[2] = Coord[2, 1] - Coord[0, 1];
            for (int i = 0; i <= 2; i++) //避免正負無窮大異號問題。
            {
                if (x[i] == 0) slope[i] = 1 / x[i];
                else slope[i] = y[i] / x[i];
            }
            return slope;
        }

        public bool Error() //成立判別。
        {
            double[] slope = Slope();
            if (slope[0] == slope[1]) return true;
            else return false;
        }

        public double Area() //面積計算，海龍公式。
        {
            double[] length = Length();
            double s, area;
            s = (length[0] + length[1] + length[2]) / 2;
            area = Math.Sqrt(s * (s - length[0]) * (s - length[1]) * (s - length[2]));
            return area;
        }

        public double[] Angle() //角度計算，餘弦定理，可直接回傳陣列。
        {
            double[] angle = new double[3];
            double[] length = Length();
            angle[0] = length[1] * length[1] + length[2] * length[2] - length[0] * length[0];
            angle[0] = angle[0] / (2 * length[1] * length[2]);
            angle[0] = Math.Acos(angle[0]);
            angle[1] = length[0] * length[0] + length[2] * length[2] - length[1] * length[1];
            angle[1] = angle[1] / (2 * length[0] * length[2]);
            angle[1] = Math.Acos(angle[1]);
            angle[2] = length[1] * length[1] + length[0] * length[0] - length[2] * length[2];
            angle[2] = angle[2] / (2 * length[1] * length[0]);
            angle[2] = Math.Acos(angle[2]);
            return angle;
        }

        public double OuterRadius() //外接圓半徑。
        {
            double[] length = Length();
            double radius;
            radius = length[0] * length[1] * length[2] / 4 / Area();
            return radius;
        }

        public bool Right() //直角判別。
        {
            double[] angle = Angle();
            if (angle[0] == Math.PI / 2 || angle[1] == Math.PI / 2 || angle[2] == Math.PI / 2) return true;
            else return false;
        }
    }
}
