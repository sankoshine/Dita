using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dita
{
    class MultipleChoiceQuestions
    {
        private List<MultipleChoice> questions;

        public MultipleChoiceQuestions(string filepath)
        {
            var list = FileIO.importXLS(filepath);
            questions = new List<MultipleChoice>();
            MultipleChoice multi;
            foreach(var line in list)
            {
                multi = new MultipleChoice(line);
                questions.Add(multi);
            }
        }

        public string getAnswer(int i)
        {
            return questions[i].answer;
        }

        public string generate(int count)
        {
            var totalCount = questions.Capacity;
            var random = BaseOperation.randomSelect(count, totalCount);
            string filepath1 = Paper.root + @"\gen\answer.csv";
            string filepath2 = Paper.root + @"\gen\paper.txt";
            string filepath3 = Paper.root + @"\gen\paperWithAnswer.txt";
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            int i = 0;
            list1.Add("一、选择题");
            list2.Add("一、选择题\r\n");
            list3.Add("一、选择题\r\n");
            string strLine1, strLine2;
            foreach (var idx in random)
            {
                var line = questions[idx];
                i++;
                strLine2 = i.ToString() + ". ";
                strLine2 += line.title + "\r\n";
                strLine2 += "A. " + line.choiceA + "\r\n";
                strLine2 += "B. " + line.choiceB + "\r\n";
                strLine2 += "C. " + line.choiceC + "\r\n";
                strLine2 += "D. " + line.choiceD + "\r\n";
                strLine1 = i.ToString() + "," + line.answer;
                list1.Add(strLine1);
                list2.Add(strLine2);
                strLine2 += "答案：" + line.answer + "\r\n";
                list3.Add(strLine2);
            }
            FileIO.outputTXT(filepath3, list3);
            FileIO.outputTXT(filepath2, list2);
            return FileIO.outputTXT(filepath1, list1);
        }
    }
}
