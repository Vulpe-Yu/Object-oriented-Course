using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs = _40873011H_Q4.Triangle;

namespace _40873011H_Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle A = new Triangle();
            string S, Keep;
            string[] Temp = new string[2];
            while (true)
            {
            Console.WriteLine("=====三角形分析=====");
            for(int i = 0; i <= 2; i++)
            {
            Console.Write("輸入第{0}座標：", i+1);
            S = Console.ReadLine();
            Temp = S.Split(' ');
            for (int j = 0; j <= 1; j++)
                {
                    A.Point[i, j] = double.Parse(Temp[j]);
                }
            }
            for (int i = 0; i <= 1; i++)
            {
                A.Point[3, i] = A.Point[0, i];
            }
            if (A.isValid()) 
            { 
                Console.WriteLine("這三點不能組成三角形！"); 
            }
            else
            {
            Console.WriteLine("邊長 = {0}", A.Perimeter());
            Console.WriteLine("面積 = {0}", A.Area());
            Console.WriteLine("外接圓半徑 = {0}", A.RadiusOfCircumcircle());
            if (A.isRight()) Console.WriteLine("直角三角形");
            else Console.WriteLine("非直角三角形");
            }
            Console.Write("繼續執行(Y)/結束程式(N)：");
            Keep = Console.ReadLine();
            switch (Keep)
            {

                case "Y":
                    break;
                case "N":
                    goto End;
                default:
                    break;

            }
            Console.WriteLine();
            }
            End:;
        }
    }
}
