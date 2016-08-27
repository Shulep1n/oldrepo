using System;
using System.Configuration;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using color = System.Drawing.Color;
using static WorstAshe.Ext.Spells;
using static WorstAshe.Ext.Config;
using static WorstAshe.Ext.AutoLevel;


namespace WorstAshe.Ext
{
    internal class Events
    {
        public static void Init()
        {
            Game.OnTick += GameOnTick;
            Interrupter.OnInterruptableSpell += InterrupterOnInterruptableSpell;
            Drawing.OnDraw += DrawingOnDraw;
            Gapcloser.OnGapcloser += GapcloserOnGapcloser;
            Obj_AI_Base.OnProcessSpellCast += ObjAiBaseOnProcessSpellCast;
            
            
        }

       


        private static void ObjAiBaseOnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!Config.Eflash || sender.Team == ObjectManager.Player.Team)
            {
                return;
            }

            if (args.SData.Name.ToLower() == "summonerflash" && sender.Distance(ObjectManager.Player.Position) < 2000)
            {
                E.Cast(args.End);
            }
        }

        private static void InterrupterOnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs interruptableSpellEventArgs)
        {
            if (User.IsRecalling() || !sender.IsEnemy)
            {
                return;
            }
            if (Config.Int && R.IsReady() && interruptableSpellEventArgs.DangerLevel == DangerLevel.High &&
                W.IsInRange(sender))
            {
                R.Cast(sender);
            }
        }


        private static void GapcloserOnGapcloser(Obj_AI_Base sender, Gapcloser.GapcloserEventArgs gapcloserEventArgs)
        {
            if (Config.Gap && gapcloserEventArgs.Sender.Distance(User) < 600)
            {
                R.Cast(gapcloserEventArgs.Sender);
            }
        }

        private static void DrawingOnDraw(EventArgs args)
        {
            
            if (User.IsDead)
            {
                return;
            }

            


            if (Config.DrawW && W.IsReady())
            {
                new Circle()
                {
                    BorderWidth = 2,
                    Color = color.Red,
                    Radius = W.Range
                }.Draw(User.Position);
            }
           /* if (Config.DrawQ && Q.IsReady())
            {
                new Circle()
                {
                    BorderWidth = 2,
                    Color = color.Orchid,
                    Radius = 700
                }.Draw(User.Position);
            } */
        }

        private static void GameOnTick(EventArgs args)
        {
            if (Config.skinEnable)
            {
                User.SetSkinId(Config.skinID);
            }

            if (Config.Combo["RManualCast"].Cast<KeyBind>().CurrentValue)
            {
                CastR();
            }

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Modes.Combo.Execute();
            }

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                Modes.Harass.Execute();
            }

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                Modes.LaneClear.Execute();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                Modes.JungleClear.Execute();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
            {
                Modes.Flee.Execute();
            }

            CastAoER();
            Modes.KillSteal.Execute();
            Active.Items();
            Spells.Hawk();
            Spells.AutoW();
            AutoLevel.Execute();
            
            
        }
    }
}
