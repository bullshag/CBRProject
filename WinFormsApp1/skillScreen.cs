using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace CBPRM
{
    public partial class skillScreen : Form
    {
        public skillScreen()
        {
            InitializeComponent();
        }
        public void redrawGraph()
        {

        }
        public void defaultStats()
        {
            listBox1.Items.Clear();

            foreach (characterData character in persistantData.characterList)
            {
                listBox1.Items.Add(character.charName);
            }
            listBox1.SelectedIndex = 0;  // Sets the first item as selected

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCharacterName = listBox1.SelectedItem.ToString();
            characterData selectedCharacter = persistantData.characterList.Find(c => c.charName == selectedCharacterName);
            double roundedNumber = Math.Round((2500f - (2500f - ((double)selectedCharacter.charFocus * (double)selectedCharacter.charSpeed) / 100f)), 1);
            // Update Labels
            statsHPLabel.Text = $"Max HP: {selectedCharacter.charMaxHP}";
            statsManaLabel.Text = $"Max Mana: {selectedCharacter.charMaxMana}";
            statsEnergyLabel.Text = $"Max Energy: {selectedCharacter.charMaxEnergy}";
            statsEXPLabel.Text = $"EXP: {selectedCharacter.charCurrentEXP}/{selectedCharacter.charMaxEXP}";
            statsAttackSpeedLabel.Text = "Attack Speed: " + roundedNumber + " APS"; // Assuming charSpeed is attack speed
            statsStrengthLabel.Text = $"Strength: {selectedCharacter.charStrength}";
            statsDexLabel.Text = $"Dexterity: {selectedCharacter.charDex}";
            statsIntelligenceLabel.Text = $"Intelligence: {selectedCharacter.charIntelligence}";
            statsFocusLabel.Text = $"Focus: {selectedCharacter.charFocus}";
            statsSpeedLabel.Text = $"Speed: {selectedCharacter.charSpeed}";
            int charPhysDefense = (int)((selectedCharacter.charSpeed + selectedCharacter.charDex) / 2);
            int charMagicDefense = (int)((selectedCharacter.charSpeed / 3) + (selectedCharacter.charFocus / 2) + (selectedCharacter.charIntelligence / 3));
            statsPhysDefenseLabel.Text = $"Physical Defense: {charPhysDefense}"; // Assuming charPhysDefense exists in characterData
            statsMagicDefenseLabel.Text = $"Magic Defense: {charMagicDefense}"; // Assuming charMagicDefense exists in characterData


            pictureBox1.Invalidate();
        }

        private void skillScreen_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            Pen borderPen = new Pen(Color.Red, 3); // Pen for the border

            // Get the selected character
            string selectedCharacterName = listBox1.SelectedItem.ToString();
            var selectedCharacter = persistantData.characterList.Find(c => c.charName == selectedCharacterName);

            // Define the stats based on the selected character
            int maxHP = selectedCharacter.charMaxHP / 5;
            int maxMana = selectedCharacter.charMaxMana / 5;
            int maxEnergy = selectedCharacter.charMaxEnergy / 5;
            int strength = selectedCharacter.charStrength * 2;
            int speed = selectedCharacter.charSpeed * 2;
            int focus = selectedCharacter.charFocus * 2;
            int dex = selectedCharacter.charDex * 2;
            int intelligence = selectedCharacter.charIntelligence * 2;

            // Calculate additional stats
            int attackSpeed = (2500 - (selectedCharacter.charFocus * selectedCharacter.charSpeed)) / 250; // Divided by 100 as per your instruction
            int physicalDefense = (selectedCharacter.charSpeed + selectedCharacter.charDex) / 2;
            int magicDefense = (selectedCharacter.charSpeed / 3) + (selectedCharacter.charFocus / 3) + (selectedCharacter.charIntelligence / 3);

            physicalDefense *= 2;
            magicDefense *= 2;
            attackSpeed *= 2;
            // Choose which stats to display on the polygon
            int[] stats = new int[11] { maxHP, maxMana, strength, speed, physicalDefense, magicDefense, maxEnergy, focus, intelligence, attackSpeed, dex };

            // Define the points for the polygon
            Point[] polygonPoints = new Point[11];
            int xCenter = pictureBox1.Width / 2;
            int yCenter = pictureBox1.Height / 2;
            int radius = Math.Min(xCenter, yCenter) - 10; // Dynamic radius, 10 is a margin

            for (int i = 0; i < 11; i++)
            {
                double angle = (2 * Math.PI / 11) * i;
                int x = (int)(xCenter + (radius * stats[i] / 100.0) * Math.Cos(angle));
                int y = (int)(yCenter + (radius * stats[i] / 100.0) * Math.Sin(angle));
                polygonPoints[i] = new Point(x, y);
            }

            // Draw the polygon
            g.DrawPolygon(pen, polygonPoints);

            // Draw the border
            Point[] borderPolygonPoints = new Point[11];
            for (int i = 0; i < 11; i++)
            {
                double angle = (2 * Math.PI / 11) * i;
                int x = (int)(xCenter + radius * Math.Cos(angle));
                int y = (int)(yCenter + radius * Math.Sin(angle));
                borderPolygonPoints[i] = new Point(x, y);
            }
            g.DrawPolygon(borderPen, borderPolygonPoints);

            // Optionally, fill the polygon
            Brush brush = new SolidBrush(Color.LightGray);
            g.FillPolygon(brush, polygonPoints);

            // Draw a black dot at the center
            Brush centerBrush = new SolidBrush(Color.Black);
            int dotRadius = 5; // radius of the dot
            g.FillEllipse(centerBrush, xCenter - dotRadius, yCenter - dotRadius, dotRadius * 2, dotRadius * 2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
