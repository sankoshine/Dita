using System;
using System.Windows.Forms;
using System.IO;

namespace Dita
{
    public partial class Paper : Form
    {
        public static string root { get; set; }

        public Paper()
        {
            InitializeComponent();
        }

        private void import_Click(object sender, EventArgs e)
        {
            File.Delete(root + @"\gen\paper.txt");
            File.Delete(root + @"\gen\answer.csv");
            File.Delete(root + @"\gen\paperWithAnswer.txt");
            string filepath = root + @"\1.xls";
            MultipleChoiceQuestions multiple = new MultipleChoiceQuestions(filepath);
            int count = Int32.Parse(textBox1.Text);
            multiple.generate(count);
            filepath = root + @"\2.xls";
            BlankFillingQuestions blank = new BlankFillingQuestions(filepath);
            count = Int32.Parse(textBox2.Text);
            blank.generate(count);
            filepath = root + @"\3.xls";
            BlankFillingQuestions third = new BlankFillingQuestions(filepath);
            count = Int32.Parse(textBox3.Text);
            third.generate2(count);
            tip.Text = "Generated";
            System.Diagnostics.Process.Start("explorer.exe", root + @"\gen");
            this.Close();
        }

        private void directory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                root = folderBrowserDialog1.SelectedPath;
                tip.Text = root;
            }
        }

        private void Paper_Load(object sender, EventArgs e)
        {

        }

        private void check_Click(object sender, EventArgs e)
        {
            File.Delete(root + @"\gen\score.csv");
            BaseOperation.CollectAnswers(root + @"\gen");
            System.Diagnostics.Process.Start("explorer.exe", root + @"\gen");
            this.Close();
        }


    }
}
