private static async Task HydrantTwo()
        {
            //Define Player
            Ped player = Game.Player.Character;

            //Define Hydrant Coords
            Vector3 hydrant1 = new Vector3(184.5492f, 218.2182f, 104.7189f);
            Vector3 hydrant2 = new Vector3(226.8473f, 202.896f, 104.4526f);
            Vector3 hydrant3 = new Vector3(521.3613f, 253.03f, 102.0574f);
            Vector3 hydrant4 = new Vector3(338.3344f, 129.2688f, 102.0771f);
            Vector3 hydrant5 = new Vector3(265.1212f, 155.9369f, 103.574f);
            Vector3 hydrant6 = new Vector3(1222.044f, -293.1514f, 68.11421f);
            Vector3 hydrant7 = new Vector3(2560.393f, 347.7226f, 107.6181f);
            Vector3 hydrant8 = new Vector3(-1696.895f, -1049.545f, 11.98223f);
            Vector3 hydrant9 = new Vector3(824.0065f, -2946.987f, 5.014343f);
            Vector3 hydrant10 = new Vector3(868.6367f, -3204.491f, 4.971878f);
            Vector3 hydrant11 = new Vector3(778.2593f, -3184.396f, 5.03273f);
            Vector3 hydrant12 = new Vector3(1209.969f, -718.024f, 58.34735f);
            Vector3 hydrant13 = new Vector3(1274.053f, -711.2696f, 63.71563f);
            Vector3 hydrant14 = new Vector3(1276.975f, -631.2563f, 67.72325f);
            Vector3 hydrant15 = new Vector3(1256.002f, -573.3724f, 68.026f);

            Vector3 hydrant16 = new Vector3(1188.704f, -605.1033f, 62.85157f);
            Vector3 hydrant17 = new Vector3(1185.775f, -532.9993f, 63.7937f);
            Vector3 hydrant18 = new Vector3(1068.283f, -465.7858f, 63.71632f);
            Vector3 hydrant19 = new Vector3(1074.748f, -504.4433f, 61.75901f);
            Vector3 hydrant20 = new Vector3(1083.773f, -457.8754f, 64.22716f);
            Vector3 hydrant21 = new Vector3(1077.055f, -423.7416f, 66.01534f);
            Vector3 hydrant22 = new Vector3(1262.438f, -517.7819f, 68.0621f);
            Vector3 hydrant23 = new Vector3(1277.5f, -476.0016f, 68.0621f);
            Vector3 hydrant24 = new Vector3(1272.277f, -420.9629f, 68.0621f);
            Vector3 hydrant25 = new Vector3(1216.073f, -400.3622f, 67.13177f);
            Vector3 hydrant26 = new Vector3(1230.935f, -371.2471f, 68.03226f);
            Vector3 hydrant27 = new Vector3(1186.052f, -374.0226f, 67.88928f);
            Vector3 hydrant28 = new Vector3(1184.27f, -427.0316f, 66.21692f);
            Vector3 hydrant29 = new Vector3(1168.79f, -490.6074f, 64.44797f);
            Vector3 hydrant30 = new Vector3(1200.483f, -509.2219f, 64.07828f);

            //Get Distance Between
            float hydrant1distance = World.GetDistance(player.Position, hydrant1);
            float hydrant2distance = World.GetDistance(player.Position, hydrant2);
            float hydrant3distance = World.GetDistance(player.Position, hydrant3);
            float hydrant4distance = World.GetDistance(player.Position, hydrant4);
            float hydrant5distance = World.GetDistance(player.Position, hydrant5);
            float hydrant6distance = World.GetDistance(player.Position, hydrant6);
            float hydrant7distance = World.GetDistance(player.Position, hydrant7);
            float hydrant8distance = World.GetDistance(player.Position, hydrant8);
            float hydrant9distance = World.GetDistance(player.Position, hydrant9);
            float hydrant10distance = World.GetDistance(player.Position, hydrant10);
            float hydrant11distance = World.GetDistance(player.Position, hydrant11);
            float hydrant12distance = World.GetDistance(player.Position, hydrant12);
            float hydrant13distance = World.GetDistance(player.Position, hydrant13);
            float hydrant14distance = World.GetDistance(player.Position, hydrant14);
            float hydrant15distance = World.GetDistance(player.Position, hydrant15);

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