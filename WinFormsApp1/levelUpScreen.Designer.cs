namespace CBPRM
{
    partial class levelUpScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(levelUpScreen));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            backgroundBonusLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.MaximumSize = new Size(500, 0);
            label1.Name = "label1";
            label1.Size = new Size(492, 60);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.UseMnemonic = false;
            // 
            // button1
            // 
            button1.Location = new Point(12, 245);
            button1.Name = "button1";
            button1.Size = new Size(98, 23);
            button1.TabIndex = 1;
            button1.Text = "+25 Health";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(116, 245);
            button2.Name = "button2";
            button2.Size = new Size(98, 23);
            button2.TabIndex = 2;
            button2.Text = "+25 Mana";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(324, 216);
            button3.Name = "button3";
            button3.Size = new Size(98, 23);
            button3.TabIndex = 3;
            button3.Text = "+1 Strength";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(324, 245);
            button4.Name = "button4";
            button4.Size = new Size(98, 23);
            button4.TabIndex = 4;
            button4.Text = "+1 Dexterity";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(12, 216);
            button5.Name = "button5";
            button5.Size = new Size(98, 23);
            button5.TabIndex = 5;
            button5.Text = "+1 Focus";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(116, 216);
            button6.Name = "button6";
            button6.Size = new Size(98, 23);
            button6.TabIndex = 6;
            button6.Text = "+1 Speed";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(220, 245);
            button7.Name = "button7";
            button7.Size = new Size(98, 23);
            button7.TabIndex = 7;
            button7.Text = "+25 Energy";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(220, 216);
            button8.Name = "button8";
            button8.Size = new Size(98, 23);
            button8.TabIndex = 8;
            button8.Text = "+1 Intelligence";
            button8.UseVisualStyleBackColor = true;
            // 
            // backgroundBonusLabel
            // 
            backgroundBonusLabel.AutoSize = true;
            backgroundBonusLabel.Location = new Point(10, 110);
            backgroundBonusLabel.MaximumSize = new Size(500, 0);
            backgroundBonusLabel.Name = "backgroundBonusLabel";
            backgroundBonusLabel.Size = new Size(493, 30);
            backgroundBonusLabel.TabIndex = 9;
            backgroundBonusLabel.Text = "Based on your background, your will gain the following bonuses each time you spend a stat point:";
            backgroundBonusLabel.UseMnemonic = false;
            // 
            // levelUpScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 280);
            Controls.Add(backgroundBonusLabel);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "levelUpScreen";
            Text = "levelUpScreen";
            Load += levelUpScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Label backgroundBonusLabel;
    }
}