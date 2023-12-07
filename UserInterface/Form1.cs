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
    private IPsu _psu;
    private MyMqtt _mqttClient = new MyMqtt();
    private ComboBox _comboBoxPsuTypes;
    private bool isRemoteControlOn = true;
    private bool isOperationStopped = false; 
    private int Xseconds;
    

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
        var defaultPsuType = PsuType.Psu2000; // Set your default PSU type
        _psu = PsuFactory.CreatePsu(defaultPsuType);
    }

    // Initialize the ComboBox with PSU types
    private void InitializeComboBox()
    {
        comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        PopulatePsuTypes();
        Controls.Add(_comboBoxPsuTypes);
    }

    // Populate the ComboBox with PSU types
    private void PopulatePsuTypes()
    {
        comboBox2.Items.AddRange(Enum.GetValues(typeof(PsuType)).Cast<object>().ToArray());
        comboBox2.SelectedIndex = 0; // Set the default selection
    }

    // Subscribe to ComboBox and other events
    private void SubscribeToEvents()
    {
        comboBox2.SelectedIndexChanged += _comboBoxPsuTypes_SelectedIndexChanged;
    }

    // Event handler for ComboBox selection change
    private void _comboBoxPsuTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedPsuType = (PsuType)comboBox2.SelectedItem;
        _psu = PsuFactory.CreatePsu(selectedPsuType);
        DisplayPsuInfo();
    }

    // User-defined method to display PSU information
    private void DisplayPsuInfo()
    {
        var currentVoltage = _psu.GetVoltage() + "V";
        var currentCurrent = _psu.GetCurrent() + "A";

        textBox13.Text = currentVoltage;
        textBox17.Text = currentCurrent;
        textBox5.Text = _psu.GetSerialNumber();
        
        richTextBox2.AppendText("Remote is turned " + (isRemoteControlOn ? "On" : "Off") + "\n");
    }

    // User-defined method to display voltage
    private void DisplayVoltageAndCurrent()
    {
        var currentVoltage = _psu.GetVoltage() + "V";
        var currentCurrent = _psu.GetCurrent() + "A";

        textBox13.Text = currentVoltage;
        textBox17.Text = currentCurrent;
    }
    

    // User-defined method to set voltage
   private void SetVolt()
    {
        button5.Enabled = true;
        // This code allows for "." instead of ","
        var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        
        _psu.SetVoltage(float.Parse(textBox14.Text, NumberStyles.Any, ci));
        DisplayVoltageAndCurrent();
        
        // Check for existing X value
        if (textBox18.Text.Length > 0)
        {
            Xseconds = int.Parse(textBox18.Text);
            int currentXSeconds = Xseconds * 1000;
            // Start the current display thread with the existing X value in seconds
            Thread currentDisplayThread = new Thread(() =>
            {
                DisplayCurrentLoop(currentXSeconds);
            });
            currentDisplayThread.Start();
        }
        else
        {
            // Start the current display thread with default interval in seconds (3 seconds)
            Thread currentDisplayThread = new Thread(() =>
            {
                DisplayCurrentLoop(5000);
            });
            currentDisplayThread.Start();
        }
        
    }


   private void SetX()
   {
       Xseconds = int.Parse(textBox18.Text);
       int currentXSeconds = Xseconds * 1000;

       
       // Start a background thread to update the loop interval for the display
       Thread updateLoopIntervalThread = new Thread(() =>
       {
           DisplayCurrentLoop(currentXSeconds);

       });
       updateLoopIntervalThread.Start();
   }
   
   private void DisplayCurrentLoop(int loopInterval)
   {
       Xseconds = loopInterval;
       var current = _psu.GetCurrent();

       while(!isOperationStopped)
       {
           textBox17.Text = current;
           richTextBox2.AppendText("\n Current: " + current + "A");
           Thread.Sleep(loopInterval);
       }
   }

   
   private void StopOperation()
   {
       // Set voltage to 0
       var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
       ci.NumberFormat.CurrencyDecimalSeparator = ".";
        
       _psu.SetVoltage(0);

       // Stop any ongoing operations, e.g., by setting isOperationStopped flag
       isOperationStopped = true;

       // Update UI accordingly
       richTextBox2.AppendText("\n Operation Stopped");
       DisplayVoltageAndCurrent();
       button5.Enabled = false;
   }

    private void RemoteOnOf()
    {
        if (isRemoteControlOn)
        {
            _psu.DeactivateRemoteControl();
            button1.Text = "Turn Remote on" + "\n (Lock)";
            isRemoteControlOn = false;
        }
        else
        {
            _psu.ActivateRemoteControl();
            button1.Text = "Turn Remote off" + "\n (Unlock)";
            isRemoteControlOn = true;

        }
        richTextBox2.AppendText("Remote is turned " + (isRemoteControlOn ? "On" : "Off") + "\n");
    }




    // ... Other UI event handlers and methods ...
    
    // Example event handler for another button click
    private void button4_Click_1(object sender, EventArgs e)
    {
        SetVolt();
    }
    
    
    private void button5_Click(object sender, EventArgs e)
    {
       SetX();
    }
    

    
    
    string m_PSUID;
    string message;

    
    private void button8_Click(object sender, EventArgs e)
    {
        //connect
        _mqttClient.connectClient();
    }


    private void button3_Click(object sender, EventArgs e)
    {
        //subscribe_button
        _mqttClient.Subscribe(string.Format(textBox7.Text));
    }



    private void button7_Click(object sender, EventArgs e)
    {
        //publish_button
        _mqttClient.publish(string.Format(textBox7.Text), string.Format(textBox6.Text));

    }

    private void textBox18_TextChanged(object sender, EventArgs e)
    {
        //input for X seconds
        
    }

    private void textBox7_TextChanged(object sender, EventArgs e)
    {
        //subscribe_textbox
    }

    private void textBox6_TextChanged(object sender, EventArgs e)
    {
        //publish_textox
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        //connect_textbox
    }



    private void button6_Click(object sender, EventArgs e)
    {
        //stop operation 
        StopOperation();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        RemoteOnOf();
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



    private void textBox14_TextChanged(object sender, EventArgs e)
    {

    }


}


