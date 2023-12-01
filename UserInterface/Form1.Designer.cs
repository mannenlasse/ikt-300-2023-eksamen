
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
            textBox1 = new TextBox();
            button6 = new Button();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(0, 401);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 27);
            textBox4.TabIndex = 6;
            textBox4.Text = "Serial Number";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(107, 401);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(274, 27);
            textBox5.TabIndex = 8;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(465, 16);
            richTextBox2.Margin = new Padding(3, 4, 3, 4);
            richTextBox2.Name = "richTextBox2";
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
            // textBox9
            // 
            textBox9.Location = new Point(6, 100);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(117, 27);
            textBox9.TabIndex = 20;
            textBox9.Text = "Get current";
            textBox9.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(6, 69);
            textBox10.Margin = new Padding(3, 4, 3, 4);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(117, 27);
            textBox10.TabIndex = 21;
            textBox10.Text = "Get voltage";
            textBox10.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(123, 69);
            textBox13.Margin = new Padding(3, 4, 3, 4);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(203, 27);
            textBox13.TabIndex = 22;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(123, 165);
            textBox14.Margin = new Padding(3, 4, 3, 4);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(203, 27);
            textBox14.TabIndex = 23;
            // 
            // textBox17
            // 
            textBox17.Location = new Point(123, 100);
            textBox17.Margin = new Padding(3, 4, 3, 4);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(203, 27);
            textBox17.TabIndex = 26;
            // 
            // textBox18
            // 
            textBox18.Location = new Point(123, 200);
            textBox18.Margin = new Padding(3, 4, 3, 4);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(203, 27);
            textBox18.TabIndex = 27;
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
            // button3
            // 
            button3.Location = new Point(0, 0);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 36;
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
            // button4
            // 
            button4.Location = new Point(8, 165);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(112, 31);
            button4.TabIndex = 31;
            button4.Text = "Set voltage";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(8, 200);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(112, 31);
            button5.TabIndex = 33;
            button5.Text = "Set X";
            button5.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(123, 0);
            comboBox1.Margin = new Padding(1);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(223, 28);
            comboBox1.TabIndex = 34;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 0);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(117, 27);
            textBox1.TabIndex = 35;
            textBox1.Text = "Select PSU";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // button6
            // 
            button6.Location = new Point(29, 281);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 37;
            button6.Text = "on_off";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 435);
            Controls.Add(button6);
            Controls.Add(textBox1);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "PSU Controller";
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
        private TextBox textBox1;
        private Button button6;
    }
}