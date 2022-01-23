using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceFunctions_API.Functions
{
    public class VehicleManager
    {
        public static Vehicle stoppedvehicle;
        public static Ped stoppedvehicledriver;
        public static async Task<Vehicle> StopVehicle()
        {
            //Get Vehicle
            Vehicle[] allVehicles = World.GetAllVehicles();
            if (allVehicles.Length == 0)
                return (Vehicle)null;
            float num = float.MaxValue;
            stoppedvehicle = (Vehicle)null;
            foreach (Vehicle vehicle2 in allVehicles)
            {
                if (!Entity.Equals((Entity)Game.PlayerPed.CurrentVehicle, (Entity)vehicle2))
                {
                    float distance = World.GetDistance(((Entity)vehicle2).Position, ((Entity)Game.PlayerPed).Position);
                    if ((double)distance < (double)num)
                    {
                        stoppedvehicle = vehicle2;
                        num = distance;
                    }
                }
            }

            //Get Distance
            float distancecheck = World.GetDistance(Game.Player.Character.Position, stoppedvehicle.Position);

            //Do Pullover if close
            if (distancecheck <= 10.0f)
            {
                //Set driver
                stoppedvehicledriver = stoppedvehicle.Driver;

                //Make driver and car persistent
                stoppedvehicle.IsPersistent = true;
                stoppedvehicledriver.IsPersistent = true;

                //Slow Speed
                stoppedvehicle.Speed = stoppedvehicle.Speed - 10;

                //await
                await BaseScript.Delay(3500);

                //Slow Speed
                stoppedvehicle.Speed = 10;

                //await
                await BaseScript.Delay(3500);

                //Slow Speed
                stoppedvehicle.Speed = 5;

                //await
                await BaseScript.Delay(3500);

                //Stop Car
                stoppedvehicle.Speed = 0;
                stoppedvehicle.IsPositionFrozen = true;
            }

            //Return
            return stoppedvehicle;
        }

         public static void ReleaseVehicle()
         {
            //Turn Engine On
            stoppedvehicle.IsEngineRunning = true;

            //Unfreeze Position
            stoppedvehicle.IsPositionFrozen = false;

            //Mark as un-needed
            stoppedvehicle.IsPersistent = false;
         }
        }
    }
