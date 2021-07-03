using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;
using System.Threading.Tasks;

namespace BankRobbery
{
    public class Main : BaseScript
    {
        //Bools
        public static bool HarmonyRobbery = false;
        public static bool PaletoBay = false;
        public static bool GOH = false;
        public static bool Vinewood = false;

        //INT
        public static int SessionIncome;
        public Main()
        {
            Tick += OnTick;
            
        }

        private static async Task OnTick()
        {
            //Draw Blips
            Functions.Blips.DrawBlips();

            //Draw Markers
            Functions.Markers.DrawMarkers();

            //Check Distance
            Functions.Distance.CheckDistance();

            //Register Commands
            Functions.Commands.RegisterCommands();
        }
    }
}
