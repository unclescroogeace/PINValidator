using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PINValidator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pin = textBox1.Text;
            pin = pin.Replace(" ", string.Empty);
            string digits = string.Empty;
            int[] weightArray = new int[] {2, 4, 8, 5, 10, 9, 7, 3, 6 };
            if (Regex.IsMatch(pin, "^[0-9]{10}$"))
            {
                digits = pin.Substring(0, 2);
                if ((digits == "00") || (int.Parse(digits) >= 1 && int.Parse(digits) <= 99))
                {
                    digits = pin.Substring(2, 2);
                    if ((int.Parse(digits) >= 1 && int.Parse(digits) <= 12) ||
                        (int.Parse(digits) >= 21 && int.Parse(digits) <= 32) ||
                        (int.Parse(digits) >= 41 && int.Parse(digits) <= 52))
                    {
                        digits = pin.Substring(4, 2);
                        if (int.Parse(digits) >= 1 && int.Parse(digits) <= 31)
                        {
                            int checksum = 0;
                            for(int i = 0; i < pin.Length - 1; i++)
                            {
                                checksum += int.Parse(pin[i].ToString()) * weightArray[i];
                            }
                            int check = checksum % 11;
                            if (check < 10)
                            {
                                if(int.Parse(pin[9].ToString()) == check)
                                {
                                    label1.ForeColor = ColorTranslator.FromHtml("#33cc33");
                                    label1.Text = "VALID";
                                }
                                else
                                {
                                    label1.ForeColor = ColorTranslator.FromHtml("#ff0000");
                                    label1.Text = "NOT VALID";
                                }
                            }
                            else
                            {
                                if (int.Parse(pin[9].ToString()) == 0)
                                {
                                    label1.ForeColor = ColorTranslator.FromHtml("#33cc33");
                                    label1.Text = "VALID";
                                }
                                else
                                {
                                    label1.ForeColor = ColorTranslator.FromHtml("#ff0000");
                                    label1.Text = "NOT VALID";
                                }
                            }
                        }
                        else
                        {
                            label1.ForeColor = ColorTranslator.FromHtml("#ff0000");
                            label1.Text = "NOT VALID";
                        }
                    }
                    else
                    {
                        label1.ForeColor = ColorTranslator.FromHtml("#ff0000");
                        label1.Text = "NOT VALID";
                    }
                }
            }else
            {
                label1.ForeColor = ColorTranslator.FromHtml("#ff0000");
                label1.Text = "NOT VALID";
            }
        }
    }
}
