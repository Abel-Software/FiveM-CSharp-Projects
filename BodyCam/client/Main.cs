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
        private static string resourcename = API.GetCurrentResourceName();
        private static bool BodyCamEnabled = true;
        private static bool BodyCamRecording = false;
        private static string UseEditor = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/UseRockstarEditor.ini");
        private static string BodyCamStatus = "~g~Standby";

        public Main()
        {
            Tick += OnTick;
        }

        private static async Task OnTick()
        {
            if (BodyCamEnabled)
            {
                //Get Date
                string date = DateTime.Now.ToShortDateString();

                //Get Time
                string time = "T" + DateTime.Now.ToLongTimeString();

                //Create Other Strings
                string BottomLine = "AXON FLEX 2 x83023182";

                //Draw Top Line
                API.SetTextScale(0.6f, 0.6f);
                API.SetTextFont(6);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString($"{date} {time}Z");
                API.DrawText(0.875f, 0.01f); //0.035 DIFFERENCE WITH SET FONT AND SCALE
                API.EndTextComponent();

                //Draw Bottom Line
                API.SetTextScale(0.6f, 0.6f);
                API.SetTextFont(6);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString($"{BottomLine}");
                API.DrawText(0.873f, 0.045f); 
                API.EndTextComponent();

                //Draw Bottom Line
                API.SetTextScale(0.6f, 0.6f);
                API.SetTextFont(6);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString($"{BodyCamStatus}");
                API.DrawText(0.873f, 0.08f);
                API.EndTextComponent();
            }

            if (API.IsControlJustPressed(0, 316))
            {
                if (!BodyCamEnabled)
                {
                    BodyCamEnabled = true;
                    Screen.ShowNotification("~g~Body Cam turned on");
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_REPLAY_CAMERADOWN~ to begin recording");
                }
                else
                {
                    BodyCamEnabled = false;
                    Screen.ShowNotification("~r~Body Cam turned off");
                }
            }

            if (API.IsControlJustPressed(0, 317))
            {
                if (!BodyCamRecording)
                {
                    BodyCamRecording = true;
                    BodyCamStatus = "~r~Recording";
                    Screen.ShowNotification("Body Cam now recording");
                    if (UseEditor == "true")
                    {
                        API.StartRecording(1);
                    }
                }
                else
                {
                    BodyCamRecording = false;
                    BodyCamStatus = "~g~Standby";
                    Screen.ShowNotification("Body Cam recording ended");
                    if (UseEditor == "true")
                    {
                        API.StopRecordingAndSaveClip();
                    }
                }
            }
        }
    }
}
