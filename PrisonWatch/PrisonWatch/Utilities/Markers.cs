using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace PrisonWatch.Utilities
{
    public class Markers : BaseScript
    {
        public static List<Vector3> WatchStations;
        public static List<Vector3> DutyStations;
        public Markers()
        {
            //Create Watch Stations
            WatchStations = new List<Vector3>();

            //Add Coordinates to Watch Stations
            WatchStations.Add(new Vector3(1536.27f, 2584.66f, 62.85f));
            WatchStations.Add(new Vector3(1542.04f, 2469.89f, 62.88f));
            WatchStations.Add(new Vector3(1659.47f, 2396.13f, 62.88f));
            WatchStations.Add(new Vector3(1760.98f, 2411.74f, 62.87f));
            WatchStations.Add(new Vector3(1822.91f, 2476.02f, 62.85f));
            WatchStations.Add(new Vector3(1822.48f, 2621.14f, 63.11f));
            WatchStations.Add(new Vector3(1847.26f, 2699.23f, 63.12f));
            WatchStations.Add(new Vector3(1773.09f, 2761.39f, 63.05f));
            WatchStations.Add(new Vector3(1649.99f, 2756.68f, 63.04f));
            WatchStations.Add(new Vector3(1570.63f, 2679.59f, 62.89f));

            //Draw Watch Stations Blips
            foreach (Vector3 WatchStationLocation in WatchStations)
            {
                int WatchStationBlip = API.AddBlipForCoord(WatchStationLocation.X, WatchStationLocation.Y, WatchStationLocation.Z);
                API.SetBlipSprite(WatchStationBlip, 604);
                API.SetBlipColour(WatchStationBlip, 55);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Watch Station");
                API.EndTextCommandSetBlipName(WatchStationBlip);
            }

            //Create Duty Stations
            DutyStations = new List<Vector3>();

            //Add Coordinates to Duty Stations
            DutyStations.Add(new Vector3(1846.47f, 2586.03f, 45.67f));

            //Draw Duty Station Blips
            foreach (Vector3 DutyStationLocation in DutyStations)
            {
                int DutyStationBlip = API.AddBlipForCoord(DutyStationLocation.X, DutyStationLocation.Y, DutyStationLocation.Z);
                API.SetBlipSprite(DutyStationBlip, 189);
                API.SetBlipColour(DutyStationBlip, 55);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Prison Duty Station");
                API.EndTextCommandSetBlipName(DutyStationBlip);
            }

            //Tick
            Tick += CheckMarkers;
            Tick += DrawMarkers;
        }

        private static async Task CheckMarkers()
        {
            //Check Duty Station Markers
            foreach (Vector3 DutyStationLocation in DutyStations)
            {
                float Distance = World.GetDistance(Game.Player.Character.Position, DutyStationLocation);
                if (Distance <= 0.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ toggle duty");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        if (Constructors.IsPlayerGuard)
                        {
                            TriggerServerEvent("PrisonWatch:GoOnDuty");
                            Constructors.IsPlayerGuard = false;
                            //s_m_m_prisguard_01
                        }
                        else
                        {
                            TriggerServerEvent("PrisonWatch:GoOffDuty");
                            Constructors.IsPlayerGuard = true;
                        }
                    }
                }
            }

            if (Constructors.IsPlayerGuard)
            {
                //Check Watch Station Markers
                foreach (Vector3 WatchStationLocation in WatchStations)
                {
                    float Distance = World.GetDistance(Game.Player.Character.Position, WatchStationLocation);
                    if (Distance <= 0.5f)
                    {
                        Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to check in at watch tower");
                        if (API.IsControlJustPressed(0, 38))
                        {
                            TriggerServerEvent("PrisonWatch:WatchStationCheckIn");
                        }
                    }
                }
            }
            
        }

        private static async Task DrawMarkers()
        {
            foreach (Vector3 DutyStation in DutyStations)
            {
                API.DrawMarker(1, DutyStation.X, DutyStation.Y, DutyStation.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }

            foreach (Vector3 WatchStation in WatchStations)
            {
                API.DrawMarker(1, WatchStation.X, WatchStation.Y, WatchStation.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }
        }
    }
}
