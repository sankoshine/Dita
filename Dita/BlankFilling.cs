using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dita
{
    class BlankFilling
    {
        public string title { get; set; }
        public string answer { get; set; }

        public BlankFilling(List<string> line)
        {
            format(line);
        }

        private void format(List<string> line)
        {
            title = line[0];
            answer = line[1];
        }
    }
}
