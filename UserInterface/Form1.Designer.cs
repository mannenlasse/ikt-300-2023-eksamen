
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
            textBox4.Location = new Point(6, 401);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(117, 27);
            textBox4.TabIndex = 6;
            textBox4.Text = "Serial Number";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(123, 401);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(203, 27);
            textBox5.TabIndex = 8;
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
            button1.Location = new Point(683, 271);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(177, 125);
            button1.TabIndex = 19;
            button1.Text = "Turn Remote off \r\n(Unlock)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(6, 100);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.ReadOnly = true;
            textBox9.Size = new Size(117, 27);
            textBox9.TabIndex = 20;
            textBox9.Text = "Get current";
            textBox9.TextAlign = HorizontalAlignment.Center;
            textBox9.TextChanged += textBox9_TextChanged;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(6, 69);
            textBox10.Margin = new Padding(3, 4, 3, 4);
            textBox10.Name = "textBox10";
            textBox10.ReadOnly = true;
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
            textBox14.Location = new Point(8, 169);
            textBox14.Margin = new Padding(3, 4, 3, 4);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(115, 27);
            textBox14.TabIndex = 23;
            textBox14.TextChanged += textBox14_TextChanged;
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
            textBox18.Location = new Point(8, 200);
            textBox18.Margin = new Padding(3, 4, 3, 4);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(114, 27);
            textBox18.TabIndex = 27;
            textBox18.TextChanged += textBox18_TextChanged;
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
            button4.Location = new Point(123, 169);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(201, 27);
            button4.TabIndex = 31;
            button4.Text = "Set voltage";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(123, 200);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(201, 27);
            button5.TabIndex = 33;
            button5.Text = "Set X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(465, 271);
            button6.Name = "button6";
            button6.Size = new Size(176, 125);
            button6.TabIndex = 37;
            button6.Text = "Stop operation";
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
            // button7
            // 
            button7.Location = new Point(123, 286);
            button7.Name = "button7";
            button7.Size = new Size(115, 27);
            button7.TabIndex = 40;
            button7.Text = "publish";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button3
            // 
            button3.Location = new Point(123, 317);
            button3.Name = "button3";
            button3.Size = new Size(115, 32);
            button3.TabIndex = 41;
            button3.Text = "subscribe";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button8
            // 
            button8.Location = new Point(123, 252);
            button8.Name = "button8";
            button8.Size = new Size(115, 28);
            button8.TabIndex = 42;
            button8.Text = "connect";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 252);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(116, 27);
            textBox3.TabIndex = 43;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(8, 286);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(114, 27);
            textBox6.TabIndex = 44;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(6, 320);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(116, 27);
            textBox7.TabIndex = 45;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 435);
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