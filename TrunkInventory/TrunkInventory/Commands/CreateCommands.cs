using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;

namespace TrunkInventory.Commands
{
    public class CreateCommands : BaseScript
    {
        public CreateCommands()
        {
            API.RegisterCommand("+delprop", new Action(DeleteProps), false);
        }

        private static void DeleteProps()
        {
            foreach (Prop spawnedprop in World.GetAllProps())
            {
                spawnedprop.Delete();
            }
        }
    }
}
