using System.Linq;
using WorstAshe.Ext;
using static WorstAshe.Ext.Spells;
using static WorstAshe.Ext.Config;
using EloBuddy.SDK;

namespace WorstAshe.Modes
{
    internal class JungleClear
    {
        public static void Execute()
        {



            var monsters =
                EntityManager.MinionsAndMonsters.GetJungleMonsters(User.Position, W.Range)
                    .Where(x => !x.IsDead && x.IsValid && !x.IsInvulnerable);

            if (W.IsReady() && Config.JungleClearW)
            {
                if (monsters.Count() > 0)
                {
                    W.Cast(monsters.First());
                }
            }
            if (Q.IsReady() && AsheQCastReady && Config.JungleClearQ)
            {

                if (monsters.Count() > 0)
                {
                    Q.Cast();
                }

            }

        }
    }
}
