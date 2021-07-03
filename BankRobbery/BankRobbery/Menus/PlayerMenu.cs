using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using NativeUI;
using System;

namespace BankRobbery.Menus
{
    public class PlayerMenu : BaseScript
    {
        public MenuPool _menuPool;
        public UIMenu mainMenu;

        public string MenuName = API.GetPlayerName(Game.Player.Character.Handle);

        private string playerName = API.GetPlayerName(Game.Player.Handle);

        public void PlayerOptions(UIMenu menu)
        {
            var playeroptionssub = _menuPool.AddSubMenu(menu, "Player Options");
            for (int i = 0; i < 1; i++) ;

            playeroptionssub.MouseEdgeEnabled = false;
            playeroptionssub.ControlDisablingEnabled = false;

            var sessionincome = new UIMenuItem("Check Session Income", "");
            playeroptionssub.AddItem(sessionincome);
            playeroptionssub.OnItemSelect += (sender, item, index) =>
            {
                if (item == sessionincome)
                {
                    Screen.ShowNotification("Session Income: ~g~$" + Main.SessionIncome.ToString());
                }
            };
        }

        public void MenuOptions(UIMenu menu)
        {
            var menuoptionssub = _menuPool.AddSubMenu(menu, "Menu Options");
            for (int i = 0; i < 1; i++) ;

            menuoptionssub.MouseEdgeEnabled = false;
            menuoptionssub.ControlDisablingEnabled = false;

            var refresh = new UIMenuItem("Refresh Menu", "If your name is appearing as player#, please refresh the menu!");
            menuoptionssub.AddItem(refresh);
            menuoptionssub.OnItemSelect += (sender, item, index) =>
            {
                if (item == refresh)
                {
                    MenuName = API.GetPlayerName(Game.Player.Character.Handle);
                }
            };
        }
        public PlayerMenu()
        {
            //INI
            string resourcename = API.GetCurrentResourceName();
            string data = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config/menu.ini");
            int menukey = Int32.Parse(data);

            _menuPool = new MenuPool();
            var mainMenu = new UIMenu(playerName, "BankRobbery by Abel Gaming | Version 1.0", true);
            _menuPool.Add(mainMenu);
            PlayerOptions(mainMenu);
            MenuOptions(mainMenu);
            _menuPool.MouseEdgeEnabled = false;
            _menuPool.ControlDisablingEnabled = false;
            _menuPool.RefreshIndex();

            Tick += async () =>
            {
                _menuPool.ProcessMenus();
                if (API.IsControlJustPressed(0, menukey) && !_menuPool.IsAnyMenuOpen())
                    mainMenu.Visible = !mainMenu.Visible;
            };
        }
    }
}
