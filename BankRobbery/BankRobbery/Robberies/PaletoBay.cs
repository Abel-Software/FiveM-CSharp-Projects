using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;

namespace BankRobbery.Robberies
{
    public class PaletoBay
    {
        private static string resourcename = API.GetCurrentResourceName();
        private static string data = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/payouts/PaletoBay.ini");
        private static int payout = Int32.Parse(data);
        public static async void BeginRobberyAsync()
        {
            //Set robbery state to true
            Main.PaletoBay = true;

            //Wait time
            await BaseScript.Delay(45000);

            //Show notification that heist is complete
            Screen.ShowNotification("~g~Robbery Complete");

            //Show Money Being Added
            Screen.ShowNotification("~g~$" + payout + " ~w~added to your balance!");

            //Dispatch Cops
            Game.Player.WantedLevel = 3;

            //Give Money
            Main.SessionIncome += payout;

            //Set robbery state to false
            Main.PaletoBay = false;
        }
    }
}
