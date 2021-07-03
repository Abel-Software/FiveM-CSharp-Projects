using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;

namespace BankRobbery.Robberies
{
    public class Harmony
    {
        private static string resourcename = API.GetCurrentResourceName();
        private static string data = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/payouts/Harmony.ini");
        private static int payout = Int32.Parse(data);
        public static async void BeginRobberyAsync()
        {
            //Set robbery state to true
            Main.HarmonyRobbery = true;

            //Disable Control
            Game.Player.CanControlCharacter = false;

            //Make Character Walk to Vault
            API.TaskGoToCoordAnyMeans(Game.Player.Character.Handle, 1176.16f, 2711.87f, 38.08f, 2f, 0, true, 1, 5f);

            //Wait 10 Seconds
            await BaseScript.Delay(7000);

            //Teleport to Vault
            Game.Player.Character.Position = new Vector3(1173.25f, 2711.93f, 38.07f);
            Game.Player.Character.Heading = 3.3f;

            //Give Control
            Game.Player.CanControlCharacter = true;

            //Wait time
            await BaseScript.Delay(23000);

            //Teleport out of Vault
            Game.Player.Character.Position = new Vector3(1175.97f, 2711.78f, 38.09f);
            Game.Player.Character.Heading = 268.29f;

            //Show notification that heist is complete
            Screen.ShowNotification("~g~Robbery Complete");

            //Show Money Being Added
            Screen.ShowNotification("~g~$" + payout + " ~w~added to your balance!");

            //Dispatch Cops
            Game.Player.WantedLevel = 3;

            //Give Money
            Main.SessionIncome += payout;

            //Set robbery state to false
            Main.HarmonyRobbery = false;
        }
    }
}
