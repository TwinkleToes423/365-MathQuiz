﻿using System;
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

        //for the subtraction problem 
        int minuend;
        int subtrahend;

        //integer variables for multiplication
        int multiplicand;
        int multiplier;

        //integer variable autofill for division
        int dividend;
        int divisor;

        //This integer variable keeps track of time remaining
        int timeLeft;


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
            sum.Value = 0;

            //fill in the subtraction problem 
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = subtrahend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //autofill multiplication problem values
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            //autofill division problem values
            divisor = randomizer.Next(2, 11);
            int temporatyQuotient
            //start timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        private void startButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //if method returns true, then user got answer correct if galse show messagebox
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //display the new time left
                // by updating the time left label
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";

            }
            else
            {
                //If the user ran out of time, stop the time, show messageBox, and fill in the ansers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                startButton.Enabled = true;
            }
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - subtrahend == difference.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Select the whole number in the 'sum' NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

                if (answerBox != null)
                {
                 int lengthOfAnser = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnser);
                }
        }
    }
    
}
