using System;
using System.Globalization;
using System.Windows.Forms;
using PsuController;
using MyMQTTClient;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace UserInterface;

public partial class Form1 : Form
{

    public Form1()
    {
        InitializeComponent();
        InitializePowerSupply();
        InitializeComboBox();
        DisplayPsuInfo();
        SubscribeToEvents();
    }

    
    
    
    // Initialize the power supply
    private void InitializePowerSupply()
    {
        // Create an instance of PSU using the factory
        // Set your default PSU type
     
    }

    
    
    
    
    // Initialize the ComboBox with PSU types
    private void InitializeComboBox()
    {

    }

    
    
    
    
    // Populate the ComboBox with PSU types
    private void PopulatePsuTypes()
    {

    }
    
    
    
    
    
    // Subscribe to ComboBox and other events
    private void SubscribeToEvents()
    {

   }
    
    
    
    
    // Event handler for ComboBox selection change
    
    private void _comboBoxPsuTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //select psu from drop-down
    }

    
    
    
    
    // User-defined method to display PSU information
    private void DisplayPsuInfo()
    {
        //display current serial number
    }

    
    
    
    // User-defined method to display voltage
    public void DisplayVoltageAndCurrent()
    {

    }

    
    
    
    // User-defined method to start displaying output
    public void StartDisplayOutput()
    {

    }

    
    
    
    // ... Other UI event handlers and methods ...

    // Example event handler for a button click
    private void button2_Click(object sender, EventArgs e)
    {
        //refresh button showing StartDisplayOutput and display voltage n current
    }

    
    
    
    // Example event handler for another button click
    private void button4_Click_1(object sender, EventArgs e)
    {
        //set voltage 
        
    }



    string m_PSUID;
    string message;
    
    


    private void button6_Click(object sender, EventArgs e)
    {
        //on_off button
    }



    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox9_TextChanged(object sender, EventArgs e)
    {

    }

    private void button5_Click(object sender, EventArgs e)
    {

    }

    private void textBox14_TextChanged(object sender, EventArgs e)
    {

    }
}


