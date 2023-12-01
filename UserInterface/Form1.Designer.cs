
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
            textBox5 = new TextBox();
            richTextBox2 = new RichTextBox();
            button1 = new Button();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            textBox17 = new TextBox();
            textBox18 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            splitter1 = new Splitter();
            button4 = new Button();
            button5 = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(0, 823);
            textBox4.Margin = new Padding(7, 8, 7, 8);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(237, 47);
            textBox4.TabIndex = 6;
            textBox4.Text = "Serial Number";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(228, 823);
            textBox5.Margin = new Padding(7, 8, 7, 8);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(577, 47);
            textBox5.TabIndex = 8;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(988, 33);
            richTextBox2.Margin = new Padding(7, 8, 7, 8);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(835, 425);
            richTextBox2.TabIndex = 18;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(988, 651);
            button1.Margin = new Padding(7, 8, 7, 8);
            button1.Name = "button1";
            button1.Size = new Size(840, 221);
            button1.TabIndex = 19;
            button1.Text = "Power On/Off";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(11, 204);
            textBox9.Margin = new Padding(7, 8, 7, 8);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(244, 47);
            textBox9.TabIndex = 20;
            textBox9.Text = "Watt";
            textBox9.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(11, 141);
            textBox10.Margin = new Padding(7, 8, 7, 8);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(244, 47);
            textBox10.TabIndex = 21;
            textBox10.Text = "Volt";
            textBox10.TextAlign = HorizontalAlignment.Center;
            textBox10.TextChanged += textBox10_TextChanged;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(262, 141);
            textBox13.Margin = new Padding(7, 8, 7, 8);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(426, 47);
            textBox13.TabIndex = 22;
            textBox13.TextChanged += textBox13_TextChanged;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(262, 340);
            textBox14.Margin = new Padding(7, 8, 7, 8);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(426, 47);
            textBox14.TabIndex = 23;
            textBox14.TextChanged += textBox14_TextChanged;
            // 
            // textBox17
            // 
            textBox17.Location = new Point(262, 204);
            textBox17.Margin = new Padding(7, 8, 7, 8);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(426, 47);
            textBox17.TabIndex = 26;
            // 
            // textBox18
            // 
            textBox18.Location = new Point(262, 411);
            textBox18.Margin = new Padding(7, 8, 7, 8);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(426, 47);
            textBox18.TabIndex = 27;
            textBox18.TextChanged += textBox18_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(1420, 482);
            button2.Margin = new Padding(7, 8, 7, 8);
            button2.Name = "button2";
            button2.Size = new Size(403, 153);
            button2.TabIndex = 28;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(988, 482);
            button3.Margin = new Padding(7, 8, 7, 8);
            button3.Name = "button3";
            button3.Size = new Size(426, 153);
            button3.TabIndex = 29;
            button3.Text = "Unlock / lock";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(7, 8, 7, 8);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(7, 886);
            splitter1.TabIndex = 30;
            splitter1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(16, 340);
            button4.Margin = new Padding(7, 8, 7, 8);
            button4.Name = "button4";
            button4.Size = new Size(239, 47);
            button4.TabIndex = 31;
            button4.Text = "SetVolt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(16, 411);
            button5.Margin = new Padding(7, 8, 7, 8);
            button5.Name = "button5";
            button5.Size = new Size(239, 47);
            button5.TabIndex = 33;
            button5.Text = "Set X";
            button5.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(0, -3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(471, 49);
            comboBox1.TabIndex = 34;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1858, 886);
            Controls.Add(comboBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(splitter1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox18);
            Controls.Add(textBox17);
            Controls.Add(textBox14);
            Controls.Add(textBox13);
            Controls.Add(textBox10);
            Controls.Add(textBox9);
            Controls.Add(button1);
            Controls.Add(richTextBox2);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Margin = new Padding(7, 8, 7, 8);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox4;
        private TextBox textBox5;
        private RichTextBox richTextBox2;
        private Button button1;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox17;
        private TextBox textBox18;
        private Button button2;
        private Button button3;
        private Splitter splitter1;
        private Button button4;
        private Button button5;
        private ComboBox comboBox1;
    }
}