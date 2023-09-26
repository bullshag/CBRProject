using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public struct uiSlot
        {

        }
        public List<battleHandler.characterSlot> friendlyCharList = new List<battleHandler.characterSlot>();

        public List<battleHandler.characterSlot> enemyNpcList = new List<battleHandler.characterSlot>();

        public void populateUIWindows()
        {

        }
        public void generateBattleLists()
        {
            friendlyCharList = persistantData._dataHandler.generateFriendlyList();
        }
        public battleScreen()
        {
            InitializeComponent();
        }

        private void battleScreen_Load(object sender, EventArgs e)
        {

        }

    }
}
