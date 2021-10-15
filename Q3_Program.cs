using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs = Quiz3.Triangle;

namespace Quiz3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle A = new Triangle();
            string S;
            string[] Temp; //字串陣列宣告。
            Temp = new string[2]; //配置記憶體及宣告長度。
            char Keep;
        Repeat:; //重複點。
            Console.WriteLine("=====三角形特性分析====="); //標題，WriteLine自動換行。
            Console.WriteLine("輸入座標點。(以空格分隔)");
            Console.Write("(X1, Y1) = "); //讀入座標，Write不換行。
            S = Console.ReadLine(); //讀入字串。            
            Temp = S.Split(' '); //以空格分割讀入字串。
            A.Point1X = double.Parse(Temp[0]); //進行資料轉換。
            A.Point1Y = double.Parse(Temp[1]);
            Console.Write("(X2, Y2) = ");
            S = Console.ReadLine(); //讀入字串。
            Temp = S.Split(' '); //分割字串。
            A.Point2X = double.Parse(Temp[0]);
            A.Point2Y = double.Parse(Temp[1]);
            Console.Write("(X3, Y3) = ");
            S = Console.ReadLine();
            Temp = S.Split(' ');
            A.Point3X = double.Parse(Temp[0]);
            A.Point3Y = double.Parse(Temp[1]); //讀入結束。
            if (A.isValid()) //錯誤判讀。
            {
                Console.WriteLine("此三點無法構成三角形。");
                goto GoOn;
            }
            Console.WriteLine("周長 = {0}", A.Perimeter());
            Console.WriteLine("面積 = {0}", A.Area());
            Console.WriteLine("外接圓半徑 = {0}", A.RadiusOfCircumcircle());
            if (A.isRight()) Console.WriteLine("是直角三角形。");
            else Console.WriteLine("非直角三角形。");
            GoOn:;
            Console.WriteLine("再次進行驗證？(是：Y / 否：N)");
            Keep = char.Parse(Console.ReadLine());
            switch (Keep)
            {
                case 'Y':
                    Console.Clear();
                    goto Repeat;
                case 'N':
                    break;
                default:
                    Console.WriteLine("Error, ending program.");
                    break;
            }
        }
    }
}
