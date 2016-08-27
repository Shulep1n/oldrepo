using System.Linq;
using WorstAshe.Ext;
using static WorstAshe.Ext.Config;
using static WorstAshe.Ext.Spells;
using EloBuddy;
using EloBuddy.SDK;

namespace WorstAshe.Modes
{
    internal class KillSteal
    {
        public static void Execute()
        {
            var t =
                EntityManager.Heroes.Enemies.Where(
                    x =>
                        x.IsValidTarget(2000) && !x.HasBuff("Undying Rage") && !x.HasBuff("JudicatorIntervention") &&
                        !x.HasBuff("kindrednodeathbuff") && !x.IsZombie && !x.IsDead);
            foreach (var target in t)
            {
                //R logic
                if (Config.KSR && R.IsReady())
                {
                    if (target.IsValidTarget(2000) && target.Health < User.GetSpellDamage(target, SpellSlot.R))
                    {
                        R.Cast(target);
                    }
                }

                //W logic
                if (Config.KSW && W.IsReady())
                {
                    if (target.Health < User.GetSpellDamage(target, SpellSlot.W) && target.IsValidTarget(W.Range))
                    {
                        W.Cast(target);
                    }
                }
            }
        }
    }
}
