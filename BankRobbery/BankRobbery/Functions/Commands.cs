using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace BankRobbery.Functions
{
    public class Commands
    {
        public static void RegisterCommands()
        {
            API.RegisterCommand("testme", new Action(TestCommand), false);
        }

        private static void TestCommand()
        {
            Screen.ShowNotification("Test");
        }
    }
}