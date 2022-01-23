using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace PoliceFunctions_API.Functions
{
    public class Tools
    {
        private static int breathresultint;
        private static string breathresult;
        public static async Task BreathalyzePed()
        {
            //Create random
            var breathalyzerrandom = new Random();

            //Create possible results
            var possibleresults = new List<string>
            {
                "~g~0.00",
                "~g~0.01",
                "~g~0.02",
                "~g~0.03",
                "~g~0.04",
                "~y~0.05",
                "~y~0.06",
                "~y~0.07",
                "~r~0.08",
                "~r~0.09",
                "~r~0.10"
            };

            //Count the options
            breathresultint = breathalyzerrandom.Next(possibleresults.Count);

            //Choose the result
            breathresult = possibleresults[breathresultint];

            //Show result
            int x = API.RegisterPedheadshot_3(PedManager.ped1.Handle);
            while (!API.IsPedheadshotReady(x) || !API.IsPedheadshotValid(x))
                await BaseScript.Delay(0);
            API.SetNotificationTextEntry("STRING");
            API.SetNotificationColorNext(4);
            API.AddTextComponentString("BAC: " + breathresult);
            API.SetTextScale(0.5f, 0.5f);
            API.SetNotificationMessage(API.GetPedheadshotTxdString(x), API.GetPedheadshotTxdString(x), false, 0, "Breathalyzer", "~o~Breathlyzer Result");
            API.DrawNotification(true, false);
        }
    }
}
