using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
   public class persistantData
    {
        public static hubScreen hubScreen;
        public static characterCreationScreen createCharacterScreen;
        public static dataHandler _dataHandler;
        public static battleScreen battleScreen;
        public static int persistantUID;
        public static bool chatEnabled;
        public static string chatNickname;
        public static int playerZoneID;
        public static void firstLoad()
        {
            playerZoneID = 1;
            chatEnabled = false;
            hubScreen = new hubScreen();
            createCharacterScreen = new characterCreationScreen();
            _dataHandler = new dataHandler();
            battleScreen = new battleScreen();

        }
    }
}
