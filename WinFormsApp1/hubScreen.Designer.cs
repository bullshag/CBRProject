namespace WinFormsApp1
{
    partial class hubScreen
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
            components = new System.ComponentModel.Container();
            characterPanel_noChar = new Panel();
            label1 = new Label();
            button1 = new Button();
            characterPanel_foundChar = new Panel();
            levelupButton = new Button();
            statsEXPBar = new ProgressBar();
            statsEnergyBar = new ProgressBar();
            statsManaBar = new ProgressBar();
            statsHPBar = new ProgressBar();
            statsEXPLabel = new Label();
            statsEnergyLabel = new Label();
            statsManaLabel = new Label();
            statsHPLabel = new Label();
            label5 = new Label();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            listBox1 = new ListBox();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            currentLocationLabel = new Label();
            textBox1 = new TextBox();
            button6 = new Button();
            chatPanel = new Panel();
            checkBox1 = new CheckBox();
            button7 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            characterPanel_noChar.SuspendLayout();
            characterPanel_foundChar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            chatPanel.SuspendLayout();
            SuspendLayout();
            // 
            // characterPanel_noChar
            // 
            characterPanel_noChar.BackColor = SystemColors.ButtonShadow;
            characterPanel_noChar.BorderStyle = BorderStyle.FixedSingle;
            characterPanel_noChar.Controls.Add(label1);
            characterPanel_noChar.Controls.Add(button1);
            characterPanel_noChar.Location = new Point(10, 9);
            characterPanel_noChar.Margin = new Padding(3, 2, 3, 2);
            characterPanel_noChar.Name = "characterPanel_noChar";
            characterPanel_noChar.Size = new Size(281, 408);
            characterPanel_noChar.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(15, 136);
            label1.Name = "label1";
            label1.Size = new Size(243, 32);
            label1.TabIndex = 1;
            label1.Text = "No characters found!";
            // 
            // button1
            // 
            button1.Location = new Point(67, 369);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(131, 32);
            button1.TabIndex = 0;
            button1.Text = "Create Character";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // characterPanel_foundChar
            // 
            characterPanel_foundChar.BackColor = SystemColors.ButtonShadow;
            characterPanel_foundChar.BorderStyle = BorderStyle.FixedSingle;
            characterPanel_foundChar.Controls.Add(levelupButton);
            characterPanel_foundChar.Controls.Add(statsEXPBar);
            characterPanel_foundChar.Controls.Add(statsEnergyBar);
            characterPanel_foundChar.Controls.Add(statsManaBar);
            characterPanel_foundChar.Controls.Add(statsHPBar);
            characterPanel_foundChar.Controls.Add(statsEXPLabel);
            characterPanel_foundChar.Controls.Add(statsEnergyLabel);
            characterPanel_foundChar.Controls.Add(statsManaLabel);
            characterPanel_foundChar.Controls.Add(statsHPLabel);
            characterPanel_foundChar.Controls.Add(label5);
            characterPanel_foundChar.Controls.Add(button5);
            characterPanel_foundChar.Controls.Add(button4);
            characterPanel_foundChar.Controls.Add(button3);
            characterPanel_foundChar.Controls.Add(listBox1);
            characterPanel_foundChar.Controls.Add(button2);
            characterPanel_foundChar.Location = new Point(6, 7);
            characterPanel_foundChar.Margin = new Padding(3, 2, 3, 2);
            characterPanel_foundChar.Name = "characterPanel_foundChar";
            characterPanel_foundChar.Size = new Size(281, 407);
            characterPanel_foundChar.TabIndex = 1;
            characterPanel_foundChar.Visible = false;
            // 
            // levelupButton
            // 
            levelupButton.Location = new Point(27, 265);
            levelupButton.Name = "levelupButton";
            levelupButton.Size = new Size(235, 23);
            levelupButton.TabIndex = 14;
            levelupButton.Text = "Level  Up!";
            levelupButton.UseVisualStyleBackColor = true;
            levelupButton.Visible = false;
            levelupButton.Click += levelupButton_Click;
            // 
            // statsEXPBar
            // 
            statsEXPBar.Location = new Point(27, 265);
            statsEXPBar.Name = "statsEXPBar";
            statsEXPBar.Size = new Size(235, 20);
            statsEXPBar.TabIndex = 13;
            statsEXPBar.Click += progressBar4_Click;
            // 
            // statsEnergyBar
            // 
            statsEnergyBar.Location = new Point(130, 193);
            statsEnergyBar.Name = "statsEnergyBar";
            statsEnergyBar.Size = new Size(132, 20);
            statsEnergyBar.TabIndex = 12;
            // 
            // statsManaBar
            // 
            statsManaBar.Location = new Point(130, 170);
            statsManaBar.Name = "statsManaBar";
            statsManaBar.Size = new Size(132, 20);
            statsManaBar.TabIndex = 11;
            // 
            // statsHPBar
            // 
            statsHPBar.Location = new Point(130, 147);
            statsHPBar.Name = "statsHPBar";
            statsHPBar.Size = new Size(132, 20);
            statsHPBar.TabIndex = 10;
            // 
            // statsEXPLabel
            // 
            statsEXPLabel.AutoSize = true;
            statsEXPLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            statsEXPLabel.Location = new Point(82, 242);
            statsEXPLabel.Name = "statsEXPLabel";
            statsEXPLabel.Size = new Size(103, 20);
            statsEXPLabel.TabIndex = 9;
            statsEXPLabel.Text = "EXP: XXX/XXX";
            statsEXPLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statsEnergyLabel
            // 
            statsEnergyLabel.AutoSize = true;
            statsEnergyLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            statsEnergyLabel.Location = new Point(-1, 193);
            statsEnergyLabel.Name = "statsEnergyLabel";
            statsEnergyLabel.Size = new Size(125, 20);
            statsEnergyLabel.TabIndex = 8;
            statsEnergyLabel.Text = "Energy: XXX/XXX";
            // 
            // statsManaLabel
            // 
            statsManaLabel.AutoSize = true;
            statsManaLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            statsManaLabel.Location = new Point(8, 168);
            statsManaLabel.Name = "statsManaLabel";
            statsManaLabel.Size = new Size(116, 20);
            statsManaLabel.TabIndex = 7;
            statsManaLabel.Text = "Mana: XXX/XXX";
            // 
            // statsHPLabel
            // 
            statsHPLabel.AutoSize = true;
            statsHPLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            statsHPLabel.Location = new Point(27, 148);
            statsHPLabel.Name = "statsHPLabel";
            statsHPLabel.Size = new Size(97, 20);
            statsHPLabel.TabIndex = 6;
            statsHPLabel.Text = "HP: XXX/XXX";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(82, 118);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 5;
            label5.Text = "Character Info";
            // 
            // button5
            // 
            button5.Location = new Point(145, 368);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(131, 32);
            button5.TabIndex = 4;
            button5.Text = "Inventory";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(3, 368);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(131, 32);
            button4.TabIndex = 3;
            button4.Text = "Seek Training";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(145, 332);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(131, 32);
            button3.TabIndex = 2;
            button3.Text = "Skill Screen";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Items.AddRange(new object[] { "Aaaaa", "Bbbbb", "Ccccc", "Ddddd", "Eeeee", "Fffff", "Gggg", "Hhhhh", "Iiiiii", "Jjjjj" });
            listBox1.Location = new Point(3, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(273, 100);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(3, 332);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(131, 32);
            button2.TabIndex = 0;
            button2.Text = "Abandon Character";
            button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = CBPRM.Properties.Resources.Untitled;
            pictureBox1.Location = new Point(297, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(429, 303);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(297, 346);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(429, 152);
            richTextBox1.TabIndex = 3;
            richTextBox1.TabStop = false;
            richTextBox1.Text = "";
            // 
            // currentLocationLabel
            // 
            currentLocationLabel.AutoSize = true;
            currentLocationLabel.Location = new Point(408, 9);
            currentLocationLabel.Name = "currentLocationLabel";
            currentLocationLabel.Size = new Size(210, 15);
            currentLocationLabel.TabIndex = 4;
            currentLocationLabel.Text = "Current Location: Village of Riverwood";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(297, 504);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(373, 23);
            textBox1.TabIndex = 5;
            // 
            // button6
            // 
            button6.Location = new Point(676, 504);
            button6.Name = "button6";
            button6.Size = new Size(50, 23);
            button6.TabIndex = 6;
            button6.TabStop = false;
            button6.Text = "Send";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // chatPanel
            // 
            chatPanel.BackColor = SystemColors.ControlDark;
            chatPanel.Controls.Add(checkBox1);
            chatPanel.Controls.Add(button7);
            chatPanel.Controls.Add(textBox2);
            chatPanel.Controls.Add(label4);
            chatPanel.Controls.Add(label3);
            chatPanel.Controls.Add(label2);
            chatPanel.Location = new Point(297, 346);
            chatPanel.Name = "chatPanel";
            chatPanel.Size = new Size(429, 181);
            chatPanel.TabIndex = 7;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(178, 125);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(94, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Yes, I'm sure.";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(186, 143);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 4;
            button7.Text = "Enter Chat";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 96);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(141, 23);
            textBox2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(107, 99);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 2;
            label4.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 47);
            label3.Name = "label3";
            label3.Size = new Size(317, 15);
            label3.TabIndex = 1;
            label3.Text = "seen by other players in chat, and cannot be changed later.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 30);
            label2.Name = "label2";
            label2.Size = new Size(343, 15);
            label2.TabIndex = 0;
            label2.Text = "To enable chat, please create a username. This username will be ";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 2500;
            timer1.Tick += timer1_Tick;
            // 
            // hubScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 534);
            Controls.Add(chatPanel);
            Controls.Add(button6);
            Controls.Add(textBox1);
            Controls.Add(currentLocationLabel);
            Controls.Add(richTextBox1);
            Controls.Add(pictureBox1);
            Controls.Add(characterPanel_foundChar);
            Controls.Add(characterPanel_noChar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "hubScreen";
            Text = "Form2";
            Load += Form2_Load;
            characterPanel_noChar.ResumeLayout(false);
            characterPanel_noChar.PerformLayout();
            characterPanel_foundChar.ResumeLayout(false);
            characterPanel_foundChar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            chatPanel.ResumeLayout(false);
            chatPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel characterPanel_noChar;
        private Label label1;
        private Button button1;
        private Panel characterPanel_foundChar;
        private Button button3;
        private ListBox listBox1;
        private Button button2;
        private Button button5;
        private Button button4;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Label currentLocationLabel;
        private TextBox textBox1;
        private Button button6;
        private Panel chatPanel;
        private Label label2;
        private Button button7;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
        private Label statsEXPLabel;
        private Label statsEnergyLabel;
        private Label statsManaLabel;
        private Label statsHPLabel;
        private Label label5;
        private ProgressBar statsEXPBar;
        private ProgressBar statsEnergyBar;
        private ProgressBar statsManaBar;
        private ProgressBar statsHPBar;
        private Button levelupButton;
    }
}