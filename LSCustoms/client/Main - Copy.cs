using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace ESXLSTowing
{
    public class Main : BaseScript
    {
        public static string Author = "Abel Gaming";
        public static string ModName = "ESX LS Towing";
        public static string Version = "1.0";
        
        public Main()
        {
            Tick += OnTick;
            API.RegisterCommand("testcommand", new Action(CommandAction), false);
        }
        
        private static void CommandAction()
        {
            TriggerServerEvent("NJRP:GiveMoney", 1000);
            TriggerEvent("swt_notifications:Icon","Money Given","top-right",2500,"green-10","white",true,"mdi-currency-usd");
        }

        private static async Task OnTick()
        {

        }
    }
}