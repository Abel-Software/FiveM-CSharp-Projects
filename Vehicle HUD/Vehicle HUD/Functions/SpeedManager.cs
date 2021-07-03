using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Threading.Tasks;

namespace Vehicle_HUD.Functions
{
    public class SpeedManager : BaseScript
    {
        private static float speed;

        private static string resourcename = API.GetCurrentResourceName();
        private static string ShowSpeed = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/SpeedConfig/ShowSpeed.ini");
        private static string XPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/SpeedConfig/XPosition.ini");
        private static string YPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/SpeedConfig/YPosition.ini");

        private static float XScreenPosition = float.Parse(XPosition);
        private static float YScreenPosition = float.Parse(YPosition);

        public SpeedManager()
        {
            Tick += OnTick;
        }

        private static async Task OnTick()
        {
            if (ShowSpeed == "true" && API.IsPedInAnyVehicle(API.GetPlayerPed(-1), false))
            {
                //Get Speed
                float tempspeed = API.GetEntitySpeed(API.GetVehiclePedIsIn(API.GetPlayerPed(-1), false));
                speed = (float)(tempspeed * 2.2369);

                //Draw Speed
                API.SetTextScale(0.5f, 0.5f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Speed: ~b~" + Math.Floor(speed) + " ~w~MPH");
                API.DrawText(XScreenPosition, YScreenPosition);
            }
        }
    }
}
