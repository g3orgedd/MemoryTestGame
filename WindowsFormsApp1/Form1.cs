using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();

        int rightAnswers = 0, wrongAnswers = 0, score = 0, randomNumber = 0; //easterEgg = 0;

        string number = "";
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text += (sender as Button).Text;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int x = rnd.Next(100000, 1000000);
            randomNumber = x;
            textBoxShow.Text = x.ToString();
            number = x.ToString();
            textBoxAnswer.Clear();
            //infoLabel.Text = "";

            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void textBoxAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            char press = e.KeyChar;

            if (!Char.IsSymbol(press))
            {
                e.Handled = true;
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (textBoxAnswer.Text == number.ToString() && textBoxAnswer.Text != "")
            {
                ++rightAnswers;
                score += 100;

                labelRightAnswers.Text = "Right Answers: " + rightAnswers;
                labelScore.Text = "Score: " + score;

                if (rightAnswers == 9)
                {
                    rightAnswers = 0;
                }

                textBoxAnswer.Clear();
            }
            else
            {
                if (randomNumber == 0)
                {

                }
                else
                {
                    ++wrongAnswers;
                    score -= 50;

                    labelWrongAnswers.Text = "Wrong Answers: " + wrongAnswers;
                    labelScore.Text = "Score: " + score;

                    if (wrongAnswers == 99)
                    {
                        wrongAnswers = 0;
                    }
                }
            }
        }

        private void buttonHint_Click(object sender, EventArgs e)
        {
            timer.Interval = 200;
            timer.Tick += new EventHandler(timerHint_Tick);
            timer.Start();

            textBoxShow.Text = randomNumber.ToString();

            if (labelScore.Text == "Score: " && randomNumber == 0)
            {

            }
            else
            {
                score -= 100;
                labelScore.Text = "Score: " + score;
            }
        }

        private void timerHint_Tick(object sender, EventArgs e)
        {
            this.textBoxShow.Text = "";
            timer.Stop();
        }

        private void buttonClearDigit_Click(object sender, EventArgs e)
        {
            if (textBoxAnswer.Text != "")
            {
                textBoxAnswer.Text = textBoxAnswer.Text.Remove(textBoxAnswer.Text.Length - 1, 1);
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            this.textBoxShow.Text = "";
            timer.Stop();
        }
    }
}
