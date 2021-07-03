using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Threading.Tasks;

namespace Vehicle_HUD.Functions
{
    public class LocationManager : BaseScript
    {
        private static string resourcename = API.GetCurrentResourceName();
        private static string ShowStreet = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/StreetConfig/ShowStreet.ini");
        private static string XPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/StreetConfig/XPosition.ini");
        private static string YPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/StreetConfig/YPosition.ini");

        private static float XScreenPosition = float.Parse(XPosition);
        private static float YScreenPosition = float.Parse(YPosition);
        public LocationManager()
        {
            Tick += OnTick;
        }

        private static async Task OnTick()
        {
            if (ShowStreet == "true")
            {
                //Get Street
                string currentStreet = World.GetStreetName(Game.Player.Character.Position);

                //Draw Street
                API.SetTextScale(0.3f, 0.3f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~" + currentStreet);
                API.DrawText(XScreenPosition, YScreenPosition);
            }
        }
    }
}
