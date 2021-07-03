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
        public static MenuPool _menuPool;
        public static UIMenu mainMenu;

        private void VehicleUpgrades(UIMenu menu)
        {
            var vehicleupgradesub = _menuPool.AddSubMenu(menu, "Vehicle Modifications");
            for (int i = 0; i < 1; i++) ;

            vehicleupgradesub.MouseEdgeEnabled = false;
            vehicleupgradesub.ControlDisablingEnabled = false;

            var FullUpgrade = new UIMenuItem("Law Enforcement Package");
            vehicleupgradesub.AddItem(FullUpgrade);
            vehicleupgradesub.OnItemSelect += (sender, item, index) =>
            {
                if (item == FullUpgrade)
                {
                    if (Game.Player.Character.IsInVehicle())
                    {
                        //Get Current Vehicle
                        Vehicle playercar = Game.Player.Character.CurrentVehicle;
                        int playervehicle = API.GetVehiclePedIsIn(API.GetPlayerPed(-1), true);

                        //Install Mod Kit
                        API.SetVehicleModKit(playervehicle, 0);

                        //Get Max Mods
                        int MaxEngine = API.GetNumVehicleMods(playervehicle, 12);
                        int MaxBrake = API.GetNumVehicleMods(playervehicle, 13);
                        int MaxTransmission = API.GetNumVehicleMods(playervehicle, 14);
                        int MaxArmor = API.GetNumVehicleMods(playervehicle, 17);

                        //Set Max Mods
                        API.SetVehicleMod(playervehicle, 11, 3, false);
                        API.SetVehicleMod(playervehicle, 12, 2, false);
                        API.SetVehicleMod(playervehicle, 13, 2, false);
                        API.SetVehicleMod(playervehicle, 16, 4, false);

                        //Set Max Speed
                        API.SetVehicleMaxSpeed(playervehicle, 500f);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowSimpleShard("Package Installed", "Law Enforcement Package has been installed to your vehicle");
                    }
                    else
                    {
                        Screen.ShowNotification("~r~[ERROR]~w~ You are not in a vehicle");
                    }
                }
            };

            var XenonLights = new UIMenuCheckboxItem("Xenon Lights", false);
            vehicleupgradesub.AddItem(XenonLights);
            vehicleupgradesub.OnCheckboxChange += (sender, item, index) =>
            {
                if (item == XenonLights)
                {
                    if (XenonLights.Checked)
                    {
                        //Get Current Vehicle
                        int playervehicle = API.GetVehiclePedIsIn(API.GetPlayerPed(-1), true);

                        //Set Xenon Lights On
                        API.ToggleVehicleMod(playervehicle, 22, true);
                    }
                    else
                    {
                        //Get Current Vehicle
                        int playervehicle = API.GetVehiclePedIsIn(API.GetPlayerPed(-1), true);

                        //Set Xenon Lights Off
                        API.ToggleVehicleMod(playervehicle, 22, false);
                    }
                }
            };

            //Muscle Rims
            var musclerimlist = new List<dynamic>
            {
                "0", "1", "2", "3", "4", "5"
            };

            var MuscleRims = new UIMenuListItem("Rim Options 1:", musclerimlist, 0);
            vehicleupgradesub.AddItem(MuscleRims);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == MuscleRims)
                {
                    //Get Current Vehicle
                    int playervehicle = API.GetVehiclePedIsIn(API.GetPlayerPed(-1), true);

                    //Get Rim Number
                    int RimNumber = int.Parse(MuscleRims.CurrentItem());

                    //Install Mod Kit
                    API.SetVehicleModKit(playervehicle, 0);

                    //Set Rim Type
                    API.SetVehicleWheelType(playervehicle, 1);

                    //Set Vehicle Mod
                    API.SetVehicleMod(playervehicle, 23, RimNumber, false);
                }
            };

            //Sport Rims
            var sportrimlist = new List<dynamic>
            {
                "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67"
            };

            var SportRims = new UIMenuListItem("Rim Options 2:", sportrimlist, 0);
            vehicleupgradesub.AddItem(SportRims);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == SportRims)
                {
                    //Get Current Vehicle
                    int playervehicle = API.GetVehiclePedIsIn(API.GetPlayerPed(-1), true);

                    //Get Rim Number
                    int RimNumber = int.Parse(SportRims.CurrentItem());

                    //Install Mod Kit
                    API.SetVehicleModKit(playervehicle, 0);

                    //Set Rim Type
                    API.SetVehicleWheelType(playervehicle, 0);

                    //Set Vehicle Mod
                    API.SetVehicleMod(playervehicle, 23, RimNumber, false);
                }
            };
        }

        public Main()
        {
            _menuPool = new MenuPool();
            mainMenu = new UIMenu("NJRP", "~p~Mod by ~b~Abel Gaming");
            _menuPool.Add(mainMenu);

            VehicleUpgrades(mainMenu);

            _menuPool.MouseEdgeEnabled = false;
            _menuPool.ControlDisablingEnabled = false;
            _menuPool.RefreshIndex();

            Tick += async () =>
            {
                _menuPool.ProcessMenus();
                if (API.IsControlJustPressed(0, 243) && !_menuPool.IsAnyMenuOpen()) // Our menu on/off switch
                    mainMenu.Visible = !mainMenu.Visible;
            };
        }
    }
}
