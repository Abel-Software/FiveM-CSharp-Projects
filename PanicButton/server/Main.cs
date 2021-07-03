using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace server
{
    public class Main : BaseScript
    {
        //Stuff to send
        private static int myVariable;
        private static string myString;
        private static Vector3 myCoords;

        //Local Stuff
        private static bool IsPanicButtonActive = false;
        
        public Main()
        {
            EventHandlers.Add("PanicButton:GetInformation", new Action<Player>(OnGetVariable));
            EventHandlers.Add("PanicButton:ClearPanicButtonSend", new Action<Player>(ClearPanicBlip));
        }

        private void ClearPanicBlip([FromSource] Player p)
        {
            string ClearedBy = p.Name;
            IsPanicButtonActive = false;
            TriggerClientEvent("PanicButton:ClearPanicButtonResult", ClearedBy);
        }

        private void OnGetVariable([FromSource] Player p)
        {
            //Get Stuff
            myVariable = p.GetHashCode();
            myString = p.Name;
            myCoords = p.Character.Position;

            if (!IsPanicButtonActive)
            {
                //Send Alert to Players
                TriggerClientEvent("PanicButton:SendInformation", myVariable, myString, myCoords);

                //Set to true
                IsPanicButtonActive = true;
            }
            else
            {
                TriggerClientEvent("PanicButton:AlreadyActive");
            }        
        }
    }
}
