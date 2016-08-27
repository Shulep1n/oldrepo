using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using static WorstAshe.Ext.Config;

namespace WorstAshe.Ext
{
    internal class Spells
    {
        public static Spell.Active Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        internal static void Init()
        {
            Q = new Spell.Active(SpellSlot.Q);
            W = new Spell.Skillshot(SpellSlot.W, 1200, SkillShotType.Linear, 0, int.MaxValue, 60)
            {
                AllowedCollisionCount = 0
            };
            E = new Spell.Skillshot(SpellSlot.E, 15000, SkillShotType.Linear, 0, int.MaxValue, 0);
            R = new Spell.Skillshot(SpellSlot.R, 15000, SkillShotType.Linear, 500, 1000, 250);
        }

     

        public static bool AsheQCastReady
        {
            get { return User.HasBuff("AsheQCastReady"); }
        }

        public bool IsQActive
        {
            get { return User.HasBuff("FrostShot"); }
        }

        public static void CastE(SharpDX.Vector3 target)
        {
            if (target == null)
            {
                return;
            }
            if (E.IsReady())
                E.Cast(target);
        }

        public static void Hawk()
        {
            if (!E.IsReady())
            {
                return;
            }

            if (Config.EDragon)
            {
                Spells.CastE(new Vector3(9865, 4415, 0));
            }
            if (Config.EBaron)
            {
                Spells.CastE(new Vector3(5005, 10470, 0));
            }
        }


        public static void CastR()
        {
            var target = TargetSelector.SelectedTarget;
            if (target == null || !target.IsValidTarget())
                target = TargetSelector.GetTarget(1400, DamageType.Physical);

            if (target.IsValidTarget() && target != null && !target.HasBuff("rebirth") && R.GetPrediction(target).HitChance >= HitChance.Low)
            {
                R.Cast(R.GetPrediction(target).CastPosition);
            }

        }

        public static void CastAoER()
        {
            var target = EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(2000) && !x.IsDead);

            foreach (var t in target)
            {
               if (Config.aoeREnable)
                {
                    if (R.IsReady() && t.IsValidTarget(2000))
                    {
                        if (R.GetPrediction(t).CastPosition.CountEnemiesInRange(300) >= aoeR &&
                            R.GetPrediction(t).HitChance >= HitChance.Medium)
                        {
                            R.Cast(R.GetPrediction(t).CastPosition);
                        }
                    }
                }
            }
        }

        public static void AutoW()
        {
            var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            if (Config.AutoWEnable && W.IsReady() && target.IsValidTarget(W.Range) &&
                User.ManaPercent >= Config.AutoWMana)
            {
                W.Cast(target);
            }
        }

        public static void LogicQ()
        {
            var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);


            if (target != null)
            {
                if (Q.IsReady() && AsheQCastReady && Config.ComboQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                {
                    if (target.IsValidTarget(700))
                    {
                        Q.Cast();
                    }
                }
            }
        }

    }
}
