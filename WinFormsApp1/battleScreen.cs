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
using System.Windows.Forms.VisualStyles;
using Timer = System.Windows.Forms.Timer;

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
            combatStarted = false;
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
            for (int i = 0; i < enemyNpcList.Count; i++)
            {
                var currentNpc = enemyNpcList[i];
                GroupBox groupBox = (GroupBox)this.Controls.Find("npc_charWindow" + (i + 1), true).FirstOrDefault();
                ProgressBar hpBar = (ProgressBar)this.Controls.Find("npc_hpBar" + (i + 1), true).FirstOrDefault();
                ProgressBar manaBar = (ProgressBar)this.Controls.Find("npc_manaBar" + (i + 1), true).FirstOrDefault();
                ProgressBar energyBar = (ProgressBar)this.Controls.Find("npc_energyBar" + (i + 1), true).FirstOrDefault();

                if (groupBox != null && hpBar != null && manaBar != null && energyBar != null)
                {
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
        public void CheckCombatStatus()
        {
            bool allFriendlyDown = true;
            bool allEnemyDown = true;

            // Check if all friendly characters are down
            for (int i = 0; i < friendlyCharList.Count; i++)
            {
                if (friendlyCharList[i]._charData.charCurrentHP > 0)
                {
                    allFriendlyDown = false;
                    break;
                }
            }

            // Check if all enemy NPCs are down
            for (int i = 0; i < enemyNpcList.Count; i++)
            {
                if (enemyNpcList[i]._npcData.npcCurrentHP > 0)
                {
                    allEnemyDown = false;
                    break;
                }
            }

            // If all combatants on either side are down, set combatStarted to false
            if (allFriendlyDown || allEnemyDown)
            {
                gameLoopTimer.Enabled = false;
                combatStarted = false;
                if (allFriendlyDown)
                {
                    MessageBox.Show("You have been defeated!");
                }
                if (allEnemyDown)
                {
                    MessageBox.Show("You are victorious!");
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
        public bool combatStarted;
        public void startBattle()
        {
            combatStarted = true;
            generateBattleLists();
            timer1.Enabled = true;
            updateFriendlyUI();
            updateNpcUI();
            gameLoopTimer.Enabled = true;
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

        private Random rand = new Random();

        public void subtractEnergy(characterData characterData, int energyCost)
        {
            int index = friendlyCharList.FindIndex(c => c._charData.charUID == characterData.charUID);
            characterData.charCurrentEnergy -= energyCost;
            // Replace the old character data with the new one
            if (index != -1)
            {
                //  friendlyCharList[index]._charData = characterData;
            }
        }
        public void PerformAction(characterData charData)
        {
            // Randomly select an action from the available actions
            int actionIndex = rand.Next(charData.AvailableActions.Count);
            actionLibrary.GameAction selectedAction = charData.AvailableActions[actionIndex];

            // Randomly select a target NPC
            int targetIndex = rand.Next(enemyNpcList.Count);
            npcData targetNpc = enemyNpcList.First(n => n._npcData.spawnID == enemyNpcList[targetIndex]._npcData.spawnID)._npcData;



            // Execute the action
            actionLibrary.Action result = selectedAction(targetNpc, charData, actionLibrary.Target.npc);

            if (charData.charCurrentEnergy < result.energyCost)
            {
                result.combatLogString = CombatLogGenerator.GenerateAttackLog(targetNpc.npcName, charData.charName, 0, "melee", "failure", true);
                result.damageDealt = 0;
            }
            if (charData.charCurrentMana < result.manaCost)
            {
                result.damageDealt = 0;
                result.combatLogString = CombatLogGenerator.GenerateAttackLog(targetNpc.npcName, charData.charName, 0, "spell", "failure", true); ;
            }
            var character = friendlyCharList.FirstOrDefault(c => c._charData.charUID == charData.charUID);

            // Deduct the energy cost
            character._charData.charCurrentEnergy -= result.energyCost;

            // Ensure energy doesn't go below zero
            if (character._charData.charCurrentEnergy < 0)
            {
                character._charData.charCurrentEnergy = 0;
            }



            // Update the NPC's health
            Debug.WriteLine("Before Update Hash Codes: " + string.Join(", ", enemyNpcList.Select(n => n._npcData.GetHashCode())));
            UpdateNpcHealth(targetNpc.spawnID, result.damageDealt);
            Debug.WriteLine("After Update Hash Codes: " + string.Join(", ", enemyNpcList.Select(n => n._npcData.GetHashCode())));


            // Update the UI if needed
            if (result.damageDealt > 0)
            {

                updateNpcUI();
            }

            // Log the action
            richTextBox1.Text += result.combatLogString + Environment.NewLine;

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void UpdateNpcHealth(int targetSpawnID, int damageDealt)
        {
            int targetIndex = enemyNpcList.FindIndex(n => n._npcData.spawnID == targetSpawnID);

            if (targetIndex != -1)
            {
                Debug.WriteLine($"Targeting NPC with spawnID: {targetSpawnID}");

                battleHandler.npcSlot npcSlot = enemyNpcList[targetIndex];
                npcSlot._npcData.npcCurrentHP -= damageDealt;

                if (npcSlot._npcData.npcCurrentHP < 0)
                {
                    npcSlot._npcData.npcCurrentHP = 0;
                    CheckCombatStatus();
                }

                enemyNpcList[targetIndex] = npcSlot;

                Debug.WriteLine($"Updated NPC with spawnID: {npcSlot._npcData.spawnID}, New HP: {npcSlot._npcData.npcCurrentHP}");
            }
            else
            {
                Debug.WriteLine($"NPC with spawnID {targetSpawnID} not found.");
            }
        }
        public void PerformAction(npcData npcData)
        {
            // Randomly select an action from the available actions
            Random rand = new Random();
            int actionIndex = rand.Next(npcData.AvailableActions.Count);
            actionLibrary.GameAction selectedAction = npcData.AvailableActions[actionIndex];

            // Randomly select a target character
            int targetIndex = rand.Next(friendlyCharList.Count);
            characterData targetCharacter = friendlyCharList[targetIndex]._charData;

            // Execute the action
            actionLibrary.Action result = selectedAction(npcData, targetCharacter, actionLibrary.Target.character);

            if (npcData.npcCurrentEnergy < result.energyCost)
            {
                result.combatLogString = CombatLogGenerator.GenerateAttackLog(npcData.npcName, targetCharacter.charName, 0, "melee");
                result.damageDealt = 0;
            }
            if (npcData.npcCurrentMana < result.manaCost)
            {
                result.damageDealt = 0;
                result.combatLogString = CombatLogGenerator.GenerateAttackLog(npcData.npcName, targetCharacter.charName, 0, "spell");
            }
            var npc = enemyNpcList.FirstOrDefault(n => n._npcData.spawnID == npcData.spawnID);

            // Deduct the energy costs
            //npc._npcData.npcCurrentEnergy -= result.energyCost;

            // Ensure energy doesn't go below zero
            if (npc._npcData.npcCurrentEnergy < 0)
            {
                npc._npcData.npcCurrentEnergy = 0;
            }

            targetCharacter.charCurrentHP -= result.damageDealt;

            if (targetCharacter.charCurrentHP <= 0)
            {
                targetCharacter.charCurrentHP = 0;
                CheckCombatStatus();
                // Handle character death here if needed
            }

            // Update the friendlyCharList with the modified targetCharacter
            battleHandler.characterSlot updatedSlot = friendlyCharList[targetIndex];
            updatedSlot._charData = targetCharacter;
            friendlyCharList[targetIndex] = updatedSlot;

            if (result.damageDealt > 0)
            {
                updateFriendlyUI(); // Assuming you have a method to update the character UI
            }

            richTextBox1.Text += result.combatLogString + Environment.NewLine;

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }


        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
            }
            float deltaTime = 100.0f; // Assuming your loop runs every 1000 ms or 1 second

            // Update player characters
            for (int i = 0; i < friendlyCharList.Count; i++)
            {


                friendlyCharList[i]._charData.TimeUntilNextAction -= deltaTime;

                if (friendlyCharList[i]._charData.TimeUntilNextAction <= 0)
                {
                    PerformAction(friendlyCharList[i]._charData);
                    friendlyCharList[i]._charData.TimeUntilNextAction = 2500 - (friendlyCharList[i]._charData.charSpeed * friendlyCharList[i]._charData.charFocus);
                }
            }

            // Update enemy NPCs
            for (int i = 0; i < enemyNpcList.Count; i++)
            {
                enemyNpcList[i]._npcData.TimeUntilNextAction -= deltaTime;

                if (enemyNpcList[i]._npcData.TimeUntilNextAction <= 0)
                {
                    PerformAction(enemyNpcList[i]._npcData);
                    enemyNpcList[i]._npcData.TimeUntilNextAction = 2500 - (enemyNpcList[i]._npcData.npcFocus * enemyNpcList[i]._npcData.npcSpeed);
                }
            }
            if (!combatStarted) { gameLoopTimer.Enabled = false; Debug.WriteLine("combat finished."); }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (combatStarted == false)
            {

                timer1.Enabled = false;

                return;
            }
            for (int i = 0; i < friendlyCharList.Count; i++)
            {
                characterData tempCharRegen = persistantData.battleHandler.regenerate(friendlyCharList[i]._charData);

                friendlyCharList[i]._charData.charCurrentHP = tempCharRegen.charCurrentHP;
                friendlyCharList[i]._charData.charCurrentMana = tempCharRegen.charCurrentMana;
                friendlyCharList[i]._charData.charCurrentEnergy = tempCharRegen.charCurrentEnergy;


            }
        }
    }
}
