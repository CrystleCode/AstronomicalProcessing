using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstronomicalProcessing
{
    public partial class Form1 : Form
    {
        // Defining the array
        int[] hours = new int[24] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Adding random data to the array and then clicking a button to print it
            RandomizeData();
            btnPrintAllData_Click(sender, e);
        }
        private void RandomizeData()
        {
            // defining a new instance of random so we can use the random function.
            Random randy = new Random();
            // using a for loop to add random data to the array.
            for (int i = 0; i < hours.Length; i++)
            {
                int y;
                y = randy.Next(10, 100);
                hours[i] = y;
            }
        }


        private void btnHourData_Click(object sender, EventArgs e)
        {
            // giving 'i' a non-sensical value so the 'try catch' block works. 
            int i = 200;
            try
            {
                // parsing the input to an int32. 
                i = Int32.Parse(txtSearchHourData.Text);
                lbxHourData.Items.Add("Hour " + i.ToString() + ": " + hours[i].ToString());
            }
            catch (Exception)
            {
                // catching the exception and telling the user that they have made an error
                MessageBox.Show("Invalid integer input. Please input a valid integer.");
            }
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            // inputHour means the hour they are going to edit
            int inputHour = 0;
            // inputData means the number they are going to give the hour
            int inputData = 0;

            // using a try catch block to see if the user made an error
            try
            {
                inputHour = Int32.Parse(txtInputHourData.Text);
                inputData = Int32.Parse(txtEditData.Text);
                hours[inputHour] = inputData;
                MessageBox.Show("Hour " + inputHour.ToString() + " now shows " + inputData.ToString() + ".");               
            }
            catch (Exception)
            {
                // catching the exception and giving the user an error message
                MessageBox.Show("Invalid integer input. Please input a valid integer.");
            }

            

        }

        private void printAllData()
        {
            // clearing what's inside the listbox and using a for loop to print out all the data
            lbxHourData.Items.Clear();
            for (int i = 0; i < hours.Length; i++)
            {
                lbxHourData.Items.Add("Hour " + i + ": " + hours[i]);
            }
        }

        private void btnPrintAllData_Click(object sender, EventArgs e)
        {
            // printing out all the data using a for loop, except this time what's inside isn't being cleared.
            for (int i = 0; i < hours.Length; i++)
            {
                lbxHourData.Items.Add("Hour " + i + ": " + hours[i]);
            }
        }

        private void btnClearAllData_Click(object sender, EventArgs e)
        {
            // a button that clears everything inside the listbox. 
            lbxHourData.Items.Clear();
        }

        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            // A bubble sort, doesn't correctly sort data. 
            int arrayLen = hours.Length;

            for (int i = 0; i < arrayLen - 2; i++)
            {
                for (int j = 0; j < arrayLen - 2; j++)
                {
                    if (hours[j] > hours[j + 1])
                    {
                        int temp = hours[j];
                        hours[j] = hours[j + 1];
                        hours[j + 1] = temp;
                    }

                }
            }
            printAllData();

        }

        private void btnInsertRandomData_Click(object sender, EventArgs e)
        {
            // Clears the list box, randomizes the data then prints out the new data. 
            lbxHourData.Items.Clear();
            RandomizeData();
            btnPrintAllData_Click(sender,e );
        }
    }
}
