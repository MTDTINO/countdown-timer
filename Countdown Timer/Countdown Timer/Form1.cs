using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Countdown_Timer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int timeLeft = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //timeLeft = Convert.ToInt32(textBox1.Text);
            
            if (timeLeft > 0) 
            {
                timeLeft--;
                label1.Text = $"Time Remaining:{timeLeft} Seconds";
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Time Ended");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int inputSeconds))
            {
                timeLeft = inputSeconds;
                timer.Interval = 1000; // Set the timer interval to 1 second
                timer.Start();
            }
            else
            {
                MessageBox.Show("Please enter a valid number of seconds.");
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
