using WorstAshe.Ext;
using static WorstAshe.Ext.Config;
using static WorstAshe.Ext.Spells;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace WorstAshe.Modes
{
    internal class Harass
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(1200, DamageType.Physical);

            //Mana Manager
            if (Config.HarassWMana >= User.ManaPercent)
            {
                return;
            }
            //W logic
            if (target != null)
            {
                if (Config.HarassW && W.IsReady())
                {
                    if (target.IsValidTarget(W.Range) && !target.IsZombie && !target.IsDead &&
                        W.GetPrediction(target).HitChance >= HitChance.Medium)
                    {
                        W.Cast(W.GetPrediction(target).CastPosition);
                    }
                }
            }

        }
    }
}
