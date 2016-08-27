using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace WorstAshe.Ext
{
    internal class Config
    {
        public static AIHeroClient User => Player.Instance;

        public static Menu Settings, Combo, Harass, LaneClear, JungleClear, KillSteal, Misc;

        public static void Init()
        {
            Settings = MainMenu.AddMenu("Worst Ashe", "Ashe");
            Settings.AddGroupLabel("Skin Changer");
            Settings.Add("skinEnable", new CheckBox("Enable"));
            Settings.Add("skinID", new ComboBox("Current Skin", 8, "Default Ashe", "Freljord Ashe", "Sherwood Forest Ashe", "Woad Ashe", "Queen Ashe", "Amethyst Ashe", "Heartseeker Ashe", "Marauder Ashe", "PROJECT: Ashe"));
            Settings.AddGroupLabel("Auto Level");
            Settings.Add("ALEnable", new CheckBox("Enable"));
            Settings.Add("ALBox", new ComboBox("Level Up Mode", 1, "R>Q>W>E", "R>W>Q>E"));
            Settings.Add("Delay", new Slider("Max. delay value", 500, 0, 10000));

            //Combo Menu
            Combo = Settings.AddSubMenu("Combo", "ComboMenu");

            Combo.AddGroupLabel("Combo Settings");
            Combo.Add("ComboQ", new CheckBox("Use Q"));           
            Combo.Add("ComboW", new CheckBox("Use W"));
            Combo.Add("ComboR", new CheckBox("Use R"));            
            Combo.AddGroupLabel("Combo R Settings");
            Combo.Add("minRRange", new Slider("Min. Range", 200, 200, 1000));
            Combo.Add("maxRRange", new Slider("Max. Range", 500, 500, 2000));
            Combo.Add("HP", new Slider("Min. HP (%)", 35, 0, 100));
            Combo.AddGroupLabel("Aoe R Settings");
            Combo.Add("aoeREnable", new CheckBox("Enable"));
            Combo.Add("aoeR", new Slider("Use R if hit X Enemies", 3, 1, 5));
            Combo.AddGroupLabel("Manual R to selected target");
            Combo.Add("RManualCast", new KeyBind("Manual R", false, KeyBind.BindTypes.HoldActive, 'T'));
            Combo.AddGroupLabel("Item Settings");
            Combo.Add("BilCombo", new CheckBox("Use Cutlass"));
            Combo.Add("YoumuCombo", new CheckBox("Use Ghostblade"));
            Combo.Add("BotrkCombo", new CheckBox("Use BOTRK"));
            Combo.Add("MyBotrkHp", new Slider("Min. HP for using BOTRK (%)", 50, 0, 100));
            Combo.Add("EnBotrkHp", new Slider("Min. Enemy HP for using BOTRK (%)", 50, 0, 100));


            //Harass Menu
            Harass = Settings.AddSubMenu("Harass", "HarassMenu");

            Harass.AddGroupLabel("Harass Settings");
            Harass.Add("HarassW", new CheckBox("Use W"));
            Harass.AddGroupLabel("Mana Manager");
            Harass.Add("HarassWMana", new Slider("Min. mana for using W (%)", 70, 0, 100));

            //LaneClear Menu
            LaneClear = Settings.AddSubMenu("Lane Clear", "LaneClearMenu");

            LaneClear.AddGroupLabel("Lane Clear Settings");
            LaneClear.Add("LaneClearQ", new CheckBox("Use Q"));
            LaneClear.Add("LaneClearW", new CheckBox("Use W"));
            LaneClear.AddGroupLabel("Mana Manager");
            LaneClear.Add("LaneClearQMana", new Slider("Min. mana for using Q (%)", 20, 0, 100));
            LaneClear.Add("LaneClearWMana", new Slider("Min. mana for using W (%)", 50, 0, 100));

            //JungleClear Menu
            JungleClear = Settings.AddSubMenu("Jungle Clear", "JungleClearMenu");

            JungleClear.AddGroupLabel("Jugnle Clear Settings");
            JungleClear.Add("JungleClearQ", new CheckBox("Use Q"));
            JungleClear.Add("JungleClearW", new CheckBox("Use W"));
            JungleClear.AddGroupLabel("Mana Manager");
            JungleClear.Add("JungleClearQMana", new Slider("Min. mana for using Q (%)", 20, 0, 100));
            JungleClear.Add("JungleClearWMana", new Slider("Min. mana for using w (%)", 50, 0, 100));

            //KillSteal Menu
            KillSteal = Settings.AddSubMenu("Kill Steal", "KSMenu");

            KillSteal.AddGroupLabel("KS Settings");
            KillSteal.Add("KSW", new CheckBox("Use W"));
            KillSteal.Add("KSR", new CheckBox("Use R"));

            //Misc
            Misc = Settings.AddSubMenu("Misc", "MiscMenu");

            Misc.AddGroupLabel("Draw Settings");
            Misc.Add("DrawW", new CheckBox("Draw W"));
            Misc.Add("DrawTarget", new CheckBox("Draw target"));
            //Misc.Add("DrawQ", new CheckBox("Draw Q"));
            Misc.AddGroupLabel("Auto W Settings");
            Misc.Add("AutoWEnable", new CheckBox("Use Auto W"));
            Misc.Add("AutoWMana", new Slider("Min. mana for using W (%)", 70, 0, 100));
            Misc.AddGroupLabel("Hawkshot Settings");
            Misc.Add("Eflash", new CheckBox("Use E against Flashes"));
            Misc.Add("EDragon", new KeyBind("Cast E to Dragon", false, KeyBind.BindTypes.HoldActive, 'U'));
            Misc.Add("EBaron", new KeyBind("Cast E to Baron", false, KeyBind.BindTypes.HoldActive, 'I'));
            


            Misc.AddGroupLabel("Misc");
            Misc.Add("Orb", new CheckBox("Buy Blue Trinket on Level 9"));
            Misc.Add("Gap", new CheckBox("Use Anti Gapcloser"));
            Misc.Add("Int", new CheckBox("Use Interrupt"));
            
            Misc.AddGroupLabel("Summoner Spell Settings");
            Misc.Add("SumEnable", new CheckBox("Enable"));
            Misc.Add("healmisc", new Slider("Use Heal if HP < (%) ", 15, 0, 100));
            Misc.Add("barmisc", new Slider("Use Barrier if HP < (%) ", 25, 0, 100));


        }

        //Combo Values
        public static bool ComboQ => Combo["ComboQ"].Cast<CheckBox>().CurrentValue;
        public static bool ComboW => Combo["ComboW"].Cast<CheckBox>().CurrentValue;
        public static bool ComboR => Combo["ComboR"].Cast<CheckBox>().CurrentValue;
        public static int maxRRange => Combo["maxRRange"].Cast<Slider>().CurrentValue;
        public static int minRRange => Combo["minRRange"].Cast<Slider>().CurrentValue;
        public static int HP => Combo["HP"].Cast<Slider>().CurrentValue;
        public static bool YoumuCombo => Combo["YoumuCombo"].Cast<CheckBox>().CurrentValue;
        public static bool BotrkCombo => Combo["BotrkCombo"].Cast<CheckBox>().CurrentValue;
        public static bool BilCombo => Combo["BilCombo"].Cast<CheckBox>().CurrentValue;
        public static int MyBotrkHp => Combo["MyBotrkHp"].Cast<Slider>().CurrentValue;
        public static int EnBotrkHp => Combo["EnBotrkHp"].Cast<Slider>().CurrentValue;
        public static bool aoeREnable => Combo["aoeREnable"].Cast<CheckBox>().CurrentValue;
        public static int aoeR => Combo["aoeR"].Cast<Slider>().CurrentValue;

        //Harass Values
        public static bool HarassW => Harass["HarassW"].Cast<CheckBox>().CurrentValue;
        public static int HarassWMana => Harass["HarassWMana"].Cast<Slider>().CurrentValue;

        //LaneClear Values
        public static bool LaneClearQ => LaneClear["LaneClearQ"].Cast<CheckBox>().CurrentValue;
        public static bool LaneClearW => LaneClear["LaneClearW"].Cast<CheckBox>().CurrentValue;
        public static int LaneClearQMana => LaneClear["LaneClearQMana"].Cast<Slider>().CurrentValue;
        public static int LaneClearWMana => LaneClear["LaneClearWMana"].Cast<Slider>().CurrentValue;

        //JungleClear Values
        public static bool JungleClearQ => JungleClear["JungleClearQ"].Cast<CheckBox>().CurrentValue;
        public static bool JungleClearW => JungleClear["JungleClearW"].Cast<CheckBox>().CurrentValue;
        public static int JungleClearQMana => LaneClear["JungleClearQMana"].Cast<Slider>().CurrentValue;
        public static int JungleClearWMana => LaneClear["JungleClearWMana"].Cast<Slider>().CurrentValue;

        //KS Values
        public static bool KSW => KillSteal["KSW"].Cast<CheckBox>().CurrentValue;
        public static bool KSR => KillSteal["KSR"].Cast<CheckBox>().CurrentValue;

        //Misc Values
        public static bool DrawW => Misc["DrawW"].Cast<CheckBox>().CurrentValue;
        public static bool DrawQ => Misc["DrawQ"].Cast<CheckBox>().CurrentValue;
        public static bool Orb => Misc["Orb"].Cast<CheckBox>().CurrentValue;
        public static bool Gap => Misc["Gap"].Cast<CheckBox>().CurrentValue;
        public static bool Int => Misc["Int"].Cast<CheckBox>().CurrentValue;
        public static bool Eflash => Misc["Eflash"].Cast<CheckBox>().CurrentValue;
        public static int healmisc => Misc["healmisc"].Cast<Slider>().CurrentValue;
        public static int barmisc => Misc["barmisc"].Cast<Slider>().CurrentValue;
        public static bool EEnable => Misc["EEnable"].Cast<CheckBox>().CurrentValue;
        public static bool EDragon => Misc["EDragon"].Cast<KeyBind>().CurrentValue;
        public static bool EBaron => Misc["EBaron"].Cast<KeyBind>().CurrentValue;
        public static bool AutoWEnable => Misc["AutoWEnable"].Cast<CheckBox>().CurrentValue;
        public static int AutoWMana => Misc["AutoWMana"].Cast<Slider>().CurrentValue;
        public static bool SumEnable => Misc["SumEnable"].Cast<CheckBox>().CurrentValue;
        public static bool DrawTarget => Misc["DrawTarget"].Cast<CheckBox>().CurrentValue;

        //Skin
        public static bool skinEnable => Settings["skinEnable"].Cast<CheckBox>().CurrentValue;
        public static int skinID => Settings["skinID"].Cast<ComboBox>().CurrentValue;

        //Auto Level
        public static bool ALEnable => Settings["ALEnable"].Cast<CheckBox>().CurrentValue;
        public static int Delay => Settings["Delay"].Cast<Slider>().CurrentValue;
        

    }
}
