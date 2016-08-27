using System;
using WorstAshe.Ext;
using EloBuddy.SDK.Events;
using static WorstAshe.Ext.Config;

namespace WorstAshe
{
    class Program
    {
        static void Main()
        {
            Loading.OnLoadingComplete += LoadingComplete;
        }

        private static void LoadingComplete(EventArgs args)
        {
            if (User.ChampionName != "Ashe")
            {
                return;
            }

            Config.Init();
            Spells.Init();
            Events.Init();
            
        }
    }
}
