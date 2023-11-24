
namespace ikt300_frivilig_prosjekt
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            richTextBox2 = new RichTextBox();
            button1 = new Button();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            textBox15 = new TextBox();
            textBox16 = new TextBox();
            textBox17 = new TextBox();
            textBox18 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            splitter1 = new Splitter();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 296);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "Farbricant";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(33, 258);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 27);
            textBox2.TabIndex = 2;
            textBox2.Text = "Device Type";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(33, 335);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(114, 27);
            textBox3.TabIndex = 4;
            textBox3.Text = "Article Number";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(33, 373);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 27);
            textBox4.TabIndex = 6;
            textBox4.Text = "Serial Number";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(154, 373);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(274, 27);
            textBox5.TabIndex = 8;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(154, 335);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(274, 27);
            textBox6.TabIndex = 9;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(154, 258);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(274, 27);
            textBox7.TabIndex = 11;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(154, 296);
            textBox8.Margin = new Padding(3, 4, 3, 4);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(274, 27);
            textBox8.TabIndex = 10;
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(586, 258);
            textBox11.Margin = new Padding(3, 4, 3, 4);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(274, 27);
            textBox11.TabIndex = 15;
            textBox11.TextChanged += textBox11_TextChanged;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(465, 258);
            textBox12.Margin = new Padding(3, 4, 3, 4);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(114, 27);
            textBox12.TabIndex = 14;
            textBox12.Text = "Software Version";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(465, 16);
            richTextBox2.Margin = new Padding(3, 4, 3, 4);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(395, 209);
            richTextBox2.TabIndex = 18;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(465, 296);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(395, 108);
            button1.TabIndex = 19;
            button1.Text = "Power On/Off";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(40, 16);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(114, 27);
            textBox9.TabIndex = 20;
            textBox9.Text = "Watt";
            textBox9.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(40, 148);
            textBox10.Margin = new Padding(3, 4, 3, 4);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(114, 27);
            textBox10.TabIndex = 21;
            textBox10.Text = "Volt";
            textBox10.TextAlign = HorizontalAlignment.Center;
            textBox10.TextChanged += textBox10_TextChanged;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(176, 16);
            textBox13.Margin = new Padding(3, 4, 3, 4);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(114, 27);
            textBox13.TabIndex = 22;
            textBox13.TextChanged += textBox13_TextChanged;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(176, 148);
            textBox14.Margin = new Padding(3, 4, 3, 4);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(114, 27);
            textBox14.TabIndex = 23;
            textBox14.TextChanged += textBox14_TextChanged;
            // 
            // textBox15
            // 
            textBox15.Location = new Point(40, 55);
            textBox15.Margin = new Padding(3, 4, 3, 4);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(114, 27);
            textBox15.TabIndex = 24;
            textBox15.Text = "Set Watt";
            textBox15.TextAlign = HorizontalAlignment.Center;
            textBox15.TextChanged += textBox15_TextChanged;
            // 
            // textBox16
            // 
            textBox16.Location = new Point(40, 187);
            textBox16.Margin = new Padding(3, 4, 3, 4);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(114, 27);
            textBox16.TabIndex = 25;
            textBox16.Text = "Set Volt";
            textBox16.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            textBox17.Location = new Point(176, 55);
            textBox17.Margin = new Padding(3, 4, 3, 4);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(114, 27);
            textBox17.TabIndex = 26;
            // 
            // textBox18
            // 
            textBox18.Location = new Point(176, 187);
            textBox18.Margin = new Padding(3, 4, 3, 4);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(114, 27);
            textBox18.TabIndex = 27;
            textBox18.TextChanged += textBox18_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(314, 16);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(114, 75);
            button2.TabIndex = 28;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(314, 142);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(114, 75);
            button3.TabIndex = 29;
            button3.Text = "Remote Control On/Off";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(3, 4, 3, 4);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 432);
            splitter1.TabIndex = 30;
            splitter1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(176, 105);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(114, 35);
            button4.TabIndex = 31;
            button4.Text = "SetVolt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 432);
            Controls.Add(button4);
            Controls.Add(splitter1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox18);
            Controls.Add(textBox17);
            Controls.Add(textBox16);
            Controls.Add(textBox15);
            Controls.Add(textBox14);
            Controls.Add(textBox13);
            Controls.Add(textBox10);
            Controls.Add(textBox9);
            Controls.Add(button1);
            Controls.Add(richTextBox2);
            Controls.Add(textBox11);
            Controls.Add(textBox12);
            Controls.Add(textBox7);
            Controls.Add(textBox8);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox11;
        private TextBox textBox12;
        private RichTextBox richTextBox2;
        private Button button1;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private Button button2;
        private Button button3;
        private Splitter splitter1;
        private Button button4;
    }
}