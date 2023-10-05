using CBPRM;
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
        public static actionLibrary actionLibrary;
        public static int persistantUID;
        public static bool chatEnabled;
        public static string chatNickname;
        public static int playerZoneID;
        public static List<characterData> characterList;
        public static int money;
        public static skillScreen skillScreen;
        public static levelUpScreen levelUpScreen;
        public static battleHandler battleHandler;
        public static void firstLoad()
        {
            battleHandler = new battleHandler();
            levelUpScreen = new levelUpScreen();
            skillScreen = new skillScreen();
            characterList = new List<characterData>();
            playerZoneID = 1;
            chatEnabled = false;
            hubScreen = new hubScreen();
            createCharacterScreen = new characterCreationScreen();
            _dataHandler = new dataHandler();
            battleScreen = new battleScreen();
            actionLibrary = new actionLibrary();
            
        }
    }
}
