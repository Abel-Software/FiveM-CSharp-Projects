using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System.Threading.Tasks;
using Config.Reader;

namespace Vehicle_HUD.Functions
{
    public class SeatBeltManager : BaseScript
    {
        public static bool SeatBelt = false;

        private static string resourcename = API.GetCurrentResourceName();
        private static string UseBelt = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/BeltConfig/UseBelt.ini");
        private static string XPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/BeltConfig/XPosition.ini");
        private static string YPosition = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/BeltConfig/YPosition.ini");
        private static string SeatBeltHotKey = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/BeltConfig/HotKey.ini");

        private static float XScreenPosition = float.Parse(XPosition);
        private static float YScreenPosition = float.Parse(YPosition);
        private static int SeatBeltKey = int.Parse(SeatBeltHotKey);

        public SeatBeltManager()
        {
            Tick += OnTick;
        }

        private static async Task OnTick()
        {
            if (UseBelt == "true" && API.IsPedInAnyVehicle(API.GetPlayerPed(-1), false))
            {
                //Draw Seatbelt Text
                if (SeatBelt)
                {
                    //Draw SeatBelt On
                    API.SetTextScale(0.4f, 0.4f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~g~SEATBELT");
                    API.DrawText(XScreenPosition, YScreenPosition);
                    API.EndTextComponent();

                    //Set Function
                    Game.Player.Character.CanFlyThroughWindscreen = false;
                    API.DisableControlAction(0, 75, true);
                }
                else
                {
                    //Draw SeatBelt Off
                    API.SetTextScale(0.4f, 0.4f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~r~SEATBELT");
                    API.DrawText(XScreenPosition, YScreenPosition);
                    API.EndTextComponent();

                    //Set Function
                    Game.Player.Character.CanFlyThroughWindscreen = true;
                    API.EnableControlAction(0, 75, true);
                }

                //Check for seatbelt Hotkey
                if (API.IsControlJustPressed(0, SeatBeltKey)) // Default Key: [
                {
                    if (SeatBelt)
                    {
                        SeatBelt = false;
                        Screen.ShowNotification("~r~Seatbelt Off");
                    }
                    else
                    {
                        SeatBelt = true;
                        Screen.ShowNotification("~g~Seatbelt On");
                    }
                }
            }
        }
    }
}
