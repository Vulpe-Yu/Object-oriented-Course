using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs = Quiz4.Triangle;

namespace Quiz4
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
            while (true)
            {
                Console.WriteLine("=====三角形特性分析====="); //標題，WriteLine自動換行。
                Console.WriteLine("輸入座標點。(以空格分隔)");
                for (int i = 0; i <= 2; i++)
                {
                    Console.Write("(X{0}, Y{0}) = ", i+1); //讀入座標，Write不換行。
                    S = Console.ReadLine(); //讀入字串。            
                    Temp = S.Split(' '); //以空格分割讀入字串。
                    A.Coord[i, 0] = double.Parse(Temp[0]); //進行資料轉換。
                    A.Coord[i, 1] = double.Parse(Temp[1]);
                }
                if (A.Error()) //錯誤判讀，斜率相等。
                {
                    Console.WriteLine("此三點無法構成三角形。");
                    goto GoOn;
                }
                Console.WriteLine("周長 = {0}", A.LenSum());
                Console.WriteLine("面積 = {0}", A.Area());
                Console.WriteLine("外接圓半徑 = {0}", A.OuterRadius());
                if (A.Right()) Console.WriteLine("是直角三角形。");
                else Console.WriteLine("非直角三角形。");
                GoOn:;
                Console.WriteLine("再次進行驗證？(是：Y / 否：N)");
                Keep = char.Parse(Console.ReadLine());
                switch (Keep)
                {
                    case 'Y':
                        Console.Clear();
                        break;
                    case 'N':
                        goto End;
                    default:
                        Console.WriteLine("Error, ending program.");
                        goto End;
                }
            }
        End:;
            Console.ReadKey();
        }
    }
}
