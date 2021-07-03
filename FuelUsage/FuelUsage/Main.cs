using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelUsage
{
    public class Main : BaseScript
    {
        public Main()
        {
            Tick += OnTick;
            API.RegisterCommand("refuel", new Action(Refuel), false);
        }

        private static void Refuel()
        {
            Game.Player.Character.CurrentVehicle.FuelLevel = 100;
        }

        private static async Task OnTick()
        {
            //Get Fuel
            float tempfuel = Game.Player.Character.CurrentVehicle.FuelLevel;
            float fuel = (float)(Math.Round(tempfuel));

            if (API.IsPedInAnyVehicle(API.GetPlayerPed(-1), false))
            {
                if (fuel == 0)
                {
                    //Show Text
                    API.SetTextScale(0.5f, 0.5f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~r~OUT OF FUEL");
                    API.DrawText(0.45f, 0.45f);

                    //Disable Engine
                    Game.Player.Character.CurrentVehicle.IsEngineRunning = false;
                }
                else
                {
                    //Use Fuel
                    Game.Player.Character.CurrentVehicle.FuelLevel = (float)(Game.Player.Character.CurrentVehicle.FuelLevel - 0.001);

                    //Disable Engine
                    Game.Player.Character.CurrentVehicle.IsEngineRunning = true;
                }
            }
        }
    }
}
