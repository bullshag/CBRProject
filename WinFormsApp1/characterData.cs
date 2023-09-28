﻿using CBPRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBPRM.actionLibrary;

namespace WinFormsApp1
{
    public class characterData
    {
        public string charName;
        public int charMaxHP;
        public int charCurrentHP;
        public int charMaxMana;
        public int charCurrentMana;
        public int charMaxEnergy;
        public int charCurrentEnergy;
        public int charStrength;
        public int charDex;
        public int charIntelligence;
        public int charFocus;
        public int charSpeed;
        public int charMaxEXP;
        public int charCurrentEXP;
        public int charUID;
        public int charBackgroundBonus;

        public float TimeUntilNextAction;
        public List<GameAction> AvailableActions { get; set; }

        public void loadActions()
        {
            AvailableActions = new List<GameAction>();
        }
}

}
