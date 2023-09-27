using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            persistantData._dataHandler.PopulateCharacterList(persistantData.persistantUID, listBox1);
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
            if (textBox1.Text.Length > 0) { 
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
    }
}
