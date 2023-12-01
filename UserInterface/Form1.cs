using System;
using System.Windows.Forms;
using PsuManager;

namespace UserInterface;

public partial class Form1 : Form
{
    private IPsu _psu;

    private ComboBox comboBoxPsuTypes;

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
        comboBoxPsuTypes = new ComboBox();
        comboBoxPsuTypes.Location = new System.Drawing.Point(12, 12); // Set appropriate location
        comboBoxPsuTypes.DropDownStyle = ComboBoxStyle.DropDownList;
        PopulatePsuTypes();
        Controls.Add(comboBoxPsuTypes);
    }

    // Populate the ComboBox with PSU types
    private void PopulatePsuTypes()
    {
        comboBoxPsuTypes.Items.AddRange(Enum.GetValues(typeof(PsuType)).Cast<object>().ToArray());
        comboBoxPsuTypes.SelectedIndex = 0; // Set the default selection
    }

    // Subscribe to ComboBox and other events
    private void SubscribeToEvents()
    {
        comboBoxPsuTypes.SelectedIndexChanged += comboBoxPsuTypes_SelectedIndexChanged;
    }

    // Event handler for ComboBox selection change
    private void comboBoxPsuTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedPsuType = (PsuType)comboBoxPsuTypes.SelectedItem;
        _psu = PsuFactory.CreatePsu(selectedPsuType);
        DisplayPsuInfo();
    }

    // User-defined method to display PSU information
    private void DisplayPsuInfo()
    {
        textBox13.Text = _psu.GetVoltage();
        textBox5.Text = _psu.GetVoltage();
    }

    // User-defined method to display voltage
    public void DisplayVolt()
    {
        textBox14.Text = _psu.GetVoltage();
    }

    // User-defined method to start displaying output
    public void StartDisplayOutput()
    {
        richTextBox2.Text = $"Current volt(v): {_psu.GetVoltage()}";
    }

    // ... Other UI event handlers and methods ...

    // Example event handler for a button click
    private void button2_Click(object sender, EventArgs e)
    {
        DisplayVolt();
        StartDisplayOutput();
    }

    // Example event handler for another button click
    private void button4_Click_1(object sender, EventArgs e)
    {
        _psu.SetVoltage(int.Parse(textBox14.Text));
        DisplayVolt();
    }
}