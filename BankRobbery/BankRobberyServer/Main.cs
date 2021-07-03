using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;

namespace BankRobberyServer
{
    public class Main : BaseScript
    {
        public Main()
        {
            
        }

        public static void FleecaRobbery(int src)
        {
            Player plyr = new PlayerList()[src];
            TriggerClientEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                multiline = true,
                args = new[] { "~y~NEWS", "Harmony Fleeca has just been robbed" }
            });
            Console.Write($"{plyr.Name} has just robbed the Harmony Fleeca");
            API.CancelEvent();
        }
    }
}
