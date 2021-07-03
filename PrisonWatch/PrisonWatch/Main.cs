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
    public class Main : BaseScript
    {
        private static string Name = "Prison Watch";
        private static string Version = "1.0";
        private static string Author = "Abel Gaming";
        public Main()
        {
            Debug.WriteLine($"~b~{Name} ~w~version ~y~{Version}~w~ by ~b~{Author}~w~ has been loaded");
            Screen.ShowNotification($"~b~{Name} ~w~version ~y~{Version}~w~ by ~b~{Author}~w~ has been loaded");
        }
    }
}
