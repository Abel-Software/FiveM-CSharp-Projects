using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client
{
    public class Main : BaseScript
    {
        //BOOLS
        private static bool IsPlayerLEO = false;
        private static bool IsPanicButtonActive = false;

        //BLIPS
        private static Blip PanicBlip;

        //STRINGS
        private static string PanicPlayer;
        private static string PanicStreet;
        
        public Main()
        {
            //Register Commands for Server Action
            API.RegisterCommand("+panicbutton", new Action<int, List<object>, string>((source, arguments, raw) =>
            {
                TriggerServerEvent("PanicButton:GetInformation");
            }), false);
            API.RegisterCommand("clearpb", new Action<int, List<object>, string>((source, arguments, raw) =>
            {
                TriggerServerEvent("PanicButton:ClearPanicButtonSend");
            }), false);

            //Create Event
            EventHandlers.Add("PanicButton:SendInformation", new Action<int, string, Vector3>(OnSendVariable));
            EventHandlers.Add("PanicButton:AlreadyActive", new Action(PBAlreadyActive));
            EventHandlers.Add("PanicButton:ClearPanicButtonResult", new Action<string>(ClearPB));

            //Create Basic Commands
            API.RegisterCommand("activeLeo", new Action(SetLEO), false);

            //Tick
            Tick += OnTick;
            Tick += DrawDetails;

            //Log Messages
            Debug.WriteLine("PanicButton has loaded");
        }

        private static void PBAlreadyActive()
        {
            Audio.PlaySoundFrontend("ERROR", "HUD_AMMO_SHOP_SOUNDSET");
            Screen.ShowNotification("~r~[ERROR]~w~ A panic button is already active");
        }

        private static void ClearPB(string ClearedBy)
        {
            //Delete Blip
            if (PanicBlip.Exists())
            {
                PanicBlip.Delete();
            }

            //Set bool
            IsPanicButtonActive = false;

            //Draw Notification
            Screen.ShowNotification($"~g~[SUCCESS]~w~ Panic Button was cleared by ~b~{ClearedBy}");

            //Log
            Debug.WriteLine($"Panic button cleared by {ClearedBy}");
        }

        private static void SetLEO()
        {
            if (!IsPlayerLEO)
            {
                IsPlayerLEO = true;
                Audio.PlaySoundFrontend("TOGGLE_ON", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                Screen.ShowNotification("~g~[SUCCESS]~w~ You are now on duty");

            }
            else
            {
                IsPlayerLEO = false;
                Audio.PlaySoundFrontend("TOGGLE_ON", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                Screen.ShowNotification("~g~[SUCCESS]~w~ You are now off duty");
            }
        }

        private static async void OnSendVariable(int someVariable, string someString, Vector3 someCoords)
        {
            //Define Things
            Vector3 pos = someCoords;
            string street = World.GetStreetName(pos);
            string player = someString;

            //Get things for the panic detail box
            PanicPlayer = player;
            PanicStreet = street;

            if (IsPlayerLEO)
            {
                //Sound Alarm
                Audio.PlaySoundFrontend("Start_Squelch", "CB_RADIO_SFX");
                await Delay(500);
                Audio.PlaySoundFrontend("Beep_Red", "DLC_HEIST_HACKING_SNAKE_SOUNDS");
                await Delay(300);
                Audio.PlaySoundFrontend("Beep_Red", "DLC_HEIST_HACKING_SNAKE_SOUNDS");
                await Delay(300);
                Audio.PlaySoundFrontend("Beep_Red", "DLC_HEIST_HACKING_SNAKE_SOUNDS");
                await Delay(500);
                Audio.PlaySoundFrontend("End_Squelch", "CB_RADIO_SFX");

                //Set Bool
                IsPanicButtonActive = true;

                //Draw Notifications
                Screen.ShowNotification($"~b~{player}~w~ has just pressed their panic button at ~y~{street}");
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_REPLAY_TIMELINE_PICKUP_CLIP~ to draw route to officer");

                //Draw Blip
                PanicBlip = World.CreateBlip(pos);
                PanicBlip.Sprite = BlipSprite.PoliceCarDot;
                PanicBlip.Name = $"{player}'s Panic Button";
            }
        }

        private static async Task OnTick()
        {
            if (IsPlayerLEO & Game.IsControlJustPressed(0, Control.SelectCharacterFranklin))
            {
                TriggerServerEvent("PanicButton:GetInformation");
            }
        }

        private static async Task DrawDetails()
        {
            if (IsPlayerLEO & IsPanicButtonActive)
            {
                //Draw Recentangle
                API.DrawRect(0.5f, 0.05f, 0.2f, 0.1f, 0, 0, 0, 150);

                //Draw Title Text
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(6);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~PANIC BUTTON DETAILS");
                API.DrawText(0.46f, 0.0f);
                API.EndTextComponent();

                //Draw Officer
                API.SetTextScale(0.5f, 0.5f);
                API.SetTextFont(6);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString($"Officer: ~b~{PanicPlayer}");
                API.DrawText(0.405f, 0.03f);
                API.EndTextComponent();

                //Draw Street
                API.SetTextScale(0.5f, 0.5f);
                API.SetTextFont(6);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString($"Location: ~b~{PanicStreet}");
                API.DrawText(0.405f, 0.06f);
                API.EndTextComponent();

                //Draw Route on X (Keyboard)
                if (API.IsControlJustPressed(0, 323))
                {
                    PanicBlip.ShowRoute = true;
                }

                //Check Distance
                float DistanceAway = World.GetDistance(Game.Player.Character.Position, PanicBlip.Position);
                if (DistanceAway <= 15f)
                {
                    PanicBlip.ShowRoute = false;
                }
            }
        }
    }
}
