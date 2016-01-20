using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dita
{
    class MultipleChoice
    {
        public string title { get; set; }
        public string choiceA { get; set; }
        public string choiceB { get; set; }
        public string choiceC { get; set; }
        public string choiceD { get; set; }
        public string answer { get; set; }

        public MultipleChoice(List<string> line)
        {
            format(line);
        }

        private void format(List<string> line)
        {
            title = line[0];
            choiceA = line[1];
            choiceB = line[2];
            choiceC = line[3];
            choiceD = line[4];
            answer = line[5];
        }
    }
}
