using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fire_Hydrant_Script
{
    public class Main : BaseScript
    {
        //BOOLS
        public static bool IsHoseConnected = false;

        //VECTOR 3
        public static Vector3 HoseConnection;

        //BLIPS
        public static Blip CurrentHydrantBlip;

        //INI
        private static string resourcename = API.GetCurrentResourceName();
        public static string HoseLength = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, @"config/HoseLength.ini");

        //CONVERT
        private static float HoseLengthFloat = float.Parse(HoseLength);

        public Main()
        {
            //Check Hydrants by Model
            Tick += OnTick;

            //Check Hose Status
            Tick += HoseCheck;

            //Check All Hydrant Four Coords
            Tick += HydrantFour;
        }

        private static async Task HydrantTwo()
        {
            //Define Player
            Ped player = Game.Player.Character;

            //Define Hydrant Coords
            Vector3 hydrant1 = new Vector3(1663.71f, 4832.64f, 41.12888f);
            Vector3 hydrant2 = new Vector3(1681.438f, 4815.481f, 41.01201f);
            Vector3 hydrant3 = new Vector3(1673.427f, 4879.911f, 41.01236f);

            //Get Distance Between
            float hydrant1distance = World.GetDistance(player.Position, hydrant1);

            //Get Current Weapon
            Weapon CurrentWeapon = Game.Player.Character.Weapons.Current;

            //HYDRANT 1
            if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant1distance <= 2.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Functions.Utility.AttachHose();
                }
            }
            if (IsHoseConnected & hydrant1distance <= 2.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    CurrentHydrantBlip.Delete();
                    Functions.Utility.DetatchHose();
                }
            }
        }

        private static async Task HydrantFour()
        {
            if (API.IsPedOnFoot(API.GetPlayerPed(-1)))
            {
                //Define Player
                Ped player = Game.Player.Character;

                //Define Hydrant Coordinats
                Vector3 bchydrant1 = new Vector3(-2027.106f, 3379.417f, 30.1124f);
                Vector3 bchydrant2 = new Vector3(-737.8989f, -791.5118f, 23.15706f);
                Vector3 bchydrant3 = new Vector3(-762.5945f, -1436.209f, 4.027195f);
                Vector3 bchydrant4 = new Vector3(-762.8085f, -1436.462f, 4.027195f);
                Vector3 bchydrant5 = new Vector3(-707.3607f, -1463.001f, 3.977661f);
                Vector3 bchydrant6 = new Vector3(-707.5747f, -1463.255f, 3.977661f);
                Vector3 bchydrant7 = new Vector3(-1063.486f, -1349.25f, 3.998505f);
                Vector3 bchydrant8 = new Vector3(-979.7393f, -1255.853f, 4.403336f);
                Vector3 bchydrant9 = new Vector3(-926.1752f, -1225.079f, 3.959259f);
                Vector3 bchydrant10 = new Vector3(-877.9532f, -1197.295f, 3.628395f);
                Vector3 bchydrant11 = new Vector3(-390.5803f, 1162.594f, 324.7368f);
                Vector3 bchydrant12 = new Vector3(377.2031f, 445.4281f, 143.8135f);
                Vector3 bchydrant13 = new Vector3(656.2688f, 230.5761f, 95.71864f);
                Vector3 bchydrant14 = new Vector3(-1413.762f, 484.9673f, 108.9163f);
                Vector3 bchydrant15 = new Vector3(-1258.008f, 470.0952f, 92.97253f);
                Vector3 bchydrant16 = new Vector3(-1249.756f, 645.7176f, 139.9849f);
                Vector3 bchydrant17 = new Vector3(-863.7689f, 489.3852f, 87.48478f);
                Vector3 bchydrant18 = new Vector3(1693.126f, 3581.101f, 34.37645f);
                Vector3 bchydrant19 = new Vector3(1684.752f, 3598.949f, 34.10727f);
                Vector3 bchydrant20 = new Vector3(1674.24f, 3591.41f, 34.30913f);
                Vector3 bchydrant21 = new Vector3(1893.267f, 3716.199f, 31.85033f);
                Vector3 bchydrant22 = new Vector3(1985.468f, 3062.525f, 45.95533f);
                Vector3 bchydrant23 = new Vector3(610.1679f, -2786.654f, 5.080688f);
                Vector3 bchydrant24 = new Vector3(628.2621f, -2813.019f, 5.078033f);
                Vector3 bchydrant25 = new Vector3(610.666f, -2873.838f, 4.939682f);
                Vector3 bchydrant26 = new Vector3(603.0964f, -2798.859f, 5.080688f);
                Vector3 bchydrant27 = new Vector3(634.7819f, -2800.546f, 5.080688f);
                Vector3 bchydrant28 = new Vector3(628.6299f, -3017.708f, 4.995438f);

                //Get Distance Between
                float hydrant1distance = World.GetDistance(player.Position, bchydrant1);
                float hydrant2distance = World.GetDistance(player.Position, bchydrant2);
                float hydrant3distance = World.GetDistance(player.Position, bchydrant3);
                float hydrant4distance = World.GetDistance(player.Position, bchydrant4);
                float hydrant5distance = World.GetDistance(player.Position, bchydrant5);
                float hydrant6distance = World.GetDistance(player.Position, bchydrant6);
                float hydrant7distance = World.GetDistance(player.Position, bchydrant7);
                float hydrant8distance = World.GetDistance(player.Position, bchydrant8);
                float hydrant9distance = World.GetDistance(player.Position, bchydrant9);
                float hydrant10distance = World.GetDistance(player.Position, bchydrant10);
                float hydrant11distance = World.GetDistance(player.Position, bchydrant11);
                float hydrant12distance = World.GetDistance(player.Position, bchydrant12);
                float hydrant13distance = World.GetDistance(player.Position, bchydrant13);
                float hydrant14distance = World.GetDistance(player.Position, bchydrant14);
                float hydrant15distance = World.GetDistance(player.Position, bchydrant15);
                float hydrant16distance = World.GetDistance(player.Position, bchydrant16);
                float hydrant17distance = World.GetDistance(player.Position, bchydrant17);
                float hydrant18distance = World.GetDistance(player.Position, bchydrant18);
                float hydrant19distance = World.GetDistance(player.Position, bchydrant19);
                float hydrant20distance = World.GetDistance(player.Position, bchydrant20);
                float hydrant21distance = World.GetDistance(player.Position, bchydrant21);
                float hydrant22distance = World.GetDistance(player.Position, bchydrant22);
                float hydrant23distance = World.GetDistance(player.Position, bchydrant23);
                float hydrant24distance = World.GetDistance(player.Position, bchydrant24);
                float hydrant25distance = World.GetDistance(player.Position, bchydrant25);
                float hydrant26distance = World.GetDistance(player.Position, bchydrant26);
                float hydrant27distance = World.GetDistance(player.Position, bchydrant27);
                float hydrant28distance = World.GetDistance(player.Position, bchydrant28);

                //Get Current Weapon
                Weapon CurrentWeapon = Game.Player.Character.Weapons.Current;

                //HYDRANT 1
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant1distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant1distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 2
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant2distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant2distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 3
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant3distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant3distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 4
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant4distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant4distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 5
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant5distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant5distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 6
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant6distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant6distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 7
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant7distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant7distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 8
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant8distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant8distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 9
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant9distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant9distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 10
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant10distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant10distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 11
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant11distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant11distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 12
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant12distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant12distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 13
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant13distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant13distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 14
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant14distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant14distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 15
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant15distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant15distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 16
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant16distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant16distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 17
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant17distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant17distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 18
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant18distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant18distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 19
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant19distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant19distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 20
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant20distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant20distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 21
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant21distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant21distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 22
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant22distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant22distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 23
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant23distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant23distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 24
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant24distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant24distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 25
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant25distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant25distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 26
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant26distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant26distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 27
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant27distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant27distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 28
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant28distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant28distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }
            }
        }

        private static async Task HoseCheck()
        {
            if (IsHoseConnected)
            {
                //Draw Hose Connection Box
                API.DrawRect(0.925f, 0.5f, 0.175f, 0.125f, 0, 0, 0, 150);

                //Draw Title Text
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Hydrant Connection");
                API.DrawText(0.86f, 0.435f);
                API.EndTextComponent();

                //Draw Status Text
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~o~Status: ~g~CONNECTED");
                API.DrawText(0.84f, 0.46f);
                API.EndTextComponent();

                //Get Distance
                float ConnectionDistance = World.GetDistance(Game.Player.Character.Position, HoseConnection);
                float ConnectionDistanceRounde = (float)Math.Round(ConnectionDistance);

                //Draw Length Text
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~o~Length: ~w~" + ConnectionDistanceRounde.ToString() + "/" + HoseLength + " FT");
                API.DrawText(0.84f, 0.485f); //0.025 SPACING
                API.EndTextComponent();

                //Check Distance
                if (ConnectionDistance >= HoseLengthFloat)
                {
                    CurrentHydrantBlip.Delete();
                    Functions.Utility.HoseMaxReach();
                }
            }

            if (IsHoseConnected & API.IsPedInAnyVehicle(API.GetPlayerPed(-1), false))
            {
                CurrentHydrantBlip.Delete();
                Functions.Utility.EnteredVehicle();
            }
        }

        private static async Task OnTick()
        {
            if (API.IsPedOnFoot(API.GetPlayerPed(-1)))
            {
                //Define Player
                Ped player = Game.Player.Character;

                //Define Hydrant
                var hydrant1name = "prop_fire_hydrant_1";
                var hydrant2name = "prop_fire_hydrant_2";
                var hydrant3name = "prop_fire_hydrant_3";
                var hydrant5name = "prop_fire_hydrant_5";

                //Get Closest Hydrant Int
                int hydrant1 = API.GetClosestObjectOfType(player.Position.X, player.Position.Y, player.Position.X, 5f, (uint)API.GetHashKey(hydrant1name), false, true, true);
                int hydrant2 = API.GetClosestObjectOfType(player.Position.X, player.Position.Y, player.Position.X, 5f, (uint)API.GetHashKey(hydrant2name), false, true, true);
                int hydrant3 = API.GetClosestObjectOfType(player.Position.X, player.Position.Y, player.Position.X, 5f, (uint)API.GetHashKey(hydrant3name), false, true, true);
                int hydrant5 = API.GetClosestObjectOfType(player.Position.X, player.Position.Y, player.Position.X, 5f, (uint)API.GetHashKey(hydrant5name), false, true, true);

                //Get Hydrant Coords
                Vector3 hydrant1coords = API.GetEntityCoords(hydrant1, false);
                Vector3 hydrant2coords = API.GetEntityCoords(hydrant2, false);
                Vector3 hydrant3coords = API.GetEntityCoords(hydrant3, false);
                Vector3 hydrant5coords = API.GetEntityCoords(hydrant5, false);

                //Get Distance Between
                float hydrant1distance = World.GetDistance(player.Position, hydrant1coords);
                float hydrant2distance = World.GetDistance(player.Position, hydrant2coords);
                float hydrant3distance = World.GetDistance(player.Position, hydrant3coords);
                float hydrant5distance = World.GetDistance(player.Position, hydrant5coords);

                //Get Current Weapon
                Weapon CurrentWeapon = Game.Player.Character.Weapons.Current;

                //HYDRANT 1
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant1distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant1distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 2
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant2distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant2distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 3
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant3distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant3distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }

                //HYDRANT 5
                if (!IsHoseConnected & CurrentWeapon == WeaponHash.FireExtinguisher & hydrant5distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to attach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        Functions.Utility.AttachHose();
                    }
                }
                if (IsHoseConnected & hydrant5distance <= 2.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to detach hose");
                    if (Game.IsControlJustPressed(0, Control.Pickup))
                    {
                        CurrentHydrantBlip.Delete();
                        Functions.Utility.DetatchHose();
                    }
                }
            }
        }
    }
}
