namespace WinFormsApp1
{
    partial class characterCreationScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            strLabel = new Label();
            dexLabel = new Label();
            intLabel = new Label();
            panel1 = new Panel();
            listBox1 = new ListBox();
            button6 = new Button();
            richTextBox1 = new RichTextBox();
            button5 = new Button();
            label5 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 7);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Character Name:";
            // 
            // strLabel
            // 
            strLabel.AutoSize = true;
            strLabel.Location = new Point(333, 30);
            strLabel.Name = "strLabel";
            strLabel.Size = new Size(64, 15);
            strLabel.TabIndex = 1;
            strLabel.Text = "Strength: 5";
            // 
            // dexLabel
            // 
            dexLabel.AutoSize = true;
            dexLabel.Location = new Point(331, 65);
            dexLabel.Name = "dexLabel";
            dexLabel.Size = new Size(66, 15);
            dexLabel.TabIndex = 2;
            dexLabel.Text = "Dexterity: 5";
            // 
            // intLabel
            // 
            intLabel.AutoSize = true;
            intLabel.Location = new Point(319, 103);
            intLabel.Name = "intLabel";
            intLabel.Size = new Size(83, 15);
            intLabel.TabIndex = 3;
            intLabel.Text = "Intellegence: 5";
            intLabel.Click += label4_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(button5);
            panel1.Location = new Point(3, 136);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(426, 133);
            panel1.TabIndex = 4;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "Mercenary", "Outdoor Expert", "Tactician", "Bastion", "Spellslinger" });
            listBox1.Location = new Point(3, 52);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(115, 79);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button6
            // 
            button6.Location = new Point(3, 30);
            button6.Name = "button6";
            button6.Size = new Size(115, 23);
            button6.TabIndex = 16;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(121, 8);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(299, 122);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "The Spellslinger excells in magical spells and mana regeneration.\n\n20% more maximum starting mana\nSpellcasting speed is increased by 50% of attack speed.";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button5
            // 
            button5.Location = new Point(3, 7);
            button5.Name = "button5";
            button5.Size = new Size(115, 23);
            button5.TabIndex = 15;
            button5.Text = "Create Character";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(147, 116);
            label5.Name = "label5";
            label5.Size = new Size(137, 15);
            label5.TabIndex = 5;
            label5.Text = "Background Information";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(124, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(311, 3);
            label6.Name = "label6";
            label6.Size = new Size(118, 15);
            label6.TabIndex = 10;
            label6.Text = "Points Remaining: 15";
            // 
            // button1
            // 
            button1.Font = new Font("Sylfaen", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(403, 21);
            button1.Name = "button1";
            button1.Size = new Size(24, 33);
            button1.TabIndex = 11;
            button1.Text = "+";
            button1.TextAlign = ContentAlignment.TopLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Sylfaen", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(403, 56);
            button2.Name = "button2";
            button2.Size = new Size(24, 33);
            button2.TabIndex = 12;
            button2.Text = "+";
            button2.TextAlign = ContentAlignment.TopLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Sylfaen", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(403, 94);
            button3.Name = "button3";
            button3.Size = new Size(24, 33);
            button3.TabIndex = 13;
            button3.Text = "+";
            button3.TextAlign = ContentAlignment.TopLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Sylfaen", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(147, 33);
            button4.Name = "button4";
            button4.Size = new Size(118, 24);
            button4.TabIndex = 14;
            button4.Text = "Reset";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // characterCreationScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 273);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(intLabel);
            Controls.Add(dexLabel);
            Controls.Add(strLabel);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "characterCreationScreen";
            Text = "Form3";
            Load += Form3_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label strLabel;
        private Label dexLabel;
        private Label intLabel;
        private Panel panel1;
        private ListBox listBox1;
        private Label label5;
        private TextBox textBox1;
        private Label label6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private RichTextBox richTextBox1;
        private Button button5;
        private Button button6;
    }
}