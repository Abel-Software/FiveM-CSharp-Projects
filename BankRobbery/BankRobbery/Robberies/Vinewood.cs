using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;

namespace BankRobbery.Robberies
{
    public class Vinewood
    {
        private static string resourcename = API.GetCurrentResourceName();
        private static string data = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/payouts/Vinewood.ini");
        private static int payout = Int32.Parse(data);
        public static async void BeginRobberyAsync()
        {
            //Set robbery state to true
            Main.Vinewood = true;

            //Disable Control
            Game.Player.CanControlCharacter = false;

            //Make Character Walk to Vault
            API.TaskGoToCoordAnyMeans(Game.Player.Character.Handle, 254.25f, 225.8f, 101.88f, 2f, 0, true, 1, 5f);

            //Wait 10 Seconds
            await BaseScript.Delay(25000);

            //Teleport to Vault
            Game.Player.Character.Position = new Vector3(253f, 223.19f, 101.69f);
            Game.Player.Character.Heading = 162.44f;

            //Give Control
            Game.Player.CanControlCharacter = true;

            //Wait time
            await BaseScript.Delay(275000);

            //Show notification that heist is complete
            Screen.ShowNotification("~g~Robbery Complete");

            //Show Money Being Added
            Screen.ShowNotification("~g~$" + payout + " ~w~added to your balance!");

            //Dispatch Cops
            Game.Player.WantedLevel = 3;

            //Give Money
            Main.SessionIncome += payout;

            //Set robbery state to false
            Main.Vinewood = false;
        }
    }
}
