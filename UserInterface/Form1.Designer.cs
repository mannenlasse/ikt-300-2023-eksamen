
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
            splitter1 = new Splitter();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            comboBox2 = new ComboBox();
            textBox2 = new TextBox();
            button7 = new Button();
            button3 = new Button();
            button8 = new Button();
            textBox3 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(13, 822);
            textBox4.Margin = new Padding(6, 8, 6, 8);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(244, 47);
            textBox4.TabIndex = 6;
            textBox4.Text = "Serial Number";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(261, 822);
            textBox5.Margin = new Padding(6, 8, 6, 8);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(427, 47);
            textBox5.TabIndex = 8;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(988, 33);
            richTextBox2.Margin = new Padding(6, 8, 6, 8);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(835, 424);
            richTextBox2.TabIndex = 18;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(984, 664);
            button1.Margin = new Padding(6, 8, 6, 8);
            button1.Name = "button1";
            button1.Size = new Size(839, 221);
            button1.TabIndex = 19;
            button1.Text = "Power On/Off";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(13, 205);
            textBox9.Margin = new Padding(6, 8, 6, 8);
            textBox9.Name = "textBox9";
            textBox9.ReadOnly = true;
            textBox9.Size = new Size(244, 47);
            textBox9.TabIndex = 20;
            textBox9.Text = "Get current";
            textBox9.TextAlign = HorizontalAlignment.Center;
            textBox9.TextChanged += textBox9_TextChanged;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(13, 141);
            textBox10.Margin = new Padding(6, 8, 6, 8);
            textBox10.Name = "textBox10";
            textBox10.ReadOnly = true;
            textBox10.Size = new Size(244, 47);
            textBox10.TabIndex = 21;
            textBox10.Text = "Get voltage";
            textBox10.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(261, 141);
            textBox13.Margin = new Padding(6, 8, 6, 8);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(427, 47);
            textBox13.TabIndex = 22;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(17, 346);
            textBox14.Margin = new Padding(6, 8, 6, 8);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(240, 47);
            textBox14.TabIndex = 23;
            textBox14.TextChanged += textBox14_TextChanged;
            // 
            // textBox17
            // 
            textBox17.Location = new Point(261, 205);
            textBox17.Margin = new Padding(6, 8, 6, 8);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(427, 47);
            textBox17.TabIndex = 26;
            // 
            // textBox18
            // 
            textBox18.Location = new Point(17, 410);
            textBox18.Margin = new Padding(6, 8, 6, 8);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(238, 47);
            textBox18.TabIndex = 27;
            // 
            // button2
            // 
            button2.Location = new Point(1422, 482);
            button2.Margin = new Padding(6, 8, 6, 8);
            button2.Name = "button2";
            button2.Size = new Size(404, 154);
            button2.TabIndex = 28;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(6, 8, 6, 8);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(6, 892);
            splitter1.TabIndex = 30;
            splitter1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(261, 346);
            button4.Margin = new Padding(6, 8, 6, 8);
            button4.Name = "button4";
            button4.Size = new Size(427, 55);
            button4.TabIndex = 31;
            button4.Text = "Set voltage";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(261, 410);
            button5.Margin = new Padding(6, 8, 6, 8);
            button5.Name = "button5";
            button5.Size = new Size(427, 55);
            button5.TabIndex = 33;
            button5.Text = "Set X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(988, 482);
            button6.Margin = new Padding(6, 6, 6, 6);
            button6.Name = "button6";
            button6.Size = new Size(404, 154);
            button6.TabIndex = 37;
            button6.Text = "Unlock / Lock";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(261, -2);
            comboBox2.Margin = new Padding(2, 2, 2, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(427, 49);
            comboBox2.TabIndex = 38;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(17, 0);
            textBox2.Margin = new Padding(2, 2, 2, 2);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(238, 47);
            textBox2.TabIndex = 39;
            textBox2.Text = "Select PSU Type";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button7
            // 
            button7.Location = new Point(17, 586);
            button7.Margin = new Padding(6, 6, 6, 6);
            button7.Name = "button7";
            button7.Size = new Size(244, 55);
            button7.TabIndex = 40;
            button7.Text = "publish";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button3
            // 
            button3.Location = new Point(23, 666);
            button3.Margin = new Padding(6, 6, 6, 6);
            button3.Name = "button3";
            button3.Size = new Size(236, 66);
            button3.TabIndex = 41;
            button3.Text = "subscribe";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button8
            // 
            button8.Location = new Point(13, 517);
            button8.Margin = new Padding(6, 6, 6, 6);
            button8.Name = "button8";
            button8.Size = new Size(249, 57);
            button8.TabIndex = 42;
            button8.Text = "connect";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(274, 517);
            textBox3.Margin = new Padding(6, 6, 6, 6);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(261, 47);
            textBox3.TabIndex = 43;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(274, 586);
            textBox6.Margin = new Padding(6, 6, 6, 6);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(261, 47);
            textBox6.TabIndex = 44;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(274, 672);
            textBox7.Margin = new Padding(6, 6, 6, 6);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(261, 47);
            textBox7.TabIndex = 45;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1857, 892);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox3);
            Controls.Add(button8);
            Controls.Add(button3);
            Controls.Add(button7);
            Controls.Add(textBox2);
            Controls.Add(comboBox2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(splitter1);
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
            Margin = new Padding(6, 8, 6, 8);
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
        private ComboBox comboBox2;
        private TextBox textBox2;
        private Button button7;
        private Button button8;
        private TextBox textBox3;
        private TextBox textBox6;
        private TextBox textBox7;
    }
}