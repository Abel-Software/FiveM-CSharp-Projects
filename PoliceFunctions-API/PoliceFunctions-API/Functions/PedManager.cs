using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Threading.Tasks;
using CitizenFX.Core.UI;

namespace PoliceFunctions_API.Functions
{
    public class PedManager
    {
        private static int firstnameintMale;
        private static int lastnameintMale;
        private static int firstnameintFemale;
        private static int lastnameintFemale;
        private static int licenssestatus;
        public static string firstnameMale;
        public static string lastnameMale;
        public static string firstnameFemale;
        public static string lastnameFemale;
        public static string license;

        public static Ped ped1;
        public static async Task GetID()
        {
            //NEW CODE
            if (ped1.Gender == Gender.Male)
            {
                //Generate First Name
                var firstnamerandomMale = new Random();
                var possiblefirstnamesMale = new List<string> { "Sam", "Bryan", "Wayne", "Joey", "Lenny", "Owen", "Terry", "Scott", "Zach", "John", "Wesley", "Jackson", "Brayden", "Lamar", "Justin" };

                var lastnamerandomMale = new Random();
                var possiblelastnamesMale = new List<string> { "Graham", "Walker", "Reid", "Cole", "Scott", "Wagner", "Mullins", "Stanley", "Gomez", "Watson", "King", "Todd", "Holt", "Haynes", "Philips", "Edwards", "Weaver", "Shelton", "Ford", "Rodriguez" };

                //Choose first and last names
                firstnameintMale = firstnamerandomMale.Next(possiblefirstnamesMale.Count);
                lastnameintMale = lastnamerandomMale.Next(possiblelastnamesMale.Count);

                //Create first and last
                firstnameMale = possiblefirstnamesMale[firstnameintMale];
                lastnameMale = possiblelastnamesMale[lastnameintMale];

                //Show Identification
                int x = API.RegisterPedheadshot(ped1.Handle);
                while (!API.IsPedheadshotReady(x) || !API.IsPedheadshotValid(x))
                    await BaseScript.Delay(0);
                API.SetNotificationTextEntry("STRING");
                API.SetNotificationColorNext(4);
                API.AddTextComponentString("~y~Name: ~s~" + possiblefirstnamesMale[firstnameintMale] + " " + possiblelastnamesMale[lastnameintMale]);
                API.SetTextScale(0.5f, 0.5f);
                API.SetNotificationMessage(API.GetPedheadshotTxdString(x), API.GetPedheadshotTxdString(x), false, 0, "State of San Andreas", "Identification Card");
                API.DrawNotification(true, false);
            }

            if (ped1.Gender == Gender.Female)
            {
                //Generate First Name
                var firstnamerandomFemale = new Random();
                var possiblefirstnamesFemale = new List<string> { "Darcy", "Molly", "Kye", "Tina", "Christina", "Emmie", "Lana", "Heather", "Terry" };

                var lastnamerandomFemale = new Random();
                var possiblelastnamesFemale = new List<string> { "Graham", "Walker", "Reid", "Cole", "Scott", "Wagner", "Mullins", "Stanley", "Gomez", "Watson", "King", "Todd", "Holt", "Haynes", "Philips", "Edwards", "Weaver", "Shelton", "Ford", "Rodriguez" };

                //Choose first and last names
                firstnameintFemale = firstnamerandomFemale.Next(possiblefirstnamesFemale.Count);
                lastnameintFemale = lastnamerandomFemale.Next(possiblelastnamesFemale.Count);

                //Create first and last
                firstnameFemale = possiblefirstnamesFemale[firstnameintFemale];
                lastnameFemale = possiblelastnamesFemale[lastnameintFemale];

                //Show Identification
                int x = API.RegisterPedheadshot(ped1.Handle);
                while (!API.IsPedheadshotReady(x) || !API.IsPedheadshotValid(x))
                    await BaseScript.Delay(0);
                API.SetNotificationTextEntry("STRING");
                API.SetNotificationColorNext(4);
                API.AddTextComponentString("~y~Name: ~s~" + possiblefirstnamesFemale[firstnameintFemale] + " " + possiblelastnamesFemale[lastnameintFemale]);
                API.SetTextScale(0.5f, 0.5f);
                API.SetNotificationMessage(API.GetPedheadshotTxdString(x), API.GetPedheadshotTxdString(x), false, 0, "State of San Andreas", "Identification Card");
                API.DrawNotification(true, false);
            }
        }

        public static async Task CheckID()
        {
            //Generate Random License Status
            var licenserandom = new Random();
            var licensestatusoptions = new List<string> { "~g~Valid", "~y~Expired", "~r~Suspended", "~r~Driver is wanted" };

            //Choose plate status
            licenssestatus = licenserandom.Next(licensestatusoptions.Count);
            license = licensestatusoptions[licenssestatus];
            if (ped1.Gender == Gender.Male)
            {
                //Display Result with Ped Headshot
                int x = API.RegisterPedheadshot(ped1.Handle);
                while (!API.IsPedheadshotReady(x) || !API.IsPedheadshotValid(x))
                    await BaseScript.Delay(0);
                API.SetNotificationTextEntry("STRING");
                API.SetNotificationColorNext(4);
                API.AddTextComponentString("Name~b~ " + firstnameMale + " " + lastnameMale + "~n~" + "~w~License Status: " + license);
                API.SetTextScale(0.5f, 0.5f);
                API.SetNotificationMessage(API.GetPedheadshotTxdString(x), API.GetPedheadshotTxdString(x), false, 0, "State of San Andreas", "Drivers license");
                API.DrawNotification(true, false);
            }

            if (ped1.Gender == Gender.Female)
            {
                //Display Result with Ped Headshot
                int x = API.RegisterPedheadshot(ped1.Handle);
                while (!API.IsPedheadshotReady(x) || !API.IsPedheadshotValid(x))
                    await BaseScript.Delay(0);
                API.SetNotificationTextEntry("STRING");
                API.SetNotificationColorNext(4);
                API.AddTextComponentString("Name~b~ " + firstnameFemale + " " + lastnameFemale + "~n~" + "~w~License Status: " + license);
                API.SetTextScale(0.5f, 0.5f);
                API.SetNotificationMessage(API.GetPedheadshotTxdString(x), API.GetPedheadshotTxdString(x), false, 0, "State of San Andreas", "Drivers license");
                API.DrawNotification(true, false);
            }
        }

        public static Ped StopPed()
        {
            Ped[] allPeds = World.GetAllPeds();
            if (allPeds.Length == 0)
                return (Ped)null;
            float num = float.MaxValue;
            ped1 = (Ped)null;
            foreach (Ped ped2 in allPeds)
            {
                if (!Entity.Equals((Entity)Game.PlayerPed, (Entity)ped2))
                {
                    float distance = World.GetDistance(((Entity)ped2).Position, ((Entity)Game.PlayerPed).Position);
                    if ((double)distance < (double)num)
                    {
                        ped1 = ped2;
                        num = distance;
                    }
                }
            }

            float checkdistance = World.GetDistance(Game.Player.Character.Position, ped1.Position);

            if (checkdistance <= 10.0f)
            {
                //Block Events
                ped1.BlockPermanentEvents = true;

                //Do Tasks
                ped1.Task.StandStill(-1);
                API.TaskStandStill(ped1.GetHashCode(), -1);
                ped1.Task.LookAt(Game.Player.Character, 1);
                API.TaskLookAtEntity(ped1.Handle, Game.Player.Character.Handle, -1, 2048, 3);

                //Show notification
                Screen.ShowNotification("Ped has been stopped");

                //Make ped persistent
                ped1.IsPersistent = true;
            }

            return ped1;
        }

        public static void ReleasePed()
        {
            //Clear Tasks
            ped1.Task.ClearAll();
            API.ClearPedTasks(ped1.Handle);

            //Make no longer persistent
            ped1.IsPersistent = false;
        }
    }
}
