using WorstAshe.Ext;
using static WorstAshe.Ext.Config;
using static WorstAshe.Ext.Spells;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace WorstAshe.Modes
{
    internal class Combo
    {
        public static void Execute()
        {

            var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            var rtarget = TargetSelector.GetTarget(maxRRange, DamageType.Physical);

            //Q logic
            if (target != null)
            {
                if (Q.IsReady() && AsheQCastReady && Config.ComboQ)
                {
                    if (target.IsValidTarget(700))
                    {
                        Q.Cast();
                    }
                }
            }

            //W logic
            if (target != null)
            {
                if (Config.ComboW && W.IsReady())
                {
                    if (target.IsValidTarget(W.Range) && !target.IsZombie && !target.IsDead &&
                        W.GetPrediction(target).HitChance >= HitChance.Medium)
                    {
                        W.Cast(W.GetPrediction(target).CastPosition);
                    }
                }
            }

           


            //R logic
            if (rtarget != null)
            {
                if (Config.ComboR && R.IsReady())
                {
                    if (User.Distance(rtarget) >= minRRange && R.GetPrediction(rtarget).HitChance >= HitChance.Medium &&
                        Config.HP >= rtarget.HealthPercent)
                    {
                        R.Cast(R.GetPrediction(rtarget).CastPosition);
                    }                 
                }
            } 
        }
    }
}

