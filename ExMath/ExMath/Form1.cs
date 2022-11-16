using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExMath
{
    public partial class Form1 : Form
    {
        Exercise exercise = new Exercise();
        public Form1()
        {
            InitializeComponent();
            File.AppendAllText("newExercisePage.txt", " ");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDownFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Char> lstOp = new List<char>();
            foreach (var item in panel1.Controls)
            {
                if ((item as CheckBox).Checked)
                {
                    switch ((item as CheckBox).Text)
                    {
                        case "חיבור":
                            lstOp.Add('+');
                            break;
                        case "חיסור":
                            lstOp.Add('-');
                            break;
                        case "כפל":
                            lstOp.Add('*');
                            break;
                        case "חילוק":
                            lstOp.Add('/');
                            break;
                        default:
                            break;
                    }
                }
            }
            exercise.FirstNum = (int)numericUpDownFrom.Value;
            exercise.SecendNum = (int)numericUpDownTo.Value;
            CreateEx(exercise.FirstNum, exercise.SecendNum, lstOp);
        }
        private void CreateEx(int num1, int num2, List<char> lstOperators)
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //התרגיל החדש
                    string ex = " ";
                    Char op;
                    //הגרלת המספרים

                    int firstNum = r.Next(num1 , num2 + 1);
                    int secendNum = r.Next(num1 , num2 + 1);
                    ex += firstNum.ToString();

                    //הגרלת האופרטורים
                    if (lstOperators.Count() > 1)
                    {
                        int index = r.Next(0, lstOperators.Count());
                        op = lstOperators[index];
                        ex += " " + op.ToString();
                    }
                    else
                    {
                        op = lstOperators[0];
                        ex += " " + op.ToString();
                    }

                    ex += " " + secendNum.ToString();
                    ex += " =";

                    File.AppendAllText("newExercisePage.txt", "\t\t\t" + ex);


                }

                File.AppendAllText("newExercisePage.txt", "\n\n\n");

            }

            linkLabel1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists("newExercisePage.txt"))

            {
                openFileDialog1.InitialDirectory = new FileInfo("newExercisePage.txt").DirectoryName;
                openFileDialog1.ShowDialog();
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Process.Start("explorer.exe", "newExercisePage.txt");
        }
    }
}
