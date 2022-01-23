using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace PoliceFunctions_API.Functions
{
    public class Arrest
    {
        public static Ped arrestedped;

        public static void ArrestPed()
        {
            //Request Animation
            API.RequestAnimDict("mp_arresting");

            //Set heading for ped
            API.TaskAchieveHeading(PedManager.ped1.Handle, Game.Player.Character.Heading, 1000);

            //Play animation for cuffing
            Game.Player.Character.Task.PlayAnimation("mp_arresting", "a_uncuff");

            //Play ped animation
            PedManager.ped1.Task.PlayAnimation("mp_arresting", "idle", 8f, -1, AnimationFlags.Loop);

            //Set Handcuffs
            API.SetEnableHandcuffs(PedManager.ped1.Handle, true);

            //Set ped1 as arrestped
            arrestedped = PedManager.ped1;
        }
    }
}
