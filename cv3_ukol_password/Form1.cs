using System.Text.RegularExpressions;

namespace cv3_ukol_password
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        bool check = false;
        string text;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.visible__1_;
            textBox1.PasswordChar = '\0';

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.hide__1_;
            textBox1.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Heslo není správné nebo nesplòuje podmínky!");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                if (textBox2.Text == text)
                {
                    if (check)
                    {
                        MessageBox.Show("Heslo bylo nastaveno!");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Heslo není správné nebo nesplòuje podmínky!");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Heslo není správné nebo nesplòuje podmínky!");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string input = textBox1.Text;
            bool containsUppercase = Regex.IsMatch(input, "[A-Z]");
            bool containsNumber = Regex.IsMatch(input, "[0-9]");


            if (input.Length == 0)
            {
                label3.Text = "";
            }
            else if (input.Length < 12)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Heslo nesplòuje délku!";
                check = false;
            }
            else if (input.Length > 12)
            {
                if (!containsNumber)
                {
                    check = false;
                    label3.ForeColor = Color.Red;
                    label3.Text = "Heslo nesplòuje podmínku! Heslo musí obshavoat èísla!";
                }
                else if (!containsUppercase)
                {
                    check = false;
                    label3.ForeColor = Color.Red;
                    label3.Text = "Heslo nesplòuje podmínku! Heslo musí obshavoat velká písmena!";
                }
                else
                {
                    check = true;
                    label3.ForeColor = Color.Green;
                    label3.Text = "Heslo splòuje podmínky!";
                }
            }

            text = input;
        }
    }
}