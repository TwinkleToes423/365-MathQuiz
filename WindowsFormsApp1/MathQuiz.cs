using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MathQuiz : Form
    {
        //random number generator
        Random randomizer = new Random();

        //for the addition problem
        int addend1;
        int addend2;

        public MathQuiz()
        {
            InitializeComponent();
        }

        private void MathQuiz_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void StartTheQuiz()
        {
            //Fill in the addition problem
            //generate two random numbers to add
            //store the values in the variables 'addend1' and 'addend2'
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //convert the two random #'s into strings so they can be displayed
            //in the controls
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //'sum' is the name of the NumericUpDown control.
            //This step makes sure it's value is zero before adding by values to it
            Sum.Value = 0;
        }
        private void startButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }
    }
    
}
