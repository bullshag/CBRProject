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
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp1
{
    public partial class battleScreen : Form
    {
        public List<battleHandler.characterSlot> friendlyCharList = new List<battleHandler.characterSlot>();

        public List<battleHandler.npcSlot> enemyNpcList = new List<battleHandler.npcSlot>();

        //    public void populateUIWindow(int slotID, int slot_type) // 0 = player, 1 = npc, 2 = enemy player

        public void generateBattleLists()
        {
            friendlyCharList = persistantData._dataHandler.generateFriendlyList();
            enemyNpcList = persistantData._dataHandler.GenerateNpcSlotList(persistantData._dataHandler.GenerateNPCList(persistantData._dataHandler.GetPlayerCharacters(persistantData.persistantUID), persistantData.playerZoneID));
        }
        public battleScreen()
        {
            InitializeComponent();
        }
        public void endBattle()
        {
            friendlyCharList.Clear();
            enemyNpcList.Clear();
            for (int i = 1; i <= 10; i++)
            {
                GroupBox groupBox = (GroupBox)this.Controls.Find("charWindow" + i, true).FirstOrDefault();
                if (groupBox != null)
                {
                    groupBox.Visible = false;
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                GroupBox groupBox = (GroupBox)this.Controls.Find("npc_charWindow" + i, true).FirstOrDefault();
                if (groupBox != null)
                {
                    groupBox.Visible = false;
                }
            }

        }
        public void updateNpcUI()
        {
            Debug.WriteLine("Total npc list size: " + enemyNpcList.Count);
            for (int i = 0; i < enemyNpcList.Count; i++)
            {
                var currentNpc = enemyNpcList[i];
                GroupBox groupBox = (GroupBox)this.Controls.Find("npc_charWindow" + (i + 1), true).FirstOrDefault();
                ProgressBar hpBar = (ProgressBar)this.Controls.Find("npc_hpBar" + (i + 1), true).FirstOrDefault();
                ProgressBar manaBar = (ProgressBar)this.Controls.Find("npc_manaBar" + (i + 1), true).FirstOrDefault();
                ProgressBar energyBar = (ProgressBar)this.Controls.Find("npc_energyBar" + (i + 1), true).FirstOrDefault();

                if (groupBox != null && hpBar != null && manaBar != null && energyBar != null)
                {
                    Debug.WriteLine("Adding new npc.. " + currentNpc._npcData.npcName);
                    groupBox.Text = currentNpc._npcData.npcName;
                    hpBar.Maximum = currentNpc._npcData.npcMaxHP;
                    hpBar.Value = currentNpc._npcData.npcCurrentHP;
                    manaBar.Maximum = currentNpc._npcData.npcMaxMana;
                    manaBar.Value = currentNpc._npcData.npcCurrentMana;
                    energyBar.Maximum = currentNpc._npcData.npcMaxEnergy;
                    energyBar.Value = currentNpc._npcData.npcCurrentEnergy;

                    // Make the group box and its components visible
                    groupBox.Visible = true;
                    hpBar.Visible = true;
                    manaBar.Visible = true;
                    energyBar.Visible = true;
                }
            }
        }
        public void updateFriendlyUI()
        {
            for (int i = 0; i < friendlyCharList.Count; i++)
            {
                var currentChar = friendlyCharList[i];
                GroupBox groupBox = (GroupBox)this.Controls.Find("charWindow" + (i + 1), true).FirstOrDefault();
                ProgressBar hpBar = (ProgressBar)this.Controls.Find("hpBar" + (i + 1), true).FirstOrDefault();
                ProgressBar manaBar = (ProgressBar)this.Controls.Find("manaBar" + (i + 1), true).FirstOrDefault();
                ProgressBar energyBar = (ProgressBar)this.Controls.Find("energyBar" + (i + 1), true).FirstOrDefault();
                Label hpLabel = (Label)this.Controls.Find("hp_Label" + (i + 1), true).FirstOrDefault();
                Label manaLabel = (Label)this.Controls.Find("mana_Label" + (i + 1), true).FirstOrDefault();

                if (groupBox != null && groupBox.Text != currentChar._charData.charName)
                {
                    groupBox.Text = currentChar._charData.charName;
                }

                if (hpBar != null && (hpBar.Maximum != currentChar._charData.charMaxHP || hpBar.Value != currentChar._charData.charCurrentHP))
                {
                    hpBar.Maximum = currentChar._charData.charMaxHP;
                    hpBar.Value = currentChar._charData.charCurrentHP;
                }

                if (manaBar != null && (manaBar.Maximum != currentChar._charData.charMaxMana || manaBar.Value != currentChar._charData.charCurrentMana))
                {
                    manaBar.Maximum = currentChar._charData.charMaxMana;
                    manaBar.Value = currentChar._charData.charCurrentMana;
                }

                if (energyBar != null && (energyBar.Maximum != currentChar._charData.charMaxEnergy || energyBar.Value != currentChar._charData.charCurrentEnergy))
                {
                    energyBar.Maximum = currentChar._charData.charMaxEnergy;
                    energyBar.Value = currentChar._charData.charCurrentEnergy;
                }

                if (hpLabel != null)
                {
                    string newText = $"{currentChar._charData.charCurrentHP}/{currentChar._charData.charMaxHP}";
                    if (hpLabel.Text != newText)
                    {
                        hpLabel.Text = newText;
                    }
                }

                if (manaLabel != null)
                {
                    string newText = $"{currentChar._charData.charCurrentMana}/{currentChar._charData.charMaxMana}";
                    if (manaLabel.Text != newText)
                    {
                        manaLabel.Text = newText;
                    }
                }
                if (groupBox != null)
                {
                    groupBox.Visible = true;
                }
            }

        }

        public void startBattle()
        {
            generateBattleLists();

            updateFriendlyUI();
            updateNpcUI();
        }
        private void battleScreen_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void progressBar22_Click(object sender, EventArgs e)
        {

        }
    }
}
