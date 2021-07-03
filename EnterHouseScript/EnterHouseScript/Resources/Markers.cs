using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System.Threading.Tasks;

namespace EnterHouseScript.Resources
{
    public class Markers
    {
        public static void DrawMarkers()
        {
            //Outside Markers
            API.DrawMarker(1, Locations.marker1.X, Locations.marker1.Y, Locations.marker1.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.marker2.X, Locations.marker2.Y, Locations.marker2.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.marker3.X, Locations.marker3.Y, Locations.marker3.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.marker4.X, Locations.marker4.Y, Locations.marker4.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.marker5.X, Locations.marker5.Y, Locations.marker5.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.marker6.X, Locations.marker6.Y, Locations.marker6.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.marker7.X, Locations.marker7.Y, Locations.marker7.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.marker8.X, Locations.marker8.Y, Locations.marker8.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.marker9.X, Locations.marker9.Y, Locations.marker9.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);

            //Residences
            API.DrawMarker(1, Locations.MadrazaResidence.X, Locations.MadrazaResidence.Y, Locations.MadrazaResidence.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            
            //Apartments
            API.DrawMarker(1, Locations.ApartmentSpawn.X, Locations.ApartmentSpawn.Y, Locations.ApartmentSpawn.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.ApartmentSpawn2.X, Locations.ApartmentSpawn2.Y, Locations.ApartmentSpawn2.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.ApartmentSpawn3.X, Locations.ApartmentSpawn3.Y, Locations.ApartmentSpawn3.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.ApartmentSpawn4.X, Locations.ApartmentSpawn4.Y, Locations.ApartmentSpawn4.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.ApartmentSpawn5.X, Locations.ApartmentSpawn5.Y, Locations.ApartmentSpawn5.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.ApartmentSpawn6.X, Locations.ApartmentSpawn6.Y, Locations.ApartmentSpawn6.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.ApartmentSpawn7.X, Locations.ApartmentSpawn7.Y, Locations.ApartmentSpawn7.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.ApartmentSpawn8.X, Locations.ApartmentSpawn8.Y, Locations.ApartmentSpawn8.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.LowEndApartment.X, Locations.LowEndApartment.Y, Locations.LowEndApartment.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.MediumEndApartment.X, Locations.MediumEndApartment.Y, Locations.MediumEndApartment.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);

            //Random
            API.DrawMarker(1, Locations.RandomOfficeSpawn.X, Locations.RandomOfficeSpawn.Y, Locations.RandomOfficeSpawn.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, Locations.Bunker.X, Locations.Bunker.Y, Locations.Bunker.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            API.DrawMarker(1, -797.52f, 328.36f, 190.72f, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);

            //CEO Offices
            API.DrawMarker(1, Locations.CEOSpawn1.X, Locations.CEOSpawn1.Y, Locations.CEOSpawn1.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
        }

        public static void CheckDistance()
        {
            float marker9a = World.GetDistance(Game.Player.Character.Position, Locations.marker9);
            if (marker9a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.MadrazaResidence;

                    //Make Player Invisible to everyone else
                    API.NetworkSetEntityInvisibleToNetwork(Game.Player.Character.Handle, true);
                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker9b = World.GetDistance(Game.Player.Character.Position, Locations.MadrazaResidence);
            if (marker9b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker9;

                    //Make Player Visible to everyone else
                    API.NetworkSetEntityInvisibleToNetwork(Game.Player.Character.Handle, false);
                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker9c = World.GetDistance(Game.Player.Character.Position, new Vector3(-797.52f, 328.36f, 190.72f));
            if (marker9c <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter bunker");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.Bunker;

                    //Make Player Visible to everyone else
                    API.NetworkSetEntityInvisibleToNetwork(Game.Player.Character.Handle, false);
                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker9d = World.GetDistance(Game.Player.Character.Position, Locations.Bunker);
            if (marker9d <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave bunker");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = new Vector3(-797.52f, 328.36f, 190.72f);

                    //Make Player Visible to everyone else
                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker8a = World.GetDistance(Game.Player.Character.Position, Locations.marker8);
            if (marker8a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.ApartmentSpawn3;

                    //Invisible
                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker8b = World.GetDistance(Game.Player.Character.Position, Locations.ApartmentSpawn3);
            if (marker8b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker8;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker7a = World.GetDistance(Game.Player.Character.Position, Locations.marker7);
            if (marker7a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.LowEndApartment;

                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker7b = World.GetDistance(Game.Player.Character.Position, Locations.LowEndApartment);
            if (marker7b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker7;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker6a = World.GetDistance(Game.Player.Character.Position, Locations.marker6);
            if (marker6a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.MediumEndApartment;

                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker6b = World.GetDistance(Game.Player.Character.Position, Locations.MediumEndApartment);
            if (marker6b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker6;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker5a = World.GetDistance(Game.Player.Character.Position, Locations.marker5);
            if (marker5a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.ApartmentSpawn7;

                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker5b = World.GetDistance(Game.Player.Character.Position, Locations.ApartmentSpawn7);
            if (marker5b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker5;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker4a = World.GetDistance(Game.Player.Character.Position, Locations.marker4);
            if (marker4a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.ApartmentSpawn;

                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker4b = World.GetDistance(Game.Player.Character.Position, Locations.ApartmentSpawn);
            if (marker4b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker4;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker3a = World.GetDistance(Game.Player.Character.Position, Locations.marker3);
            if (marker3a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.ApartmentSpawn5;

                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker3b = World.GetDistance(Game.Player.Character.Position, Locations.ApartmentSpawn5);
            if (marker3b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker3;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker2a = World.GetDistance(Game.Player.Character.Position, Locations.marker2);
            if (marker2a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.ApartmentSpawn6;

                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));
                    API.SetPlayerInvisibleLocally(API.GetPlayerPed(-1), true);

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker2b = World.GetDistance(Game.Player.Character.Position, Locations.ApartmentSpawn6);
            if (marker2b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker2;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));
                    API.SetPlayerInvisibleLocally(API.GetPlayerPed(-1), false);

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker1a = World.GetDistance(Game.Player.Character.Position, Locations.marker1);
            if (marker1a <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.ApartmentSpawn8;

                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker1b = World.GetDistance(Game.Player.Character.Position, Locations.ApartmentSpawn8);
            if (marker1b <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.marker1;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker1c = World.GetDistance(Game.Player.Character.Position, new Vector3(336.37f, 435.41f, 141.77f));
            if (marker1c <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter office");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = Locations.CEOSpawn1;

                    API.SetEntityLocallyVisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }

            float marker1d = World.GetDistance(Game.Player.Character.Position, Locations.CEOSpawn1);
            if (marker1d <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to leave office");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    //Disable Player Control
                    Game.Player.CanControlCharacter = false;

                    //Set Position
                    Game.Player.Character.Position = new Vector3(336.37f, 435.41f, 141.77f);

                    API.SetEntityLocallyInvisible(API.GetPlayerPed(-1));

                    //Enable Player Control
                    Game.Player.CanControlCharacter = true;
                }
            }
        }
    }
}
