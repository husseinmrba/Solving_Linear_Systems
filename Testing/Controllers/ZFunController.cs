using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing.Controllers
{
    internal class ZFunController
    {

        

        public static double ResultZFun(Point point, ZFun zFun)
        {
            return ((point.x1 * zFun.x1) + (point.x2 * zFun.x2));
        }

        public static double MaxFun(List<double> res)
        {
            double max = double.MinValue;
            foreach (var item in res)
            {
                if (max < item)
                {
                    max = item;
                }
            }
            return max;
        }

        public static double MinFun(List<double> res)
        {
            double min = double.MaxValue;
            foreach (var item in res)
            {
                if (min > item)
                {
                    min = item;
                }
            }
            return min;
        }



    }
}
