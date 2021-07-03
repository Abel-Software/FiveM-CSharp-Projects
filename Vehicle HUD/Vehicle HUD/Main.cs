using System.Threading.Tasks;
using CitizenFX.Core;

namespace Vehicle_HUD
{
    public class Main : BaseScript
    {
        public Main()
        {
            Debug.WriteLine("Abel Gaming Vehicle HUD Loaded");
            Tick += OnTick;
        }

        private static async Task OnTick()
        {
            
        }
    }
}
