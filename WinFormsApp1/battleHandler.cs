using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class battleHandler
    {
        public struct characterSlot
        {
            public int cid;
            public int slotID;
            public int speed;
            public bool alive;
            public characterData _charData;
        }

        public struct npcSlot
        {
            public int cid;
            public int slotID;
            public int speed;
            public bool alive;
            public npcData _npcData;
        }


    }

    public class CombatLogGenerator
    {
        private static Random rand = new Random();

        private static Dictionary<string, List<string>> attackVerbs = new Dictionary<string, List<string>>
    {
        {"melee", new List<string> {"swings", "slashes", "stabs", "lunges at", "slices", "attacks", "hacks", "cleaves", "impales", "gouges"}},
        {"ranged", new List<string> {"shoots", "fires", "launches", "hurls", "looses", "aims", "sends", "propels", "flings", "lets fly"}},
        {"spell", new List<string> {"casts", "conjures", "unleashes", "invokes", "summons", "utters", "channels", "weaves", "hurls", "releases"}},
        {"unarmed", new List<string> {"punches", "kicks", "slaps", "headbutts", "elbows", "knees", "bites", "grapples", "shoves", "strikes"}}
    };

        private static List<string> connectingWords = new List<string>
    {
        "at",
        "towards",
        "against",
        "into",
        "upon",
        "directly at",
        "viciously at",
        "swiftly towards",
        "forcefully against",
        "ferociously into"
    };

        public static string GenerateAttackLog(string attacker, string target, int damage, string attackType, string spellName = "")
        {
            string attackVerb = attackVerbs[attackType][rand.Next(attackVerbs[attackType].Count)];
            string connectingWord = connectingWords[rand.Next(connectingWords.Count)];

            if (attackType == "spell")
            {
                return $"{attacker} {attackVerb} {spellName} {connectingWord} {target} and deals {damage} damage.";
            }
            else
            {
                return $"{attacker} {attackVerb} {connectingWord} {target} and deals {damage} damage.";
            }
        }
    }


}
