using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Threading.Tasks;

namespace Vehicle_HUD.Functions
{
    public class VehicleManager : BaseScript
    {
        private static bool ShowInfoBool = false;
        public VehicleManager()
        {
            Tick += OnTick;
            API.RegisterCommand("showinfo", new Action(ShowInfo), false);
        }

        private static void ShowInfo()
        {
            if (!ShowInfoBool)
            {
                ShowInfoBool = true;
            }
            else
            {
                ShowInfoBool = false;
            }
        }

        private static async Task OnTick()
        {
            if (ShowInfoBool && API.IsPedInAnyVehicle(API.GetPlayerPed(-1), false))
            {
                //Get Info
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;
                string plate = vehicle.Mods.LicensePlate;
                string model = vehicle.DisplayName;
                string vehclass = vehicle.ClassLocalizedName;
                float enginehealth = vehicle.EngineHealth;
                float enginehealthrounded = (float)(Math.Round(enginehealth));
                int currentgear = vehicle.CurrentGear;
                float rpm = vehicle.CurrentRPM * 10000;
                float rpmrounded = (float)(Math.Round(rpm));

                //Draw Rectangle
                API.DrawRect(0.925f, 0.5f, 0.175f, 0.175f, 0, 0, 0, 150);

                //Display Title
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Vehicle Information");
                API.DrawText(0.865f, 0.41f);
                API.EndTextComponent();

                //Display Plate
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Plate: ~b~" + plate);
                API.DrawText(0.84f, 0.435f);
                API.EndTextComponent();

                //Display Model
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Model: ~b~" + model);
                API.DrawText(0.84f, 0.46f);
                API.EndTextComponent();

                //Display Class
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Class: ~b~" + vehclass);
                API.DrawText(0.84f, 0.485f);
                API.EndTextComponent();

                //Display Engine Health
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Engine Health: ~b~" + enginehealthrounded.ToString() + "/1000");
                API.DrawText(0.84f, 0.51f);
                API.EndTextComponent();

                //Display Current Gear
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Current Gear: ~b~" + currentgear.ToString());
                API.DrawText(0.84f, 0.535f);
                API.EndTextComponent();

                //Display Current RPM
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Current RPM: ~b~" + rpmrounded.ToString());
                API.DrawText(0.84f, 0.56f);
                API.EndTextComponent();
            }
        }
    }
}
