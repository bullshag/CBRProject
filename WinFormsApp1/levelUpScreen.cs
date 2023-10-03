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
                    performLevelUp();
            }
        }

        public void increaseStat(int statID)
        {
            
            
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

        }
    }
}
