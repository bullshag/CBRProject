using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace CBPRM
{
    public partial class levelUpScreen : Form
    {
        public characterData selectedCharacter;

        public void selectCharacterForLevelUp(characterData characterData)
        {
            string baseText = "Based on your background, your will gain the following bonuses each time you spend a stat point: ";
            selectedCharacter = new characterData();
            selectedCharacter = characterData;


            if (selectedCharacter.charCurrentEXP > selectedCharacter.charMaxEXP)
            {

                while (selectedCharacter.charCurrentEXP > selectedCharacter.charMaxEXP && (selectedCharacter.charCurrentEXP - selectedCharacter.charMaxEXP) > 0)
                {
                    selectedCharacter.charCurrentEXP -= selectedCharacter.charMaxEXP;
                    selectedCharacter.charMaxEXP = (int)(selectedCharacter.charMaxEXP * 1.15);
                    selectedCharacter.statPoints += 1;
                }

            }
            selectedCharacter.statPoints += 1;

            switch (selectedCharacter.charBackgroundBonus)
            {
                case 0:
                    backgroundBonusLabel.Text = baseText + "+1 to Dex and Strength";
                    break;
                case 1:
                    backgroundBonusLabel.Text = baseText + "10% more health, mana, and energy gained from ability points";

                    break;
                case 2:
                    backgroundBonusLabel.Text = baseText + "Whenever you spend a stat point on strength, dex, or intelligence you gain an additional point in the chosen stat.";
                    break;
                case 3:
                    backgroundBonusLabel.Text = baseText + "Whenever you spend a stat point on health, you gain +5 to your maximum energy and mana. ";
                    break;
                case 4:
                    backgroundBonusLabel.Text = baseText + "When you increase your focus or intelligence, you also gain +10 maximum mana.";
                    break;
            }
        }
        public void increaseStat(int statID)
        {
            // Check if there are stat points available to spend
            if (selectedCharacter.statPoints <= 0)
            {
                return;
            }

            // Default values for increasing stats
            int defaultHPIncrease = 25;
            int defaultManaIncrease = 25;
            int defaultEnergyIncrease = 25;
            int defaultStatIncrease = 1;

            // Apply the stat increase based on the statID
            switch (statID)
            {
                case 0: // focus
                    selectedCharacter.charFocus += defaultStatIncrease;
                    if (selectedCharacter.charBackgroundBonus == 4)
                    {
                        selectedCharacter.charMaxMana += 10;
                    }
                    break;
                case 1: // speed
                    selectedCharacter.charSpeed += defaultStatIncrease;
                    break;
                case 2: // intelligence
                    selectedCharacter.charIntelligence += defaultStatIncrease;
                    if (selectedCharacter.charBackgroundBonus == 4 || selectedCharacter.charBackgroundBonus == 2)
                    {
                        selectedCharacter.charMaxMana += 10;
                    }
                    break;
                case 3: // strength
                    selectedCharacter.charStrength += defaultStatIncrease;
                    if (selectedCharacter.charBackgroundBonus == 0 || selectedCharacter.charBackgroundBonus == 2)
                    {
                        selectedCharacter.charStrength += 1;
                    }
                    break;
                case 4: // hp
                    selectedCharacter.charMaxHP += defaultHPIncrease;
                    if (selectedCharacter.charBackgroundBonus == 1)
                    {
                        selectedCharacter.charMaxHP = (int)(selectedCharacter.charMaxHP * 1.1);
                    }
                    if (selectedCharacter.charBackgroundBonus == 3)
                    {
                        selectedCharacter.charMaxEnergy += 5;
                        selectedCharacter.charMaxMana += 5;
                    }
                    break;
                case 5: // mana
                    selectedCharacter.charMaxMana += defaultManaIncrease;
                    if (selectedCharacter.charBackgroundBonus == 1)
                    {
                        selectedCharacter.charMaxMana = (int)(selectedCharacter.charMaxMana * 1.1);
                    }
                    break;
                case 6: // energy
                    selectedCharacter.charMaxEnergy += defaultEnergyIncrease;
                    if (selectedCharacter.charBackgroundBonus == 1)
                    {
                        selectedCharacter.charMaxEnergy = (int)(selectedCharacter.charMaxEnergy * 1.1);
                    }
                    break;
                case 7: // dex
                    selectedCharacter.charDex += defaultStatIncrease;
                    if (selectedCharacter.charBackgroundBonus == 0 || selectedCharacter.charBackgroundBonus == 2)
                    {
                        selectedCharacter.charDex += 1;
                    }
                    break;
                case 8: // skill points
                    selectedCharacter.skillPoints += 1;
                    break;
            }

            // Deduct a stat point after successfully increasing a stat
            selectedCharacter.statPoints -= 1;
            try
            {
                // Find the index of the old character data in the list
                int index = persistantData.characterList.FindIndex(c => c.charUID == selectedCharacter.charUID);

                // Replace the old character data with the new one
                if (index != -1)
                {
                    persistantData.characterList[index] = selectedCharacter;
                }
                else
                {
                    // Handle the case where the character was not found in the list
                    // For example, you might want to add the new character data to the list
                    persistantData.characterList.Add(selectedCharacter);
                }

                // Now you can call your method to save this updated list back to the database

                foreach (characterData character in persistantData.characterList)
                {
                persistantData._dataHandler.SaveCharacter(character);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            MessageBox.Show("Level Up applied to your character!");
            if (selectedCharacter.statPoints == 0)
            {
                persistantData.hubScreen.Visible = true;
                persistantData.levelUpScreen.Visible = false;
            }
        }

        public void ReplaceCharacterData(characterData newCharacterData)
        {
            // Find the index of the old character data in the list
            int index = persistantData.characterList.FindIndex(c => c.charUID == newCharacterData.charUID);

            // Replace the old character data with the new one
            if (index != -1)
            {
                persistantData.characterList[index] = newCharacterData;
            }
            else
            {
                // Handle the case where the character was not found in the list
                // For example, you might want to add the new character data to the list
                persistantData.characterList.Add(newCharacterData);
            }

        }
        public void performLevelUp()
        {

            switch (selectedCharacter.charBackgroundBonus)
            {
                case 0:
                    selectedCharacter.charDex += 1;
                    selectedCharacter.charStrength += 1;

                    break;
                case 1:

                    break;
            }
        }
        public levelUpScreen()
        {
            InitializeComponent();
        }

        private void levelUpScreen_Load(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            increaseStat(3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            increaseStat(8);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            increaseStat(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            increaseStat(1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            increaseStat(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            increaseStat(4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            increaseStat(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            increaseStat(6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            increaseStat(7);
        }
    }
}
