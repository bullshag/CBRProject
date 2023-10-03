using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace CBPRM
{
    public class actionLibrary
    {
        public delegate Action GameAction(npcData npc, characterData character, Target actionTarget, string abilityName = "");

        public enum AttackType
        {
            meleeAttack,
            rangedAttack,
            spellAttack,
            utility,
            heal
        }
        public struct Action
        {
            public int damageDealt;
            public int healingDealt;
            public characterData characterData;
            public npcData npcData;
            public string combatLogString;
            
        }
        public enum Target
        {
            character, 
            npc
        }
        public Action MeleeAttackAction(npcData npc, characterData character, Target actionTarget, string abilityName = "")

        {
            Action actionResult = new Action();
                    Random rand = new Random();
                    double randomFactor = 0.8 + (rand.NextDouble() * 0.4);

            switch (actionTarget)
            {
                case Target.character:
                    int baseDamage = npc.npcStrength + npc.npcDex + (int)(npc.npcEXPValue / 10);
                    int defense = (int)((character.charSpeed + character.charDex) / 2);

                    // Calculate the final damage

                    // Introduce a random factor, for example, a value between 0.8 and 1.2

                    // Calculate the final damage with the random factor
                    int finalDamage = (int)((baseDamage - defense) * randomFactor);

                    // Ensure the damage is at least 0
                    finalDamage = Math.Max(finalDamage, 0);
                    actionResult.combatLogString = CombatLogGenerator.GenerateAttackLog(npc.npcName, character.charName, finalDamage, "melee");
                    actionResult.damageDealt = finalDamage;
                    break;
                case Target.npc:
                    // Assuming you have a character attacking an NPC
                    int charBaseDamage = character.charStrength + character.charDex + (int)(character.charMaxEXP / 10);
                    int npcDefense = (int)((npc.npcSpeed + npc.npcDex)/2);

                    // Calculate the final damage

                    int charFinalDamage = (int)((charBaseDamage - npcDefense) * randomFactor);

                    // Ensure the damage is at least 0
                    charFinalDamage = Math.Max(charFinalDamage, 0);
                    actionResult.combatLogString = CombatLogGenerator.GenerateAttackLog(character.charName, npc.npcName, charFinalDamage, "melee");
                    actionResult.damageDealt = charFinalDamage;
                    break;
                default:
                    break;
            }

            return actionResult;
        }

        public Action SpellAttackAction(npcData npc, characterData character, Target actionTarget, string abilityName = "")

        {
            Action actionResult = new Action();

            switch (actionTarget)
            {
                case Target.character:
                    int baseDamage = npc.npcIntelligence + npc.npcDex + (int)(npc.npcEXPValue / 10);
                    int defense = (int)((character.charSpeed / 3) + (character.charFocus / 2) +(character.charIntelligence / 3));

                    // Calculate the final damage
                    int finalDamage = baseDamage - defense;

                    // Ensure the damage is at least 0
                    finalDamage = Math.Max(finalDamage, 0);
                    actionResult.combatLogString = CombatLogGenerator.GenerateAttackLog(npc.npcName, character.charName, finalDamage, "spell", abilityName);
                    actionResult.damageDealt = finalDamage;
                    break;
                case Target.npc:
                    // Assuming you have a character attacking an NPC
                    int charBaseDamage = character.charIntelligence + character.charDex + (int)(character.charMaxEXP / 10);
                    int npcDefense = npc.npcSpeed + npc.npcFocus;

                    // Calculate the final damage
                    int charFinalDamage = charBaseDamage - npcDefense;

                    // Ensure the damage is at least 0
                    charFinalDamage = Math.Max(charFinalDamage, 0);
                    actionResult.combatLogString = CombatLogGenerator.GenerateAttackLog(character.charName, npc.npcName, charFinalDamage, "spell", abilityName);
                    actionResult.damageDealt = charFinalDamage;
                    break;
                default:
                    break;
            }

            return actionResult;
        }
    }
}

public class skillStrings
{
    public string AutoAttack = "";
}

