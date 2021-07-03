using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace Fire_Hydrant_Script.Functions
{
    public class Utility
    {
        //BLIPS
        public static int CurrentHydrantBlip;

        public static async void AttachHose()
        {
            Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
            await BaseScript.Delay(3000);
            Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
            await BaseScript.Delay(1500);
            Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
            await BaseScript.Delay(3000);

            //Execute Hose Command
            API.ExecuteCommand("+-+-+-hose+-+-+");

            Screen.ShowNotification("~g~[SUCCESS] ~w~You have attached the hose!");
            Main.IsHoseConnected = true;
            Main.HoseConnection = Game.Player.Character.Position;

            //DRAW BLIP
            Main.CurrentHydrantBlip = World.CreateBlip(Main.HoseConnection);
            API.SetBlipSprite(Main.CurrentHydrantBlip.GetHashCode(), 502);
        }

        public static async void DetatchHose()
        {
            Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
            await BaseScript.Delay(3000);
            Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
            await BaseScript.Delay(1500);
            Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
            await BaseScript.Delay(3000);

            Screen.ShowNotification("~g~[SUCCESS] ~w~You have detached the hose!");
            API.ExecuteCommand("+-+-+-hose+-+-+");
            Main.IsHoseConnected = false;
        }

        public static void HoseMaxReach()
        {
            Audio.PlaySoundFrontend("Beep_Red", "DLC_HEIST_HACKING_SNAKE_SOUNDS");
            Screen.ShowNotification("~r~[ERROR] ~w~Hose length reached. Hose has been disconnected!");
            API.ExecuteCommand("+-+-+-hose+-+-+");
            Main.IsHoseConnected = false;
        }

        public static void EnteredVehicle()
        {
            Audio.PlaySoundFrontend("Beep_Red", "DLC_HEIST_HACKING_SNAKE_SOUNDS");
            Screen.ShowNotification("~r~[ERROR] ~w~Cannot enter vehicle while using hose");
            API.ExecuteCommand("+-+-+-hose+-+-+");
            Main.IsHoseConnected = false;
        }
    }
}
