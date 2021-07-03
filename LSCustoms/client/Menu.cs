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
    public class Menu : BaseScript
    {
        public static MenuPool _menuPool;
        public static UIMenu mainMenu;
        public static UIMenuItem EnterCustoms;

        private static int playervehicle;

        public static void CreateList(Vehicle car)
        {
            playervehicle = API.GetVehiclePedIsIn(API.GetPlayerPed(-1), true); //Get Current Vehicle INT ID
        }

        public void UpgradeOptions(UIMenu menu)
        {
            //Create Options Sub
            var vehicleupgradesub = _menuPool.AddSubMenu(menu, "Vehicle Modifications");
            for (int i = 0; i < 1; i++) ;

            vehicleupgradesub.MouseEdgeEnabled = false;
            vehicleupgradesub.ControlDisablingEnabled = false;

            //Create Lists
            var Spoiler = new List<dynamic> { "0", "1" };
            var FrontBumper = new List<dynamic> { "0", "1" };
            var RearBumper = new List<dynamic> { "0", "1" };
            var SideSkirt = new List<dynamic> { "0", "1" };
            var Exhaust = new List<dynamic> { "0", "1" };
            var Frame = new List<dynamic> { "0", "1" };
            var Grille = new List<dynamic> { "0", "1" };
            var Hood = new List<dynamic> { "0", "1" };
            var Fender = new List<dynamic> { "0", "1" };
            var Roof = new List<dynamic> { "0", "1" };
            var Engine = new List<dynamic> { "0", "1" };
            var Brakes = new List<dynamic> { "0", "1" };
            var Transmission = new List<dynamic> { "0", "1" };
            var Horns = new List<dynamic> { "0", "1" };
            var Suspension = new List<dynamic> { "0", "1" };
            var Armor = new List<dynamic> { "0", "1" };
            var FrontWheels = new List<dynamic> { "0", "1" };
            var RearWheels = new List<dynamic> { "0", "1"};

            //Main Options
            mainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == EnterCustoms)
                {
                    //Clear All
                    Spoiler.Clear();
                    FrontBumper.Clear();
                    RearBumper.Clear();
                    SideSkirt.Clear();
                    Exhaust.Clear();
                    Frame.Clear();
                    Grille.Clear();
                    Hood.Clear();
                    Fender.Clear();
                    Roof.Clear();
                    Engine.Clear();
                    Brakes.Clear();
                    Transmission.Clear();
                    Horns.Clear();
                    Suspension.Clear();
                    Armor.Clear();
                    FrontWheels.Clear();
                    RearWheels.Clear();

                    //Get Possible Mods for All
                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 0); i++)
                    {
                        Spoiler.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 1); i++)
                    {
                        FrontBumper.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 2); i++)
                    {
                        RearBumper.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 3); i++)
                    {
                        SideSkirt.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 4); i++)
                    {
                        Exhaust.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 5); i++)
                    {
                        Frame.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 6); i++)
                    {
                        Grille.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 7); i++)
                    {
                        Hood.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 8); i++)
                    {
                        Fender.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 10); i++)
                    {
                        Roof.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 11); i++)
                    {
                        Engine.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 12); i++)
                    {
                        Brakes.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 13); i++)
                    {
                        Transmission.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 14); i++)
                    {
                        Horns.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 15); i++)
                    {
                        Suspension.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 16); i++)
                    {
                        Armor.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 23); i++)
                    {
                        FrontWheels.Add(i.ToString());
                    }

                    for (int i = 0; i <= API.GetNumVehicleMods(playervehicle, 24); i++)
                    {
                        RearWheels.Add(i.ToString());
                    }

                    //Refresh Index
                    vehicleupgradesub.RefreshIndex();

                    //Hide Main Menu
                    mainMenu.Visible = false;

                    //Show Modification Menu
                    vehicleupgradesub.Visible = true; //Show the menu
                }
            };

            //-------------------------------------- MODIFICATIONS ------------------------------------------

            //SPOILER
            var SpoilerUpgrade = new UIMenuListItem("Spoiler", Spoiler, 0);
            vehicleupgradesub.AddItem(SpoilerUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == SpoilerUpgrade)
                {
                    int SelectedItem = int.Parse(SpoilerUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 0, SelectedItem, false);
                }
            };

            //FRONT BUMPER
            var FrontBumperUpgrade = new UIMenuListItem("Front Bumper", FrontBumper, 0);
            vehicleupgradesub.AddItem(FrontBumperUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == FrontBumperUpgrade)
                {
                    int SelectedItem = int.Parse(FrontBumperUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 1, SelectedItem, false);
                }
            };

            //REAR BUMPER
            var RearBumperUpgrade = new UIMenuListItem("Rear Bumper", RearBumper, 0);
            vehicleupgradesub.AddItem(RearBumperUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == RearBumperUpgrade)
                {
                    int SelectedItem = int.Parse(RearBumperUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 2, SelectedItem, false);
                }
            };

            //Side Skirts
            var SideSkirtsUpgrade = new UIMenuListItem("Side Skirt", SideSkirt, 0);
            vehicleupgradesub.AddItem(SideSkirtsUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == SideSkirtsUpgrade)
                {
                    int SelectedItem = int.Parse(SideSkirtsUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 3, SelectedItem, false);
                }
            };

            //Exhaust
            var ExhaustUpgrade = new UIMenuListItem("Exhaust", Exhaust, 0);
            vehicleupgradesub.AddItem(ExhaustUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == ExhaustUpgrade)
                {
                    int SelectedItem = int.Parse(ExhaustUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 4, SelectedItem, false);
                }
            };

            //Frame
            var FrameUpgrade = new UIMenuListItem("Frame", Frame, 0);
            vehicleupgradesub.AddItem(FrameUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == FrameUpgrade)
                {
                    int SelectedItem = int.Parse(FrameUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 5, SelectedItem, false);
                }
            };

            //Grille
            var GrilleUpgrade = new UIMenuListItem("Grille", Grille, 0);
            vehicleupgradesub.AddItem(GrilleUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == GrilleUpgrade)
                {
                    int SelectedItem = int.Parse(GrilleUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 6, SelectedItem, false);
                }
            };

            //Hood 7
            var HoodUpgrade = new UIMenuListItem("Hood", Hood, 0);
            vehicleupgradesub.AddItem(HoodUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == HoodUpgrade)
                {
                    int SelectedItem = int.Parse(HoodUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 7, SelectedItem, false);
                }
            };

            //Fender 8
            var FenderUpgrade = new UIMenuListItem("Fender", Fender, 0);
            vehicleupgradesub.AddItem(FenderUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == FenderUpgrade)
                {
                    int SelectedItem = int.Parse(FenderUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 8, SelectedItem, false);
                }
            };

            //Roof 10
            var RoofUpgrade = new UIMenuListItem("Roof", Roof, 0);
            vehicleupgradesub.AddItem(RoofUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == RoofUpgrade)
                {
                    int SelectedItem = int.Parse(RoofUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 10, SelectedItem, false);
                }
            };

            //ENGINE
            var EngineUpgrade = new UIMenuListItem("Engine", Engine, 0);
            vehicleupgradesub.AddItem(EngineUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == EngineUpgrade)
                {
                    int SelectedItem = int.Parse(EngineUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 11, SelectedItem, false);
                }
            };

            //Brakes 12
            var BrakeUpgrade = new UIMenuListItem("Brakes", Brakes, 0);
            vehicleupgradesub.AddItem(BrakeUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == BrakeUpgrade)
                {
                    int SelectedItem = int.Parse(BrakeUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 12, SelectedItem, false);
                }
            };

            //Transmission 13
            var TransmissionUpgrade = new UIMenuListItem("Transmission", Transmission, 0);
            vehicleupgradesub.AddItem(TransmissionUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == TransmissionUpgrade)
                {
                    int SelectedItem = int.Parse(TransmissionUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 13, SelectedItem, false);
                }
            };

            //Horns 14
            var HornUpgrade = new UIMenuListItem("Horns", Horns, 0);
            vehicleupgradesub.AddItem(HornUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == HornUpgrade)
                {
                    int SelectedItem = int.Parse(HornUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 14, SelectedItem, false);
                }
            };

            //Suspension 15
            var SuspensionUpgrade = new UIMenuListItem("Suspension", Suspension, 0);
            vehicleupgradesub.AddItem(SuspensionUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == SuspensionUpgrade)
                {
                    int SelectedItem = int.Parse(SuspensionUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 15, SelectedItem, false);
                }
            };

            //Armor 16
            var ArmorUpgrade = new UIMenuListItem("Armor", Armor, 0);
            vehicleupgradesub.AddItem(ArmorUpgrade);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == ArmorUpgrade)
                {
                    int SelectedItem = int.Parse(ArmorUpgrade.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 16, SelectedItem, false);
                }
            };

            //Front Wheels 23
            var FrontWheelUpgrades = new UIMenuListItem("Front Wheels", FrontWheels, 0);
            vehicleupgradesub.AddItem(FrontWheelUpgrades);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == FrontWheelUpgrades)
                {
                    int SelectedItem = int.Parse(FrontWheelUpgrades.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 23, SelectedItem, false);
                }
            };

            //Rear Wheels 24
            var RearWheelUpgrades = new UIMenuListItem("Rear Wheels", RearWheels, 0);
            vehicleupgradesub.AddItem(RearWheelUpgrades);
            vehicleupgradesub.OnListChange += (sender, item, index) =>
            {
                if (item == RearWheelUpgrades)
                {
                    int SelectedItem = int.Parse(RearWheelUpgrades.CurrentItem());
                    API.SetVehicleModKit(playervehicle, 0);
                    API.SetVehicleMod(playervehicle, 24, SelectedItem, false);
                }
            };
        }

        public Menu()
        {
            _menuPool = new MenuPool(); //Create MenuPool
            mainMenu = new UIMenu("Los Santos Customs", "Mod by ~b~Abel Gaming"); //Create MainMenu
            _menuPool.Add(mainMenu); //Add the main menu to the menu pool

            EnterCustoms = new UIMenuItem("Enter Customs", "~r~Must select before selecting vehicle modifications"); //Creates the enter customs menu item
            mainMenu.AddItem(EnterCustoms); //Adds the enter customs menu item to the menu
            UpgradeOptions(mainMenu); //Add the upgrade options to the menu pool

            _menuPool.MouseEdgeEnabled = false;
            _menuPool.ControlDisablingEnabled = false;
            _menuPool.RefreshIndex();

            Tick += async () =>
            {
                _menuPool.ProcessMenus();
            };
        }
    }
}
