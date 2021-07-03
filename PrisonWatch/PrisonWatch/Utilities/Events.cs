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
    public class Events : BaseScript
    {
        public Events()
        {
            //Duty Events
            EventHandlers["PrisonWatch:PlayerOnDuty"] += new Action<string>(PlayerOnDuty);
            EventHandlers["PrisonWatch:PlayerOffDuty"] += new Action<string>(PlayerOffDuty);

            //Check Ins
            EventHandlers["PrisonWatch:OfficerCheckIn"] += new Action<string, string>(OfficerCheckIn);
        }

        private static void PlayerOnDuty(string PlayerName)
        {
            Screen.ShowNotification($"~b~{PlayerName} ~w~is now on duty as a prison watch guard");
        }

        private static void PlayerOffDuty(string PlayerName)
        {

        }

        private static void OfficerCheckIn(string PlayerName, string Position)
        {

        }
    }
}
