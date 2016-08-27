using System.Linq;
using WorstAshe.Ext;
using static WorstAshe.Ext.Config;
using static WorstAshe.Ext.Spells;
using EloBuddy;
using EloBuddy.SDK;

namespace WorstAshe.Modes
{
    internal class LaneClear
    {
        public static void Execute()
        {
            //Mana Manager
            if (Config.LaneClearQMana >= User.ManaPercent)
            {
                return;
            }
            if (Config.LaneClearWMana >= User.ManaPercent)
            {
                return;
            }
            
            
            //Q logic
            if (Config.LaneClearQ && Q.IsReady() && AsheQCastReady)
            {
                if (User.CountEnemyMinionsInRange(800) >= 3)
                {
                    Q.Cast();
                }
            }

            //W logic
            if (Config.LaneClearW && W.IsReady())
            {
                Obj_AI_Base minion = EntityManager.MinionsAndMonsters.EnemyMinions.Where(
                    t => t.IsInRange(User.Position, Q.Range) && !t.IsDead && t.IsValid &&
                    !t.IsInvulnerable).FirstOrDefault();
                if (minion != null)
                {
                    W.Cast(minion);
                }
            }
        }
    }
}


