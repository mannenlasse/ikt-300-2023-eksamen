using System;
using System.Globalization;
using System.Windows.Forms;
using PsuManager;

namespace UserInterface;

public partial class Form1 : Form
{
    private IPsu _psu;

    private ComboBox _comboBoxPsuTypes;

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
        var currentCurrent = _psu.GetVoltage() + "A";

        textBox13.Text = currentVoltage;
        textBox17.Text = currentCurrent;
        textBox5.Text = _psu.GetSerialNumber();
    }

    // User-defined method to display voltage
    public void DisplayVoltageAndCurrent()
    {
        var currentVoltage = _psu.GetVoltage() + "V";
        var currentCurrent = _psu.GetVoltage() + "A";

        textBox13.Text = currentVoltage;
        textBox17.Text = currentCurrent;
    }

    // User-defined method to start displaying output
    public void StartDisplayOutput()
    {
        var currentVoltage = "Current voltage: " + _psu.GetVoltage() + "V";
        var currentCurrent = "Current current: " + _psu.GetCurrent() + "A";

        richTextBox2.Text = currentVoltage + "\n" + currentCurrent;
    }

    // ... Other UI event handlers and methods ...

    // Example event handler for a button click
    private void button2_Click(object sender, EventArgs e)
    {
        DisplayVoltageAndCurrent();
        StartDisplayOutput();
    }

    // Example event handler for another button click
    private void button4_Click_1(object sender, EventArgs e)
    {
        // This code allows for "." instead of ","
        var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";

        _psu.SetVoltage(float.Parse(textBox14.Text, NumberStyles.Any, ci));
        DisplayVoltageAndCurrent();
    }

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

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void publish_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {

    }
}


