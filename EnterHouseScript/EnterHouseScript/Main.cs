using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Threading.Tasks;

namespace EnterHouseScript
{
    public class Main : BaseScript
    {
        public Main()
        {
            Tick += OnTick;
            API.RegisterCommand("cop", new Action(SetCop), false);
        }

        private static void SetCop()
        {
            API.SetPedAsCop(API.GetPlayerPed(-1), true);
        }

        private static async Task OnTick()
        {
            //Register Locations
            Resources.Locations.RegisterLocations();

            //Draw Markers
            Resources.Markers.DrawMarkers();

            //Check Markers
            Resources.Markers.CheckDistance();
        }
    }
}
