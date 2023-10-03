using CBPRM;
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
    public partial class hubScreen : Form
    {
        public hubScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            persistantData.createCharacterScreen.Visible = true;
            persistantData.createCharacterScreen.resetCharDataForm();
        }

        public void populateCharacters()
        {
            listBox1.Items.Clear();
            //persistantData._dataHandler.PopulateCharacterList(persistantData.persistantUID, listBox1);
            persistantData.characterList.Clear();
            persistantData.characterList = persistantData._dataHandler.LoadPlayerCharacters(persistantData.persistantUID);
            Debug.WriteLine("found this many characters: " + persistantData.characterList.Count);
            foreach (characterData character in persistantData.characterList)
            {
                listBox1.Items.Add(character.charName);
            }


            if (listBox1.Items.Count > 0)
            {
                characterPanel_noChar.Visible = false;
                characterPanel_foundChar.Visible = true;
            }



        }
        private void Form2_Load(object sender, EventArgs e)
        {
            populateCharacters();

            persistantData.chatNickname = persistantData._dataHandler.CheckChatNickname(persistantData.persistantUID);
            if (persistantData.chatNickname != null)
            {
                persistantData.chatEnabled = true;
                chatPanel.Visible = false;
                persistantData._dataHandler.PopulateChatBox(richTextBox1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (persistantData._dataHandler.RegisterChatUser(textBox2.Text, persistantData.persistantUID))
            {
                MessageBox.Show("Nickname registered successfully! Welcome to the chat server.");
                persistantData.chatEnabled = true;
                chatPanel.Visible = false;
                persistantData._dataHandler.PopulateChatBox(richTextBox1);
            }
            else
            {
                MessageBox.Show("Nickname already taken.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { button7.Enabled = true; } else { button7.Enabled = false; }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (persistantData.chatEnabled = true)
            {
                persistantData._dataHandler.PopulateChatBox(richTextBox1);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                persistantData._dataHandler.SendMessage(persistantData.chatNickname, textBox1.Text);
                persistantData._dataHandler.PopulateChatBox(richTextBox1);

                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                textBox1.Text = null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            persistantData.hubScreen.Visible = false;
            persistantData.battleScreen.Visible = true;
            persistantData.battleScreen.startBattle();
        }

        private void progressBar4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCharacterName = listBox1.SelectedItem.ToString();
            var selectedCharacter = persistantData.characterList.Find(c => c.charName == selectedCharacterName);

            // Update Labels
            statsHPLabel.Text = $"HP: {selectedCharacter.charCurrentHP}/{selectedCharacter.charMaxHP}";
            statsManaLabel.Text = $"Mana: {selectedCharacter.charCurrentMana}/{selectedCharacter.charMaxMana}";
            statsEnergyLabel.Text = $"Energy: {selectedCharacter.charCurrentEnergy}/{selectedCharacter.charMaxEnergy}";
            statsEXPLabel.Text = $"EXP: {selectedCharacter.charCurrentEXP}/{selectedCharacter.charMaxEXP}";

            // Update Progress Bars
            statsHPBar.Maximum = selectedCharacter.charMaxHP;
            statsHPBar.Value = Math.Min(selectedCharacter.charCurrentHP, selectedCharacter.charMaxHP);

            statsManaBar.Maximum = selectedCharacter.charMaxMana;
            statsManaBar.Value = Math.Min(selectedCharacter.charCurrentMana, selectedCharacter.charMaxMana);

            statsEnergyBar.Maximum = selectedCharacter.charMaxEnergy;
            statsEnergyBar.Value = Math.Min(selectedCharacter.charCurrentEnergy, selectedCharacter.charMaxEnergy);

            statsEXPBar.Maximum = selectedCharacter.charMaxEXP;
            statsEXPBar.Value = Math.Min(selectedCharacter.charCurrentEXP, selectedCharacter.charMaxEXP);

            // Show the level-up button if the character's current EXP exceeds the max EXP
            levelupButton.Visible = selectedCharacter.charCurrentEXP > selectedCharacter.charMaxEXP;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            persistantData.hubScreen.Visible = false;
            persistantData.skillScreen.defaultStats();
            persistantData.skillScreen.Visible = true;
        }
    }
}
