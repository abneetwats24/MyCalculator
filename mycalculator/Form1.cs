using System;
using System.Windows.Forms;

namespace mycalculator
{
    public partial class calculator : Form
    {
        string[] parts;
        char CurrentOperator, LastOperator;

        public calculator()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            //clear
            if (TextBox.Text.Length != 0)
            {
                TextBox.Text = string.Empty;
                CurrentOperator = LastOperator = '\0';
            }
        }

        private void PercentageButtonClick(object sender, EventArgs e)
        {
          /*  if (TextBox.Text.Length != 0)
            {
                 Operate('%');
            }
            */
        }

        private void DivideButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length != 0)
            {
                 Operate('/');
            }
        }

        private void MultiplyButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length != 0)
            {
                Operate('*');
            }
        }

        private void NineButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "9";
            }
            else
            {
                TextBox.Text += "9";
            }

        }

        private void EightButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "8";
            }
            else
            {
                TextBox.Text += "8";
            }

        }

        private void SevenButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "7";
            }
            else
            {
                TextBox.Text += "7";
            }
        }

        private void FourButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "4";
            }
            else
            {
                TextBox.Text += "4";
            }
        }

        private void FiveButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "5";
            }
            else
            {
                TextBox.Text += "5";
            }
        }

        private void SixButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "6";
            }
            else
            {
                TextBox.Text += "6";
            }
        }

        private void MinusButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length != 0)
            {
                 Operate('-');
            }

        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length != 0)
            {
                 Operate('+');
            }
        }

        private void ThreeButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "3";
            }
            else
            {
                TextBox.Text += "3";
            }

        }

        private void TwoButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "2";
            }
            else
            {
                TextBox.Text += "2";
            }
        }

        private void OneButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "1";
            }
            else
            {
                TextBox.Text += "1";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = "0";
            }
            else
            {
                TextBox.Text += "0";
            }
        }

        private void DecimalButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length != 0 && !EndsWithOperator(TextBox.Text) && !TextBox.Text.EndsWith("."))
            {
                TextBox.Text += ".";
            }
        }

        private void BackspaceButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length != 0)
            {
                TextBox.Text = TextBox.Text.Remove(TextBox.Text.Length - 1, 1);

                if (TextBox.Text.Length == 0)
                {
                    CurrentOperator = LastOperator = '\0';
                }
                
            }
        }

        private void EqualButtonClick(object sender, EventArgs e)
        {
            if (TextBox.Text.Length != 0)
            {
                Operate('=');
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private static bool IsOperator(char op)
        {
            if (op == '+' || op == '-' || op == '*' || op == '/')
            {
                return true;
            }
            else {
                return false;
            }
        }
        private static bool EndsWithOperator(string str)
        {
            if(str.EndsWith("+") || str.EndsWith("-") || str.EndsWith("*") || str.EndsWith("/"))
            {
                return true;
            }else
            {
                return false;
            }
        }
        private static bool ContainsOperator(string str)
        {
            if(str.Contains("+")|| str.Contains("-") || str.Contains("*") || str.Contains("/"))
            {
                return true;
            }else
            {
                return false;
            }
        }
        private void Operate(char op)
        {
            if (op != '=')
            {
                CurrentOperator = op;
            }

            if (ContainsOperator(TextBox.Text))
            {
                if (!EndsWithOperator(TextBox.Text))
                {
                    parts = TextBox.Text.Split("+-*/".ToCharArray());

                    if (TextBox.Text.StartsWith("-"))
                    {
                        parts[0] += "-" + parts[1];
                        for (int i = 1; i < parts.Length - 1; i++)
                        {
                            parts[i] = parts[i + 1];
                        }
                    }

                    switch (LastOperator)
                    {
                        case '+':
                            TextBox.Text = Convert.ToString(Convert.ToDouble(parts[0]) + Convert.ToDouble(parts[1]));
                            break;
                        case '-':
                            TextBox.Text = Convert.ToString(Convert.ToDouble(parts[0]) - Convert.ToDouble(parts[1]));
                            break;
                        case '*':
                            TextBox.Text = Convert.ToString(Convert.ToDouble(parts[0]) * Convert.ToDouble(parts[1]));
                            break;
                        case '/':
                            TextBox.Text = Convert.ToString(Convert.ToDouble(parts[0]) / Convert.ToDouble(parts[1]));
                            break;
                    }

                    if (op != '=')
                    {
                        TextBox.Text += Convert.ToString(CurrentOperator);
                        LastOperator = CurrentOperator;
                    }
                    else
                    {
                        CurrentOperator = LastOperator = '\0';
                    }
                }
                else
                {
                    if (op != '=')
                    {
                        TextBox.Text = TextBox.Text.TrimEnd("+-*/".ToCharArray());
                        if (TextBox.Text.Length != 0)
                        {
                            TextBox.Text += Convert.ToString(CurrentOperator);
                            LastOperator = CurrentOperator;
                        }
                    }
                }
            }
            else
            {
                if (op != '=')
                {
                    TextBox.Text += Convert.ToString(CurrentOperator);
                    LastOperator = CurrentOperator;
                }
            }
        }
    }
}
