using static WorstAshe.Ext.Spells;
using EloBuddy;
using EloBuddy.SDK;

namespace WorstAshe.Modes
{
    internal class Flee
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            if (W.IsReady() && target.IsValidTarget(W.Range))
            {
                W.Cast(target);
            }
        }
    }
}
