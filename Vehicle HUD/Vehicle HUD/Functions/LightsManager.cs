using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Threading.Tasks;

namespace Vehicle_HUD.Functions
{
    public class LightsManager : BaseScript
    {
        private static string resourcename = API.GetCurrentResourceName();
        private static string ShowLights = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/LightConfig/ShowHighBeams.ini");
        private static string XPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/LightConfig/XPosition.ini");
        private static string YPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/LightConfig/YPosition.ini");

        private static float XScreenPosition = float.Parse(XPosition);
        private static float YScreenPosition = float.Parse(YPosition);
        public LightsManager()
        {
            Tick += OnTick;
        }
        private static async Task OnTick()
        {
            if (ShowLights == "true" && API.IsPedInAnyVehicle(API.GetPlayerPed(-1), false))
            {
                if (Game.Player.Character.CurrentVehicle.AreHighBeamsOn == false)
                {
                    //Draw HighBeams Off
                    API.SetTextScale(0.4f, 0.4f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~c~HIGHBEAMS");
                    API.DrawText(XScreenPosition, YScreenPosition);
                    API.EndTextComponent();
                }
                else
                {
                    //Draw HighBeams On
                    API.SetTextScale(0.4f, 0.4f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~b~HIGHBEAMS");
                    API.DrawText(XScreenPosition, YScreenPosition);
                    API.EndTextComponent();
                }
            }
        }
    }
}
