using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dita
{
    class BaseOperation
    {
        public static List<int> randomSelect(int need,int total)
        {
            var list = new List<int>();
            Random r = new Random();
            var pool = new List<int>();
            for (int i = 0; i < total; i++)
            {
                pool.Add(i);
            }
            int result;
            int up = total-1;
            int down = 0;
            for (int i = 0; i < need; i++)
            {
                result = r.Next(down, up);
                list.Add(pool[result]);
                pool[result] = pool[up];
                up--;
            }
            return list;
        }
    }
}
