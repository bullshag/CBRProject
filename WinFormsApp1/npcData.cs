using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBPRM.actionLibrary;

namespace WinFormsApp1
{
    public class npcData
    {

        public string npcName;
        public int npcMaxHP;
        public int npcCurrentHP;
        public int npcMaxMana;
        public int npcCurrentMana;
        public int npcMaxEnergy;
        public int npcCurrentEnergy;
        public int npcStrength;
        public int npcDex;
        public int npcIntelligence;
        public int npcFocus;
        public int npcSpeed;
        public int npcEXPValue;
        public int npcID;
        public int npcSkill1;
        public int npcSkill2;
        public int npcSkill3;
        public int maxOnScreen;
        public int zoneID;
        public int spawnID;
        public float TimeUntilNextAction;

        public List<GameAction> AvailableActions { get; set; }
        public void loadActions()
        {
            AvailableActions = new List<GameAction>();
        }
    }
}
