using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace BankRobbery.Functions
{
    public class Markers
    {
        public static void DrawMarkers()
        {
            //Harmony Fleeca
            if (!Main.HarmonyRobbery)
            {
                API.DrawMarker(1, Resources.Locations.HarmonyFleeca.X, Resources.Locations.HarmonyFleeca.Y, Resources.Locations.HarmonyFleeca.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }

            if (!Main.PaletoBay)
            {
                API.DrawMarker(1, Resources.Locations.PaletoBay.X, Resources.Locations.PaletoBay.Y, Resources.Locations.PaletoBay.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }

            if (!Main.GOH)
            {
                API.DrawMarker(1, Resources.Locations.GOH.X, Resources.Locations.GOH.Y, Resources.Locations.GOH.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }

            if (!Main.Vinewood)
            {
                API.DrawMarker(1, Resources.Locations.Vinewood.X, Resources.Locations.Vinewood.Y, Resources.Locations.Vinewood.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }
        }
    }
}
