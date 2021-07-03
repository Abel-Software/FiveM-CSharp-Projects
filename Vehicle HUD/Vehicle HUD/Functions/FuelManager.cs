using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Threading.Tasks;

namespace Vehicle_HUD.Functions
{
    public class FuelManager : BaseScript
    {
        private static float fuel;
        private static string resourcename = API.GetCurrentResourceName();
        private static string ShowFuel = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/FuelConfig/ShowFuel.ini");
        private static string XPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/FuelConfig/XPosition.ini");
        private static string YPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/FuelConfig/YPosition.ini");

        private static float XScreenPosition = float.Parse(XPosition);
        private static float YScreenPosition = float.Parse(YPosition);

        public FuelManager()
        {
            Tick += OnTick;
        }

        private static async Task OnTick()
        {
            if (ShowFuel == "true" && API.IsPedInAnyVehicle(API.GetPlayerPed(-1), false))
            {
                //Get Fuel
                float tempfuel = Game.Player.Character.CurrentVehicle.FuelLevel;
                fuel = (float)(Math.Round(tempfuel));

                //Draw Fuel
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Fuel: ~b~" + fuel);
                API.DrawText(XScreenPosition, YScreenPosition);
            }
        }
    }
}
