using psuManager;
using System;
using System.Linq;
using System.Windows.Forms;
using PSUFactory;

namespace ikt300_frivilig_prosjekt
{
    public partial class Form1 : Form
    {
        private PsuFactory psuFactory = new PsuFactory();
        private IPSU psu;

        private ComboBox comboBoxPsuTypes;

        // Constructor
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
            PsuType defaultPsuType = PsuType.PSU3000; // Set your default PSU type
            psu = psuFactory.CreatePSU(defaultPsuType);
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
            PsuType selectedPsuType = (PsuType)comboBoxPsuTypes.SelectedItem;
            psu = psuFactory.CreatePSU(selectedPsuType);
            DisplayPsuInfo();
        }

        // User-defined method to display PSU information
        private void DisplayPsuInfo()
        {
            textBox13.Text = psu.getNominalVolt();
            textBox17.Text = psu.getNominalWatt();
            textBox5.Text = psu.getSerialNumber();
            // ... other UI updates
        }

        // User-defined method to display voltage
        public void DisplayVolt()
        {
            textBox14.Text = psu.getNominalVolt();
        }

        // User-defined method to start displaying output
        public void StartDisplayOutput()
        {
            richTextBox2.Text = $"Current Nominal Volt: {psu.getNominalVolt()}\nCurrent Nominal Watt: {psu.getNominalWatt()}\n";
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
            psu.setVoltage(int.Parse(textBox14.Text));
            DisplayVolt();
        }

        // ... Other UI event handlers and methods ...

        private void button3_Click(object sender, EventArgs e)
        {
            if (psu.remoteOnOf() == 0)
            {
                richTextBox2.Text = "Remote on";
            }
            else
            {
                richTextBox2.Text = "Remote off";
            }
        }
    }
}
