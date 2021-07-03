using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

using NativeUI;

namespace client
{
    public class Main : BaseScript
    {
        private static List<Vector3> CustomLocations = new List<Vector3>();
        public Main()
        {
            Debug.WriteLine("Los Santos Customs by Abel Gaming has been loaded"); //When the script starts, it will place the text in the debug log
            AddLocations(); //Adds coordinates for the Custom Shop locations
            Tick += DrawMarkers; //Runs the DrawMarkers tick method
            Tick += CheckMarkers; //Runs the CheckMarker tick method
        }

        private static void AddLocations()
        {
            CustomLocations.Add(new Vector3(-341.56f, -136.8f, 38.82f)); //LS Customs in Los Santos near Michael's house
            CustomLocations.Add(new Vector3(111.08f, 6626.49f, 31.32f)); //Paleto Bay PD
        }

        private static async Task DrawMarkers()
        {
            foreach(Vector3 LSCustoms in CustomLocations)
            {
                //Draw Marker
                API.DrawMarker(
                    1,           //Marker Type
                    LSCustoms.X, //X Position
                    LSCustoms.Y, //Y Position
                    LSCustoms.Z, //Z Position
                    0.0f,        //X Direction
                    0.0f,        //Y Direction
                    0.0f,        //Z Direction
                    0.0f,        //X Rotation
                    180.0f,      //Y Rotation
                    0.0f,        //Z Rotation
                    3.0f,        //X Scale
                    3.0f,        //Y Scale
                    3.0f,        //Z Scale
                    250,         //RED (RGB)
                    160,         //GREEN (RGB)
                    5,           //BLUE (RGB)
                    100,         //Alpha
                    false,       //Bob up and down
                    true,        //Face cammera
                    2,           //P19 (Always set to 2)
                    false,       //Rotate
                    null,        //Texture Dictionary
                    null,        //Texture Name
                    false);      //Draw on Ents
            }
        }

        private static async Task CheckMarkers()
        {
            foreach (Vector3 LSCustoms in CustomLocations)
            {
                //Gets the float distance between the character and the marker
                float MarkerDistance = World.GetDistance(Game.Player.Character.Position, LSCustoms);

                //Check Distance
                if (MarkerDistance <= 1.5f) //Checks to make sure the player is within range of the marker
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter ~y~Los Santos Customs"); //This displays the message to open the LS Customs menu
                    if (API.IsControlJustPressed(0, 38)) //Checking for the input to enter the customs menu
                    {
                        if (Game.Player.Character.IsInVehicle()) //Checks to make sure the player is in a vehicle
                        {
                            //Create Vehicle Mod List
                            Menu.CreateList(Game.Player.Character.CurrentVehicle);

                            //Open Menu Code
                            Menu.mainMenu.Visible = true;

                            //Disable Control
                            Game.Player.CanControlCharacter = false;

                            //Hide HUD
                            Screen.Hud.IsVisible = false;
                            Screen.Hud.IsRadarVisible = false;
                        }
                        else
                        {
                            Screen.ShowNotification("~r~[ERROR]~w~ You are not in a vehicle"); //Shows the player an error message if they are not in a vehicle
                        }
                    }

                    if (!Menu._menuPool.IsAnyMenuOpen())
                    {
                        //Enable Control
                        Game.Player.CanControlCharacter = true;

                        //Show HUD
                        Screen.Hud.IsVisible = true;
                        Screen.Hud.IsRadarVisible = true;
                    }
                }
                else
                {
                    if (Menu._menuPool.IsAnyMenuOpen())
                    {
                        Menu._menuPool.CloseAllMenus();
                    }
                }
            }
        }
    }
}
