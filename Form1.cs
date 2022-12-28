using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc_3
{
    public partial class Form1 : Form

    {

        bool operandPerformed = false;
        bool ChangeOperation = false;
        string operand = ""; // для швидкої зміни операції
        double result = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void NumEvent(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || operandPerformed )// Зміна булевого значення на true означає що був обраний тип операціїї і потрібно очистити texBox для нового числаю 
            {
                textBox1.Clear();
            }

            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
            operandPerformed = false;
        }

        private void OperandEvent(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                
                
                operandPerformed = true;
                Button btn = (Button)sender;
                string newOperand = btn.Text;

                calculate();
                if (operand != "" || result == 0)
                    label1.Text = textBox1.Text + " " + newOperand;
                else
                    label1.Text += textBox1.Text + " " + newOperand;
                result = Double.Parse(textBox1.Text);
                operand = newOperand; // наступна операція відбувається за новим операндом
                ChangeOperation = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";
            result = 0;
            operand = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text += " "+textBox1.Text +" =";
            operandPerformed = true;

            calculate();

            result = Double.Parse(textBox1.Text);
            textBox1.Text = result.ToString();
            result = 0;
            operand = "";

        }


        private void button18_Click(object sender, EventArgs e)
        {
            if (!operandPerformed && !textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
            else if (operandPerformed)
            {
                textBox1.Text = "0";
            }

            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }

            operandPerformed = false;
        }
        private void calculate()
        {
            switch (operand)
            {
                case "+": textBox1.Text = (result + Double.Parse(textBox1.Text)).ToString(); break;
                case "-": textBox1.Text = (result - Double.Parse(textBox1.Text)).ToString(); break;
                case "*": textBox1.Text = (result * Double.Parse(textBox1.Text)).ToString(); break;
                case "/": textBox1.Text = (result / Double.Parse(textBox1.Text)).ToString(); break;
                default: break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    } 
       
    
}
