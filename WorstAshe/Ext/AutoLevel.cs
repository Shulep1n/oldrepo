using EloBuddy;
using System;
using EloBuddy.SDK.Menu.Values;
using static WorstAshe.Ext.Config;

namespace WorstAshe.Ext
{
    using System.Linq;



    class AutoLevel
    {
        public static int[] SpellLevels;

       

        private static string GetLevelList(int[] spellLevels)
        {
            var a = new[] { "Q", "W", "E", "R" };
            var b = spellLevels.Aggregate("", (c, i) => c + (a[i - 1] + " - "));
            return b != "" ? b.Substring(0, b.Length - 2) : "";
        }

        
        public static void LevelUp(SpellSlot slot)
        {
            EloBuddy.SDK.Core.DelayAction(() =>
            {
                User.Spellbook.LevelSpell(slot);
            }, new Random().Next(0, Config.Delay));
        }

        public static void Execute()
        {
            if (!Config.ALEnable)
            {
                return;
            }

            
            if (User.ChampionName == "Ashe")
            {
                if (Settings["ALBox"].Cast<ComboBox>().CurrentValue == 0)
                {
                    SpellLevels = new int[] {2, 1, 1, 3, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3};
                }
                if (Settings["ALBox"].Cast<ComboBox>().CurrentValue == 1)
                {
                    SpellLevels = new int[] {2, 1, 2, 3, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3};
                }
            }

            var qLevel = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level;
            var wLevel = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level;
            var eLevel = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level;
            var rLevel = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level;

            if (qLevel + wLevel + eLevel + rLevel >= ObjectManager.Player.Level)
            {
                return;
            }

            var level = new int[] { 0, 0, 0, 0 };
            for (var i = 0; i < ObjectManager.Player.Level; i++)
            {
                level[SpellLevels[i] - 1] = level[SpellLevels[i] - 1] + 1;
            }

            if (qLevel < level[0])
            {
                LevelUp(SpellSlot.Q);
            }
            if (wLevel < level[1])
            {
                LevelUp(SpellSlot.W);
            }

            if (eLevel < level[2])
            {
                LevelUp(SpellSlot.E);
            }

            if (rLevel < level[3])
            {
                LevelUp(SpellSlot.R);
            }
        }
    }
}
