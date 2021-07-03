using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace server
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers["PrisonWatch:GoOnDuty"] += new Action<Player>(GoOnDuty);
        }

        private void GoOnDuty([FromSource] Player player)
        {
            //Get Player Name
            string PlayerName = player.Name;

            //Trigger Client Event
            TriggerClientEvent("PrisonWatch:PlayerOnDuty", PlayerName);
        }
    }
}
