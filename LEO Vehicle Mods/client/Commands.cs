using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using NativeUI;

namespace client
{
    public class Commands : BaseScript
    {
        public Commands()
        {
            API.RegisterCommand("dv", new Action(DeleteVehicle), false);
        }

        private static void DeleteVehicle()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                String vehiclename = Game.Player.Character.CurrentVehicle.DisplayName;
                int vehicle = API.GetVehiclePedIsIn(API.GetPlayerPed(-1), true);
                API.DeleteVehicle(ref vehicle);
                BigMessageThread.MessageInstance.ShowMissionPassedMessage($"~b~{vehiclename}~w~ has been deleted");
            }
        }
    }
}
