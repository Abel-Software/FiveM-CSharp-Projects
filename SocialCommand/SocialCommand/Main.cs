using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;

namespace SocialCommand
{
    public class Main : BaseScript
    {
        private static string resourcename = API.GetCurrentResourceName();
        public static string Discord = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/Discord.ini");
        public static string YouTube = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/YouTube.ini");
        public static string Website = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/Website.ini");
        public static string TeamSpeak = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/TeamSpeak.ini");

        public Main()
        {
            API.RegisterCommand("discord", new Action(ShowDiscord), false);
            API.RegisterCommand("youtube", new Action(ShowYouTube), false);
            API.RegisterCommand("website", new Action(ShowWebsite), false);
            API.RegisterCommand("teamspeak", new Action(ShowTeamSpeak), false);
        }

        private static void ShowDiscord()
        {
            Screen.ShowNotification("∑ ~b~Discord:~w~ " + Discord);
        }

        private static void ShowYouTube()
        {
            Screen.ShowNotification("∑ ~b~YouTube:~w~ " + YouTube);
        }

        private static void ShowWebsite()
        {
            Screen.ShowNotification("∑ ~b~Website:~w~ " + Website);
        }

        private static void ShowTeamSpeak()
        {
            Screen.ShowNotification("∑ ~b~TeamSpeak:~w~ " + TeamSpeak);
        }
    }
}
