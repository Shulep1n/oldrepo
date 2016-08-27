using WorstAshe.Ext;
using static WorstAshe.Ext.Config;
using static WorstAshe.Ext.Spells;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace WorstAshe.Ext
{
    internal class Active
    {
        public static Item Botrk, Bil, Youmu;
        public static Spell.Active HEAL { get; private set; }
        public static Spell.Active BARRIER { get; private set; }


        public static void Items()
        {
            //Blue Trinket
            if (Orb && User.Level >= 9 && User.IsInShopRange() && !(User.HasItem(3342) || User.HasItem(3363)))
            {
                Shop.BuyItem(3363);
            }

            //Item Manager
            Botrk = new Item(3153, 450f);
            Bil = new Item(3144, 450f);
            Youmu = new Item(3142);

            //Summ
            var slotheal = User.GetSpellSlotFromName("summonerheal");
            var slotbar = User.GetSpellSlotFromName("summonerbarrier");

            if (slotheal != SpellSlot.Unknown)
                HEAL = new Spell.Active(slotheal, 850);
            if (slotbar != SpellSlot.Unknown)
                BARRIER = new Spell.Active(slotbar, 0);

            if (Config.SumEnable)
            {
                if (User.HealthPercent <= Config.healmisc && HEAL.IsReady())
                {
                    HEAL.Cast();
                }
                if (User.HealthPercent <= Config.barmisc && BARRIER.IsReady())
                {
                    BARRIER.Cast();
                }
            }



            //Items Usage
            var target = TargetSelector.GetTarget(450, DamageType.Physical);
            var Ytarget = TargetSelector.GetTarget(800, DamageType.Physical);

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                if (Config.BotrkCombo && Botrk.IsReady() && Botrk.IsOwned() && target.IsValidTarget(450) &&
                    (User.HealthPercent <= MyBotrkHp || target.HealthPercent < EnBotrkHp))
                {
                    Botrk.Cast(target);
                }

                if (Config.BilCombo && Bil.IsOwned() && Bil.IsReady() && target.IsValidTarget(450))
                {
                    Bil.Cast(target);
                }

                if (Config.YoumuCombo && Youmu.IsOwned() && Youmu.IsReady() && Ytarget.IsValidTarget())
                {
                    Youmu.Cast();
                }
            }            
        }
    }
}
