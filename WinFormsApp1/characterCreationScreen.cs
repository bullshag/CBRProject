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

namespace WinFormsApp1
{
    public partial class characterCreationScreen : Form
    {
        public int pointsRemaining;
        public int statTotal;
        public characterData newCharacterSlot;

        public characterCreationScreen()
        {
            InitializeComponent();
        }

#pragma warning disable IDE1006 // Naming Styles
        public void updateCharScreen()
#pragma warning restore IDE1006 // Naming Styles
        {
            label6.Text = "Points Remaining: " + (15 - statTotal);
            if (statTotal >= 15)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }

            strLabel.Text = "Strength: " + newCharacterSlot.charStrength.ToString();
            intLabel.Text = "Intelligence: " + newCharacterSlot.charIntelligence.ToString();
            dexLabel.Text = "Dexterity: " + newCharacterSlot.charDex.ToString();

            switch (listBox1.SelectedIndex)
            {
                case 0:
                    richTextBox1.Text = "The Mercenary excells in attack skills and physical stats.\r\n\r\n+ 2 to Strength\r\n+ 2 to Dex\r\n+ Increased starting attack speed\r\n+ 20% more energy regeneration";
                    break;

                case 1:
                    richTextBox1.Text = "The Outdoor Expert excells in outlasting their opening with superior regeneration and crowd control effects. \r\n\r\n10% more health per point spent\r\n10% more mana per point spent\r\n10% more energy per point spent\r\n10% more health, mana, and energy regeneration";
                    break;

                case 2:
                    richTextBox1.Text = "The Tactician excells in critical strikes and debuffs on their opponent.\r\n\r\n+ 1 to Strength\r\n+ 1 to Dex\r\n+ 1 to Intellegence\r\nCritical hits deal 50% more damage.";
                    break;

                case 3:
                    richTextBox1.Text = "The Bastion excells in defensive skills and survivability.\r\n\r\n20% more maximum starting health\r\n+ 15% of mana and energy regeneration also regenerates health\r\n+ Increased health regeneration rate";
                    break;

                case 4:
                    richTextBox1.Text = "The Spellslinger excells in magical spells and mana regeneration.\r\n\r\n20% more maximum starting mana\r\nSpellcasting speed is increased by 50% of attack speed.";
                    break;

                default:
                    richTextBox1.Text = "The Mercenary excells in attack skills and physical stats.\r\n\r\n+ 2 to Strength\r\n+ 2 to Dex\r\n+ Increased starting attack speed\r\n+ Increased energy regeneration";
                    break;
            }
        }
        public void resetCharDataForm()
        {
            statTotal = 0;
            newCharacterSlot = new characterData();
            newCharacterSlot.charStrength = 5;
            newCharacterSlot.charDex = 5;
            newCharacterSlot.charIntelligence = 5;
            textBox1.Text = string.Empty;
            pointsRemaining = 15;
            label6.Text = "Points Remaining: 15";
            listBox1.SelectedIndex = 0;
            richTextBox1.Text = "The Mercenary excells in attack skills and physical stats.\r\n\r\n+ 2 to Strength\r\n+ 2 to Dex\r\n+ Increased starting attack speed\r\n+ 20% more energy regeneration";
            updateCharScreen();

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    richTextBox1.Text = "The Mercenary excells in attack skills and physical stats.\r\n\r\n+ 2 to Strength\r\n+ 2 to Dex\r\n+ Increased starting attack speed\r\n+ 20% more energy regeneration";
                    break;

                case 1:
                    richTextBox1.Text = "The Outdoor Expert excells in outlasting their opening with superior regeneration and crowd control effects. \r\n\r\n10% more health per point spent\r\n10% more mana per point spent\r\n10% more energy per point spent\r\n10% more health, mana, and energy regeneration";
                    break;

                case 2:
                    richTextBox1.Text = "The Tactician excells in critical strikes and debuffs on their opponent.\r\n\r\n+ 1 to Strength\r\n+ 1 to Dex\r\n+ 1 to Intellegence\r\nCritical hits deal 50% more damage.";
                    break;

                case 3:
                    richTextBox1.Text = "The Bastion excells in defensive skills and survivability.\r\n\r\n20% more maximum starting health\r\n+ 15% of mana and energy regeneration also regenerates health.";
                    break;

                case 4:
                    richTextBox1.Text = "The Spellslinger excells in magical spells and mana regeneration.\r\n\r\n20% more maximum starting mana\r\nSpellcasting speed is increased by 50% of attack speed.";
                    break;

                default:
                    richTextBox1.Text = "The Mercenary excells in attack skills and physical stats.\r\n\r\n+ 2 to Strength\r\n+ 2 to Dex\r\n+ Increased starting attack speed\r\n+ Increased energy regeneration";
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetCharDataForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (statTotal < 15)
            {
                statTotal++;
                newCharacterSlot.charStrength++;
                updateCharScreen();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (statTotal < 15)
            {
                statTotal++;
                newCharacterSlot.charDex++;
                updateCharScreen();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (statTotal < 15)
            {
                statTotal++;
                newCharacterSlot.charIntelligence++;
                updateCharScreen();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            persistantData.hubScreen.Visible = true;
            persistantData.createCharacterScreen.Visible = false;
            persistantData.hubScreen.populateCharacters();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (statTotal < 15)
            {
                if (MessageBox.Show("You have " + (15 - statTotal) + " unspent skill points. If you choose not to spend them now, they will be converted into experience points. Do you wish to continue making this character?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    newCharacterSlot.charName = textBox1.Text;
                    newCharacterSlot.charCurrentEXP = 0;
                    newCharacterSlot.charCurrentHP = 100 + (newCharacterSlot.charStrength * 5);
                    newCharacterSlot.charMaxHP = newCharacterSlot.charCurrentHP;
                    newCharacterSlot.charMaxEXP = 25;
                    newCharacterSlot.charCurrentEXP = (15 - statTotal) * 15;
                    newCharacterSlot.charMaxMana = 100 + (newCharacterSlot.charIntelligence * 5);
                    newCharacterSlot.charCurrentMana = newCharacterSlot.charMaxMana;
                    newCharacterSlot.charBackgroundBonus = listBox1.SelectedIndex;
                    newCharacterSlot.charCurrentEnergy = 100 + (newCharacterSlot.charDex * 5);
                    newCharacterSlot.charMaxEnergy = newCharacterSlot.charCurrentEnergy;
                    newCharacterSlot.charFocus = 10;
                    newCharacterSlot.charSpeed = 10;
                    if (persistantData._dataHandler.CreateCharacter(newCharacterSlot, persistantData.persistantUID, listBox1.SelectedIndex))
                    {
                        resetCharDataForm();
                        MessageBox.Show("Character created successfully!");

                        persistantData.hubScreen.Visible = true;
                        persistantData.createCharacterScreen.Visible = false;
                        persistantData.hubScreen.populateCharacters();

                    }
                    else
                    {
                        MessageBox.Show("Character name is already in use");
                    }
                }
            }
            else
            {
                newCharacterSlot.charName = textBox1.Text;
                newCharacterSlot.charCurrentEXP = 0;
                newCharacterSlot.charCurrentHP = 100 + (newCharacterSlot.charStrength * 5);
                newCharacterSlot.charMaxHP = newCharacterSlot.charCurrentHP;
                newCharacterSlot.charMaxEXP = 25;
                newCharacterSlot.charCurrentEXP = 0;
                newCharacterSlot.charMaxMana = 100 + (newCharacterSlot.charIntelligence * 5);
                newCharacterSlot.charCurrentMana = newCharacterSlot.charMaxMana;
                newCharacterSlot.charBackgroundBonus = listBox1.SelectedIndex;
                newCharacterSlot.charCurrentEnergy = 100 + (newCharacterSlot.charDex * 5);
                newCharacterSlot.charMaxEnergy = newCharacterSlot.charCurrentEnergy;
                newCharacterSlot.charFocus = 10;
                newCharacterSlot.charSpeed = 10;
                if (persistantData._dataHandler.CreateCharacter(newCharacterSlot, persistantData.persistantUID, listBox1.SelectedIndex))
                {
                    resetCharDataForm();
                    MessageBox.Show("Character created successfully!");

                    persistantData.hubScreen.Visible = true;
                    persistantData.createCharacterScreen.Visible = false;
                    persistantData.hubScreen.populateCharacters();

                }
                else
                {
                    MessageBox.Show("Character name is already in use");
                }

            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
