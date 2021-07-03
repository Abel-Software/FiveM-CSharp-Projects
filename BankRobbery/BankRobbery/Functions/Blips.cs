using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace BankRobbery.Functions
{
    public class Blips
    {
        public static void DrawBlips()
        {
            //Harmony Fleeca
            int HarmonyBlip = API.AddBlipForCoord(Resources.Locations.HarmonyFleeca.X, Resources.Locations.HarmonyFleeca.Y, Resources.Locations.HarmonyFleeca.Z);
            API.SetBlipSprite(HarmonyBlip, 108);
            API.SetBlipColour(HarmonyBlip, 2);

            //Paleto Bay Fleeca
            int PaletoBayBlip = API.AddBlipForCoord(Resources.Locations.PaletoBay.X, Resources.Locations.PaletoBay.Y, Resources.Locations.PaletoBay.Z);
            API.SetBlipSprite(PaletoBayBlip, 108);
            API.SetBlipColour(PaletoBayBlip, 2);

            //Great Ocean Highway
            int GOH = API.AddBlipForCoord(Resources.Locations.GOH.X, Resources.Locations.GOH.Y, Resources.Locations.GOH.Z);
            API.SetBlipSprite(GOH, 108);
            API.SetBlipColour(GOH, 2);

            //Vinewood
            int Vinewood = API.AddBlipForCoord(Resources.Locations.Vinewood.X, Resources.Locations.Vinewood.Y, Resources.Locations.Vinewood.Z);
            API.SetBlipSprite(Vinewood, 108);
            API.SetBlipColour(Vinewood, 2);
        }
    }
}
