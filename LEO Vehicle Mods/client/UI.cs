using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client
{
    public class UI : BaseScript
    {
        public UI()
        {
            Tick += EnteringVehicle;
        }

        private static async Task EnteringVehicle()
        {
            if (API.IsPedGettingIntoAVehicle(API.GetPlayerPed(-1)))
            {
                int vehicle = API.GetVehiclePedIsEntering(API.GetPlayerPed(-1));
                if (API.GetVehicleClass(vehicle) == 18)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_ENTER_CHEAT_CODE~ to access vehicle modifications");
                }
            }
        }
    }
}
