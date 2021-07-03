using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using MenuAPI;

namespace client
{
    public class Main : BaseScript
    {
        public static Menu mainMenu;
        public static Menu Settings;
        public static Menu ImpoundOptions;
        public static List<string> ImpoundedVehicles = new List<string>();
        public Main()
        {
            Tick += OnTick; //Run tick method
            MenuController.MenuAlignment = MenuController.MenuAlignmentOption.Right; //Align Menu
            MenuController.MenuToggleKey = Control.VehicleSelectPrevWeapon;

            //Create Menus
            mainMenu = new Menu("Impound Menu", "Mod by Abel Gaming");
            ImpoundOptions = new Menu("Impound Options", "Mod by Abel Gaming");
            Settings = new Menu("Settings", "Mod by Abel Gaming");

            //Add Menus to Pool
            MenuController.AddMenu(mainMenu);
            MenuController.AddSubmenu(mainMenu, Settings);
            MenuController.AddSubmenu(mainMenu, ImpoundOptions);

            MainMenuOptions();
            ImpoundOptionMenuOptions();
            SettingOptions();
        }

        private static void MainMenuOptions()
        {
            //Impound Current Vehicle
            var ImpoundVehicle = new MenuItem("Impound Current Vehicle");
            mainMenu.AddMenuItem(ImpoundVehicle);
            mainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == ImpoundVehicle)
                {
                    if (Game.Player.Character.IsInVehicle())
                    {
                        ImpoundedVehicles.Add(Game.Player.Character.CurrentVehicle.DisplayName);
                        String VehicleName = Game.Player.Character.CurrentVehicle.DisplayName;
                        Screen.ShowNotification($"~o~{VehicleName} ~w~has been impounded");
                        Game.Player.Character.CurrentVehicle.Delete();
                    }
                    else
                    {
                        Screen.ShowNotification("~r~[ERROR]~w~ You are not in a vehicle");
                    }
                }
            };

            //Impound Menu Item
            var GoToImpoundOptions = new MenuItem("Impound Options");
            mainMenu.AddMenuItem(GoToImpoundOptions);
            MenuController.BindMenuItem(mainMenu, ImpoundOptions, GoToImpoundOptions);

            //Settings Menu Item
            var GoToSettings = new MenuItem("Settings");
            mainMenu.AddMenuItem(GoToSettings);
            MenuController.BindMenuItem(mainMenu, Settings, GoToSettings);
        }

        private static void ImpoundOptionMenuOptions()
        {
            //View All Impounded Vehicles
            var ImpoundedVehiclesList = new MenuListItem("Impounded Vehicles", ImpoundedVehicles, 0);
            ImpoundOptions.AddMenuItem(ImpoundedVehiclesList);
            ImpoundOptions.OnListItemSelect += async (_menu, _listitem, _listindex, _intindex) =>
            {
                if (_listitem == ImpoundedVehiclesList)
                {
                    var modelName = ImpoundedVehiclesList.GetCurrentSelection();
                    var modelHash = (uint)API.GetHashKey(modelName);

                    //Check if model is valid
                    if (API.IsModelInCdimage(modelHash))
                    {
                        //Request Model
                        API.RequestModel(modelHash);

                        //Check if model has loaded
                        while (!API.HasModelLoaded(modelHash))
                        {
                            await Delay(0);
                        }

                        //Delete vehicle if player is already in one
                        if (Game.Player.Character.IsInVehicle())
                        {
                            Game.Player.Character.CurrentVehicle.Delete();
                        }

                        //Spawn Vehicle
                        var vehicle = API.CreateVehicle(modelHash, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, Game.Player.Character.Heading, true, true);

                        //Warp Player Into Vehicle
                        API.TaskWarpPedIntoVehicle(API.GetPlayerPed(-1), vehicle, -1);
                    }
                    else
                    {
                        //Show notification that model does not exist
                        Screen.ShowNotification("~r~Model does not exist");
                    }

                }
            };
        }

        private static void SettingOptions()
        {
            //Menu Alignment
            var MenuAlignment = new MenuCheckboxItem("Align Menu Left");
            Settings.AddMenuItem(MenuAlignment);
            Settings.OnCheckboxChange += (_menu, item, index, _checked) =>
            {
                if (item == MenuAlignment)
                {
                    if (MenuAlignment.Checked)
                    {
                        MenuController.MenuAlignment = MenuController.MenuAlignmentOption.Left;
                    }
                    else
                    {
                        MenuController.MenuAlignment = MenuController.MenuAlignmentOption.Right;
                    }
                }
            };

            //Version
            var ScriptVersion = new MenuItem("Script Version");
            Settings.AddMenuItem(ScriptVersion);
            Settings.OnItemSelect += (sender, item, index) =>
            {
                if (item == ScriptVersion)
                {
                    Screen.ShowNotification("Version 1.0");
                }
            };
        }

        private static async Task OnTick()
        {
            
        }
    }
}
