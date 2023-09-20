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
        double timeLeft; // seconds
        double timeMinutes;
        double timeHours;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (timeLeft >0 ) 
            {
                minutesLabel.Text = Convert.ToString(timeMinutes);
                hoursLabel.Text = Convert.ToString(timeHours);
                timeLeft--;
                secondsLabel.Text = $"{timeLeft}";
          
            }
            else if (timeMinutes > 0 && secondsLabel.Text == "0" && secondsLabel.Text != "SS")
            {
                    timeMinutes--;
                    minutesLabel.Text = $"{timeMinutes}";
                  

                    timeLeft = 59; // Reset seconds to 59 when a minute passes

                    secondsLabel.Text = $"{timeLeft--}";

                if (secondsLabel.Text == "59") // fixed this weird thing of skipping a second in the begining
                {
                    timeLeft = 59;
                }
            }
            else if (timeHours > 0 && minutesLabel.Text == "0" && minutesLabel.Text != "MM")
            {
                timeHours--;
                hoursLabel.Text = $"{timeHours}";

                timeMinutes = 59;

                minutesLabel.Text = $"{timeMinutes--}";

                if (minutesLabel.Text == "59") // fixed this weird thing of skipping a minute in the begining
                {
                    timeMinutes = 60;
                }

            }
            else
            {
                timer.Stop();
                MessageBox.Show("Time Ended");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(secondTextbox.Text, out double inputSeconds))
            {
                timeLeft = inputSeconds;
                timer.Interval = 1000;
                timer.Start();
            }

            if (double.TryParse(minuteTextbox.Text, out double inputMinutes))
            {
                timeMinutes = inputMinutes;
                timer.Interval = 1000;
                timer.Start();
            }

            if (double.TryParse(hourTextbox.Text, out double inputHours))
            {
                timeHours = inputHours;
                timer.Interval = 1000;
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

        private void resetButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            secondsLabel.Text = "SS";
            minutesLabel.Text = "MM";
            hoursLabel.Text = "HH";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
