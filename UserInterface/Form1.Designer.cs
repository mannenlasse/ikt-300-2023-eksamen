
namespace UserInterface
{
    public partial class Form1
    {


        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /*
                //USER DEFINED FUNCTIONS
        private void displayOutput()
        {
            textBox14.Text = Program.displayVolt();
        }

         */



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox4 = new TextBox();
            textBox5_view_current_serial_number = new TextBox();
            richTextBox2 = new RichTextBox();
            button1 = new Button();
            textBox13_Get_Voltage = new TextBox();
            textBox14_set_voltage = new TextBox();
            textBox17_getCurrent = new TextBox();
            textBox18_set_x = new TextBox();
            button2 = new Button();
            splitter1 = new Splitter();
            SetVoltage = new Button();
            setX = new Button();
            button6 = new Button();
            comboBox2 = new ComboBox();
            textBox2 = new TextBox();
            GetVoltageButton = new Button();
            GetCurrent = new Button();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 401);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(117, 27);
            textBox4.TabIndex = 6;
            textBox4.Text = "Serial Number";
            // 
            // textBox5_view_current_serial_number
            // 
            textBox5_view_current_serial_number.Location = new Point(123, 401);
            textBox5_view_current_serial_number.Margin = new Padding(3, 4, 3, 4);
            textBox5_view_current_serial_number.Name = "textBox5_view_current_serial_number";
            textBox5_view_current_serial_number.Size = new Size(203, 27);
            textBox5_view_current_serial_number.TabIndex = 8;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(465, 16);
            richTextBox2.Margin = new Padding(3, 4, 3, 4);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(395, 209);
            richTextBox2.TabIndex = 18;
            richTextBox2.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(463, 324);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(395, 108);
            button1.TabIndex = 19;
            button1.Text = "Power On/Off";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox13_Get_Voltage
            // 
            textBox13_Get_Voltage.Location = new Point(123, 69);
            textBox13_Get_Voltage.Margin = new Padding(3, 4, 3, 4);
            textBox13_Get_Voltage.Name = "textBox13_Get_Voltage";
            textBox13_Get_Voltage.Size = new Size(203, 27);
            textBox13_Get_Voltage.TabIndex = 22;
            // 
            // textBox14_set_voltage
            // 
            textBox14_set_voltage.Location = new Point(8, 169);
            textBox14_set_voltage.Margin = new Padding(3, 4, 3, 4);
            textBox14_set_voltage.Name = "textBox14_set_voltage";
            textBox14_set_voltage.Size = new Size(115, 27);
            textBox14_set_voltage.TabIndex = 23;
            textBox14_set_voltage.TextChanged += textBox14_TextChanged;
            // 
            // textBox17_getCurrent
            // 
            textBox17_getCurrent.Location = new Point(123, 100);
            textBox17_getCurrent.Margin = new Padding(3, 4, 3, 4);
            textBox17_getCurrent.Name = "textBox17_getCurrent";
            textBox17_getCurrent.Size = new Size(203, 27);
            textBox17_getCurrent.TabIndex = 26;
            // 
            // textBox18_set_x
            // 
            textBox18_set_x.Location = new Point(8, 200);
            textBox18_set_x.Margin = new Padding(3, 4, 3, 4);
            textBox18_set_x.Name = "textBox18_set_x";
            textBox18_set_x.Size = new Size(114, 27);
            textBox18_set_x.TabIndex = 27;
            // 
            // button2
            // 
            button2.Location = new Point(669, 235);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(190, 75);
            button2.TabIndex = 28;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(3, 4, 3, 4);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 435);
            splitter1.TabIndex = 30;
            splitter1.TabStop = false;
            // 
            // SetVoltage
            // 
            SetVoltage.Location = new Point(123, 169);
            SetVoltage.Margin = new Padding(3, 4, 3, 4);
            SetVoltage.Name = "SetVoltage";
            SetVoltage.Size = new Size(201, 27);
            SetVoltage.TabIndex = 31;
            SetVoltage.Text = "Set voltage";
            SetVoltage.UseVisualStyleBackColor = true;
            SetVoltage.Click += button4_Click_1;
            // 
            // setX
            // 
            setX.Location = new Point(123, 200);
            setX.Margin = new Padding(3, 4, 3, 4);
            setX.Name = "setX";
            setX.Size = new Size(201, 27);
            setX.TabIndex = 33;
            setX.Text = "Set X";
            setX.UseVisualStyleBackColor = true;
            setX.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(465, 235);
            button6.Name = "button6";
            button6.Size = new Size(190, 75);
            button6.TabIndex = 37;
            button6.Text = "Unlock / Lock";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(123, -1);
            comboBox2.Margin = new Padding(1);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(203, 28);
            comboBox2.TabIndex = 38;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(8, 0);
            textBox2.Margin = new Padding(1);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(114, 27);
            textBox2.TabIndex = 39;
            textBox2.Text = "Select PSU Type";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // GetVoltageButton
            // 
            GetVoltageButton.Location = new Point(9, 69);
            GetVoltageButton.Name = "GetVoltageButton";
            GetVoltageButton.Size = new Size(98, 29);
            GetVoltageButton.TabIndex = 40;
            GetVoltageButton.Text = "GetVoltageButton";
            GetVoltageButton.UseVisualStyleBackColor = true;
            GetVoltageButton.Click += GetVoltage_Click;
            // 
            // GetCurrent
            // 
            GetCurrent.Location = new Point(9, 104);
            GetCurrent.Name = "GetCurrent";
            GetCurrent.Size = new Size(94, 29);
            GetCurrent.TabIndex = 41;
            GetCurrent.Text = "GetCurrent";
            GetCurrent.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 435);
            Controls.Add(GetCurrent);
            Controls.Add(GetVoltageButton);
            Controls.Add(textBox2);
            Controls.Add(comboBox2);
            Controls.Add(button6);
            Controls.Add(setX);
            Controls.Add(SetVoltage);
            Controls.Add(splitter1);
            Controls.Add(button2);
            Controls.Add(textBox18_set_x);
            Controls.Add(textBox17_getCurrent);
            Controls.Add(textBox14_set_voltage);
            Controls.Add(textBox13_Get_Voltage);
            Controls.Add(button1);
            Controls.Add(richTextBox2);
            Controls.Add(textBox5_view_current_serial_number);
            Controls.Add(textBox4);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "PSU Controller";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox4;
        private TextBox textBox5_view_current_serial_number;
        private RichTextBox richTextBox2;
        private Button button1;
        private TextBox textBox13_Get_Voltage;
        private TextBox textBox14_set_voltage;
        private TextBox textBox17_getCurrent;
        private TextBox textBox18_set_x;
        private Button button2;
        private Splitter splitter1;
        private Button SetVoltage;
        private Button setX;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button button6;
        private ComboBox comboBox2;
        private TextBox textBox2;
        private Button GetVoltageButton;
        private Button GetCurrent;
    }
}