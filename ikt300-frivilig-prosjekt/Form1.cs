using psuManager;
using System;
using System.Windows.Forms;
using PSUFactory;

namespace ikt300_frivilig_prosjekt
{
    public partial class Form1 : Form
    {

        private psuFactory factory = new psuFactory();
        private IPSU psu = new PSU();

        public Form1()
        {
            IPSU psu = factory.CreatePSU("PSU3000");
            InitializeComponent();
            onStartUp();
        }

        public void onStartUp()
        {
            displayVolt();
            displayWatt();
            start_displayOutput();
            displaySerialNumber();
        }

        private void DisplayPsuInfo()
        {
            // Use psu object to display information in the UI
            textBox13.Text = psu.getNominalVolt();
            textBox17.Text = psu.getNominalWatt();
            textBox5.Text = psu.getSerialNumber();
            // ... other UI updates
        }



        //USER DEFINED FUNCTIONS
        public void displayVolt()
        {
            //TaxAdded
            textBox14.Text = psu.getNominalVolt();
        }


        public void displayWatt()
        {
            //TaxAdded
            textBox13.Text = psu.getNominalWatt();
        }

        public void start_displayOutput()
        {
            //TaxAdded
            richTextBox2.Text = "Current Nominal Volt: " + psu.getNominalVolt() + "\n" + "Current Nominal Watt: " + psu.getNominalWatt()
               + "\n";


        }





        public void displaySerialNumber()
        {
            //TaxAdded
            textBox5.Text = psu.getSerialNumber();
        }













        ///////////////////


        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayVolt();
            start_displayOutput();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (psu.remoteOnOf() == 0)
            {
                richTextBox2.Text = "Remote on";
            }
            else
            {
                richTextBox2.Text = "Remote of";

            }
        }




        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click_1(object sender, EventArgs e)
        {

            psu.setVoltage(int.Parse(textBox18.Text));

            displayVolt();

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}