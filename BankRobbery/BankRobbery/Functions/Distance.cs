using CitizenFX.Core;
using CitizenFX.Core.UI;
using NativeUI;

namespace BankRobbery.Functions
{
    public class Distance
    {
        private static float HarmonyDistance;
        private static float PaletoDistance;
        private static float GOHDistance;
        private static float VinewoodDistance;
        public static void CheckDistance()
        {
            //Harmony
            HarmonyDistance = World.GetDistance(Game.Player.Character.Position, Resources.Locations.HarmonyFleeca);
            if (!Main.HarmonyRobbery & HarmonyDistance <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~b~E~w~ to begin bank robbery. This robbery takes ~y~30~w~ seconds!");

                if (!Main.HarmonyRobbery & Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Screen.ShowNotification("~g~Beginning robbery...");
                    Robberies.Harmony.BeginRobberyAsync();
                }
            }

            //Paleto Bay
            PaletoDistance = World.GetDistance(Game.Player.Character.Position, Resources.Locations.PaletoBay);
            if (!Main.PaletoBay & PaletoDistance <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~b~E~w~ to begin bank robbery. This robbery takes ~y~45~w~ seconds!");

                if (!Main.PaletoBay & Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Screen.ShowNotification("~g~Beginning robbery...");
                    Robberies.PaletoBay.BeginRobberyAsync();
                }
            }

            //Great Ocean Highway
            GOHDistance = World.GetDistance(Game.Player.Character.Position, Resources.Locations.GOH);
            if (!Main.GOH & GOHDistance <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~b~E~w~ to begin bank robbery. This robbery takes ~y~30~w~ seconds!");

                if (!Main.GOH & Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Screen.ShowNotification("~g~Beginning robbery...");
                    Robberies.GOH.BeginRobberyAsync();
                }
            }

            //Vinewood
            VinewoodDistance = World.GetDistance(Game.Player.Character.Position, Resources.Locations.Vinewood);
            if (!Main.Vinewood & VinewoodDistance <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~b~E~w~ to begin bank robbery. This robbery takes ~y~300~w~ seconds!");

                if (!Main.Vinewood & Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Screen.ShowNotification("~g~Beginning robbery...");
                    Robberies.Vinewood.BeginRobberyAsync();
                }
            }
        }
    }
}
