using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;

namespace BankRobbery.Robberies
{
    public class GOH
    {
        private static string resourcename = API.GetCurrentResourceName();
        private static string data = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/payouts/GOH.ini");
        private static int payout = Int32.Parse(data);
        public static async void BeginRobberyAsync()
        {
            //Set robbery state to true
            Main.GOH = true;

            //Disable Control
            Game.Player.CanControlCharacter = false;

            //Make Character Walk to Vault
            API.TaskGoToCoordAnyMeans(Game.Player.Character.Handle, -2957.64f, 481.74f, 15.7f, 2f, 0, true, 1, 5f);

            //Wait 10 Seconds
            await BaseScript.Delay(7000);

            //Teleport to Vault
            Game.Player.Character.Position = new Vector3(-2957.4f, 484.59f, 15.69f);
            Game.Player.Character.Heading = 263.95f;

            //Give Control
            Game.Player.CanControlCharacter = true;

            //Wait time
            await BaseScript.Delay(23000);

            //Teleport out of Vault
            Game.Player.Character.Position = new Vector3(-2957.64f, 481.74f, 15.7f);
            Game.Player.Character.Heading = 198.04f;

            //Show notification that heist is complete
            Screen.ShowNotification("~g~Robbery Complete");

            //Show Money Being Added
            Screen.ShowNotification("~g~$" + payout + " ~w~added to your balance!");

            //Dispatch Cops
            Game.Player.WantedLevel = 3;

            //Give Money
            Main.SessionIncome += payout;

            //Set robbery state to false
            Main.GOH = false;
        }
    }
}
