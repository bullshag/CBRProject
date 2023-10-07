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

        public void DistributeExpAfterBattle(List<characterSlot> characterSlots, List<npcSlot> npcSlots)
        {
            // Calculate total EXP from defeated NPCs
            int totalExp = 0;
            foreach (var npc in npcSlots)
            {
                if (!npc.alive)
                {
                    totalExp += npc._npcData.npcEXPValue;
                }
            }

            // Distribute EXP among surviving characters
            foreach (var character in characterSlots)
            {
                if (character.alive)
                {
                    character._charData.charCurrentEXP += totalExp / characterSlots.Count;
                } else { persistantData._dataHandler.DeleteCharacter(character._charData.charUID); }
            }
        }

        public characterData regenerate(characterData characterData)
        {
            characterData returnChar = new characterData();
            returnChar = characterData;

            int healthRegenAmount;
            int manaRegenAmount;
            int energyRegenAmount;

            healthRegenAmount = (int)((returnChar.charStrength * 0.1) + (returnChar.charFocus * 0.1) + (characterData.charMaxHP * 0.035));
            manaRegenAmount = (int)((returnChar.charIntelligence * 0.1) + (returnChar.charFocus * 0.1) + (characterData.charMaxMana * 0.035));
            energyRegenAmount = (int)((returnChar.charDex * 0.1) + (returnChar.charFocus * 0.1) + (characterData.charMaxEnergy * 0.035));

            if (returnChar.charBackgroundBonus == 1)
            {
                healthRegenAmount = (int)(healthRegenAmount * 1.10);
                manaRegenAmount = (int)(manaRegenAmount * 1.10);
                energyRegenAmount = (int)(energyRegenAmount * 1.10);
            }
            if (returnChar.charBackgroundBonus == 3)
            {
                healthRegenAmount += (int)(manaRegenAmount + energyRegenAmount * 0.15);
            }

            if (returnChar.charCurrentHP + healthRegenAmount < returnChar.charMaxHP)
            {
                returnChar.charCurrentHP += healthRegenAmount;
            } else { returnChar.charCurrentHP = returnChar.charMaxHP; }
            if (returnChar.charCurrentMana + manaRegenAmount < returnChar.charMaxMana)
            {
                returnChar.charCurrentMana += manaRegenAmount;
            } else { returnChar.charCurrentMana = returnChar.charMaxMana; }
            if (returnChar.charCurrentEnergy + energyRegenAmount < returnChar.charMaxEnergy)
            {
                returnChar.charCurrentEnergy += energyRegenAmount;

            } else { returnChar.charCurrentEnergy = returnChar.charMaxEnergy; }

            return returnChar;

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
        {"unarmed", new List<string> {"punches", "kicks", "slaps", "headbutts", "elbows", "knees", "bites", "grapples", "shoves", "strikes"}},
      {"noEnergy", new List<string> {"struggles to gather strength", "fails to muster energy", "stumbles, lacking energy", "pauses, drained of energy"}},
    {"noMana", new List<string> {"murmurs an incomplete incantation", "fails to focus magical energy", "stutters, lacking mana", "pauses, drained of mana"}}

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

        public static string GenerateAttackLog(string attacker, string target, int damage, string attackType, string spellName = "", bool insufficientResource = false)
        {
            string attackVerb;
            if (insufficientResource)
            {
                switch (attackType)
                {
                    case "melee":
                        attackVerb = attackVerbs["noEnergy"][rand.Next(attackVerbs["noEnergy"].Count)];
                        return $"{attacker} {attackVerb}.";
                    case "ranged":
                        attackVerb = attackVerbs["noEnergy"][rand.Next(attackVerbs["noEnergy"].Count)];
                        return $"{attacker} {attackVerb}.";
                    case "unarmed":
                        attackVerb = attackVerbs["noEnergy"][rand.Next(attackVerbs["noEnergy"].Count)];
                        return $"{attacker} {attackVerb}.";
                    case "spell":
                        attackVerb = attackVerbs["noMana"][rand.Next(attackVerbs["noMana"].Count)];
                        return $"{attacker} {attackVerb}.";
                    default:
                        return "Unknown action.";
                }
            }
            else
            {
                attackVerb = attackVerbs[attackType][rand.Next(attackVerbs[attackType].Count)];
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

}
