using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public static List<string> CollectAnswers(string directory)
        {
            var list = new List<string>();
            var listFromFile = FileIO.importXLS(directory + @"\answer.xls");
            string real_answer, result;
            foreach (var question in listFromFile)
            {
                result = question[0];
                var isNum = new Regex(@"^\d+$").Match(result);  
                if (!isNum.Success)
                {
                    list.Add(result);
                    continue;
                }
                real_answer = question[1];
                for (int j = 2; j < question.Count; j++ )
                {
                    var answer = question[j];
                    if (answer.Equals(real_answer))
                    {
                        result += ",1";
                    }
                    else
                    {
                        result += ",0";
                    }
                }
                list.Add(result);
            }
            FileIO.outputTXT(directory + @"\score.csv", list);
            return list;
        }
    }
}
