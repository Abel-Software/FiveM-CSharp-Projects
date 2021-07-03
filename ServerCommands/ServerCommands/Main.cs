using System;
using System.Windows;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace ServerCommands
{
    public class Main : BaseScript
    {
        private static string resourcename = API.GetCurrentResourceName();
        public static string Help = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/help.ini");
        public static string DonateLink = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/donate.ini");

        public Main()
        {
            API.RegisterCommand("help", new Action(ShowHelp), false);
            API.RegisterCommand("donate", new Action(Donate), false);
            EventHandlers["playerSpawned"] += new Action(playerSpawned);
        }

        private static void ShowHelp()
        {
            Screen.ShowNotification(Help);
        }

        private static void Donate()
        {
            Screen.ShowNotification("Donate link: " + DonateLink);
        }

        private static void playerSpawned()
        {
            Screen.ShowNotification("Do /help for server information!");
        }
    }
}
