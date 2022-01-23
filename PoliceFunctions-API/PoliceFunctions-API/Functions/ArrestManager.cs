using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace PoliceFunctions_API.Functions
{
    public class ArrestManager
    {
        public static void GrabPed()
        {
            //Grab / Drag
            API.AttachEntityToEntity(Arrest.arrestedped.Handle, Game.Player.Character.Handle, 0, 0.1f, 0.5f, 0.0f, 0.0f, 0.0f, 0.0f, false, false, false, false, 0, false);
        }

        public static void UnDragPed()
        {
            //Undo Drag
            API.DetachEntity(Arrest.arrestedped.Handle, true, true);
        }

        public static void SeatFrontPassenger()
        {
            //Seats ped in passenger seat
            Arrest.arrestedped.Task.WarpIntoVehicle(Game.Player.Character.LastVehicle, VehicleSeat.RightFront);
        }

        public static void SeatRearDriver()
        {
            //Seats ped in left rear seat
            Arrest.arrestedped.Task.WarpIntoVehicle(Game.Player.Character.LastVehicle, VehicleSeat.LeftRear);
        }

        public static void SeatRearPassenger()
        {
            //Seats ped in right rear seat
            Arrest.arrestedped.Task.WarpIntoVehicle(Game.Player.Character.LastVehicle, VehicleSeat.RightRear);
        }

        public static void RemoveFromCar()
        {
            //Leave Vehicle
            Arrest.arrestedped.Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);

            //Put Ped back in cuffs
            API.SetEnableHandcuffs(Arrest.arrestedped.Handle, true);

            //Make ped stand still
            Arrest.arrestedped.Task.StandStill(-1);
        }

        public static void ReleasePed()
        {
            //Undo Cuffs
            API.SetEnableHandcuffs(PedManager.ped1.Handle, false);

            //Clear tasks
            Arrest.arrestedped.Task.ClearAll();
            API.ClearPedTasks(Arrest.arrestedped.Handle);

            //Remove Persistent Property
            Arrest.arrestedped.IsPersistent = false;
        }

        public static void JailPed()
        {
            //Make ped no longer persistent
            Arrest.arrestedped.IsPersistent = false;

            //Define Ped to Delete
            int DeletePed = Arrest.arrestedped.Handle;

            //Delete Ped
            API.DeletePed(ref DeletePed);

            //Show Notification
            Screen.ShowNotification("Ped has been jailed");
        }
    }
}
