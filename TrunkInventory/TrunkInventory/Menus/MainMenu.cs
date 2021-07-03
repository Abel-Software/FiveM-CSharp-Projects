using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using NativeUI;
using System.Collections.Generic;

namespace TrunkInventory
{
	public class MainMenu : BaseScript
	{
		public static MenuPool _menuPool;
		public static UIMenu mainMenu;
		public static string currentobject;
		public static Prop previewcone;
		public static Prop previewpolicebarrier;
		public static Prop previewconstructionbarrier;
		public static Prop previewroadworkbarrier;


		public void ObjectMenu(UIMenu menu)
		{
			var objects = _menuPool.AddSubMenu(menu, "Objects");
			for (int i = 0; i < 1; i++) ;

			objects.MouseEdgeEnabled = false;
			objects.ControlDisablingEnabled = false;

			//CREATE OBJECTS LIST
			var allobjects = new List<dynamic>
			{
				"Road Cone", "Police Barrier", "Construction Barrier", "Road Work Barrier"
			};

			//SELECT OBJECT
			var selectobject = new UIMenuListItem("Select Object", allobjects, 0);
			objects.AddItem(selectobject);
			objects.OnListSelect += async (sender, item, index) =>
			{
				if (item == selectobject)
				{
					if (selectobject.CurrentItem() == "Road Cone")
                    {
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
						await BaseScript.Delay(3000);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
						await BaseScript.Delay(1500);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
						await BaseScript.Delay(3000);

						selectobject.Enabled = false;

						Screen.ShowNotification("~g~[SUCCESS]~w~ You grabbed a road cone");
						currentobject = "Road Cone";
						Main.IsPropInHand = true;

						//GHOST
						//Define Model
						var prop = "prop_roadcone01a";
						var propHash = API.GetHashKey(prop);

						//Get Position
						Vector3 pos = Game.Player.Character.Position;
						Vector3 rot = Game.Player.Character.Rotation;

						//Create Preview Prop
						previewcone = await World.CreateProp(prop, pos, Game.Player.Character.Rotation, true, true);

						//Disable Collision
						previewcone.IsCollisionEnabled = false;
						previewcone.IsRecordingCollisions = false;

						//Set Opacity
						API.SetEntityAlpha(previewcone.GetHashCode(), 90, 90);

						//ATTACH TO PLAYER
						API.AttachEntityToEntity(previewcone.GetHashCode(), Game.Player.Character.GetHashCode(), 0, 0.9f, -1f, -0.8f, rot.X, rot.Y, rot.Z, false, false, false, false, 0, false);
						//END OF GHOST

						if (_menuPool.IsAnyMenuOpen())
						{
							_menuPool.CloseAllMenus();
						}
					}

					if (selectobject.CurrentItem() == "Police Barrier")
					{
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
						await BaseScript.Delay(3000);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
						await BaseScript.Delay(1500);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
						await BaseScript.Delay(3000);

						selectobject.Enabled = false;

						Screen.ShowNotification("~g~[SUCCESS]~w~ You grabbed a police barrier");
						currentobject = "Police Barrier";
						Main.IsPropInHand = true;

						//GHOST
						//Define Model
						var prop = "prop_barrier_work05";
						var propHash = API.GetHashKey(prop);

						//Get Position
						Vector3 pos = Game.Player.Character.Position;

						//Create Preview Prop
						previewpolicebarrier = await World.CreateProp(prop, pos, Game.Player.Character.Rotation, true, true);

						//Disable Collision
						previewpolicebarrier.IsCollisionEnabled = false;
						previewpolicebarrier.IsRecordingCollisions = false;

						//Set Opacity
						API.SetEntityAlpha(previewpolicebarrier.GetHashCode(), 90, 90);

						//ATTACH TO PLAYER
						API.AttachEntityToEntity(previewpolicebarrier.GetHashCode(), Game.Player.Character.GetHashCode(), 0, 0.9f, -1f, -0.8f, 0f, 0f, 0f, false, false, false, false, 0, false);
						//END OF GHOST

						if (_menuPool.IsAnyMenuOpen())
                        {
							_menuPool.CloseAllMenus();
						}
					}

					if (selectobject.CurrentItem() == "Construction Barrier")
					{
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
						await BaseScript.Delay(3000);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
						await BaseScript.Delay(1500);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
						await BaseScript.Delay(3000);

						selectobject.Enabled = false;

						Screen.ShowNotification("~g~[SUCCESS]~w~ You grabbed a construction barrier");
						currentobject = "Construction Barrier";
						Main.IsPropInHand = true;

						//GHOST
						//Define Model
						var prop = "prop_barrier_work06a";
						var propHash = API.GetHashKey(prop);

						//Get Position
						Vector3 pos = Game.Player.Character.Position;

						//Create Preview Prop
						previewconstructionbarrier = await World.CreateProp(prop, pos, Game.Player.Character.Rotation, true, true);

						//Disable Collision
						previewconstructionbarrier.IsCollisionEnabled = false;
						previewconstructionbarrier.IsRecordingCollisions = false;

						//Set Opacity
						API.SetEntityAlpha(previewconstructionbarrier.GetHashCode(), 90, 90);

						//ATTACH TO PLAYER
						API.AttachEntityToEntity(previewconstructionbarrier.GetHashCode(), Game.Player.Character.GetHashCode(), 0, 0.9f, -1f, -0.8f, 0f, 0f, 0f, false, false, false, false, 0, false);
						//END OF GHOST

						if (_menuPool.IsAnyMenuOpen())
						{
							_menuPool.CloseAllMenus();
						}
					}

					if (selectobject.CurrentItem() == "Road Work Barrier")
					{
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
						await BaseScript.Delay(3000);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
						await BaseScript.Delay(1500);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
						await BaseScript.Delay(3000);

						selectobject.Enabled = false;

						Screen.ShowNotification("~g~[SUCCESS]~w~ You grabbed a road work barrier");
						currentobject = "Road Work Barrier";
						Main.IsPropInHand = true;

						//GHOST
						//Define Model
						var prop = "prop_barrier_work06b";
						var propHash = API.GetHashKey(prop);

						//Get Position
						Vector3 pos = Game.Player.Character.Position;

						//Create Preview Prop
						previewroadworkbarrier = await World.CreateProp(prop, pos, Game.Player.Character.Rotation, true, true);

						//Disable Collision
						previewroadworkbarrier.IsCollisionEnabled = false;
						previewroadworkbarrier.IsRecordingCollisions = false;

						//Set Opacity
						API.SetEntityAlpha(previewroadworkbarrier.GetHashCode(), 90, 90);

						//ATTACH TO PLAYER
						API.AttachEntityToEntity(previewroadworkbarrier.GetHashCode(), Game.Player.Character.GetHashCode(), 0, 0.9f, -1f, -0.8f, 0f, 0f, 0f, false, false, false, false, 0, false);
						//END OF GHOST

						if (_menuPool.IsAnyMenuOpen())
						{
							_menuPool.CloseAllMenus();
						}
					}

					
				}
			};

			//RETURN OBJECT WILL GO HERE
			var returnobject = new UIMenuListItem("Return Object", allobjects, 0);
			objects.AddItem(returnobject);
			objects.OnListSelect += async (sender, item, index) =>
            {
				if (item == returnobject)
				{
					if (returnobject.CurrentItem() == "Road Cone")
					{
						if (previewcone.Exists())
						{
							selectobject.Enabled = true;
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
							await BaseScript.Delay(3000);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
							await BaseScript.Delay(1500);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
							await BaseScript.Delay(3000);
							previewcone.Delete();
							Main.IsPropInHand = false;
							currentobject = "None";
							if (_menuPool.IsAnyMenuOpen())
							{
								_menuPool.CloseAllMenus();
							}
						}
					}

					if (returnobject.CurrentItem() == "Police Barrier")
					{
						if (previewpolicebarrier.Exists())
						{
							selectobject.Enabled = true;
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
							await BaseScript.Delay(3000);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
							await BaseScript.Delay(1500);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
							await BaseScript.Delay(3000);
							previewpolicebarrier.Delete();
							Main.IsPropInHand = false;
							currentobject = "None";
							if (_menuPool.IsAnyMenuOpen())
							{
								_menuPool.CloseAllMenus();
							}
						}
					}

					if (returnobject.CurrentItem() == "Construction Barrier")
					{
						if (previewconstructionbarrier.Exists())
                        {
							selectobject.Enabled = true;
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
							await BaseScript.Delay(3000);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
							await BaseScript.Delay(1500);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
							await BaseScript.Delay(3000);
							previewconstructionbarrier.Delete();
							Main.IsPropInHand = false;
							currentobject = "None";
							if (_menuPool.IsAnyMenuOpen())
							{
								_menuPool.CloseAllMenus();
							}
						}
					}

					if (returnobject.CurrentItem() == "Road Work Barrier")
                    {
						if (previewroadworkbarrier.Exists())
                        {
							selectobject.Enabled = true;
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
							await BaseScript.Delay(3000);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
							await BaseScript.Delay(1500);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
							await BaseScript.Delay(3000);
							previewroadworkbarrier.Delete();

							Main.IsPropInHand = false;
							currentobject = "None";
							if (_menuPool.IsAnyMenuOpen())
							{
								_menuPool.CloseAllMenus();
							}
						}
                    }
				}
            };

			//GRAB SPIKE STRIPS
			var stopstickplace = _menuPool.AddSubMenu(objects, "Grab Spike Strips");
			for (int i = 0; i < 1; i++) ;

			stopstickplace.MouseEdgeEnabled = false;
			stopstickplace.ControlDisablingEnabled = false;

			//PLACE SPIKE STRIPS
			var placestopsticks = new UIMenuItem("Place Spike Strips", "");
			stopstickplace.AddItem(placestopsticks);
			stopstickplace.OnItemSelect += (sender, item, index) =>
			{
				if (item == placestopsticks)
				{
					API.ExecuteCommand("+deployspikes");
					Screen.ShowNotification("~g~[SUCCESS] ~w~Spike strips deployed");
					if (_menuPool.IsAnyMenuOpen())
					{
						_menuPool.CloseAllMenus();
					}
				}
			};
		}

		public MainMenu()
		{
			_menuPool = new MenuPool();
			var mainMenu = new UIMenu("Trunk Inventory", "Developed by ~b~Abel Gaming");
			_menuPool.Add(mainMenu);

			//Add Non Menu Items

			//Rack & Unrack AR
			var ar = new UIMenuItem("Unrack AR", "");
			ar.SetRightBadge(UIMenuItem.BadgeStyle.Gun);
			mainMenu.AddItem(ar);
			mainMenu.OnItemSelect += async (sender, item, index) =>
			{
				if (item == ar)
				{
					if (ar.Text == "Unrack AR")
					{
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
						await BaseScript.Delay(3000);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
						await BaseScript.Delay(1500);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
						await BaseScript.Delay(3000);

						Main.RifleRacked = false;

						Game.Player.Character.Weapons.Give(WeaponHash.CarbineRifle, 500, true, true);
						Screen.ShowNotification("~g~[SUCCESS] ~w~Rifle unracked");
						ar.Text = "Rack AR";
						if (_menuPool.IsAnyMenuOpen())
						{
							_menuPool.CloseAllMenus();
						}
					}
					else if (ar.Text == "Rack AR")
					{
						if (Game.Player.Character.Weapons.HasWeapon(WeaponHash.CarbineRifle))
						{
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
							await BaseScript.Delay(3000);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
							await BaseScript.Delay(1500);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
							await BaseScript.Delay(3000);

							Main.RifleRacked = true;

							Game.Player.Character.Weapons.Remove(WeaponHash.CarbineRifle);
						}
						Screen.ShowNotification("~g~[SUCCESS] ~w~Rifle racked");
						ar.Text = "Unrack AR";
						if (_menuPool.IsAnyMenuOpen())
						{
							_menuPool.CloseAllMenus();
						}
					}
				}
			};

			//Rack & Unrack Shotgun
			var shotgun = new UIMenuItem("Unrack Shotgun", "");
			shotgun.SetRightBadge(UIMenuItem.BadgeStyle.Gun);
			mainMenu.AddItem(shotgun);
			mainMenu.OnItemSelect += async (sender, item, index) =>
			{
				if (item == shotgun)
				{
					if (shotgun.Text == "Unrack Shotgun")
					{
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
						await BaseScript.Delay(3000);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
						await BaseScript.Delay(1500);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
						await BaseScript.Delay(3000);

						Main.ShotgunRacked = false;

						Game.Player.Character.Weapons.Give(WeaponHash.PumpShotgun, 500, true, true);
						Screen.ShowNotification("~g~[SUCCESS] ~w~Shotgun unracked");
						shotgun.Text = "Rack Shotgun";
						if (_menuPool.IsAnyMenuOpen())
						{
							_menuPool.CloseAllMenus();
						}
					}
					else if (shotgun.Text == "Rack Shotgun")
					{
						if (Game.Player.Character.Weapons.HasWeapon(WeaponHash.PumpShotgun))
						{
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
							await BaseScript.Delay(3000);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
							await BaseScript.Delay(1500);
							Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
							await BaseScript.Delay(3000);

							Main.ShotgunRacked = true;

							Game.Player.Character.Weapons.Remove(WeaponHash.PumpShotgun);
						}
						Screen.ShowNotification("~g~[SUCCESS] ~w~Shotgun racked");
						shotgun.Text = "Unrack Shotgun";
						if (_menuPool.IsAnyMenuOpen())
						{
							_menuPool.CloseAllMenus();
						}
					}
				}
			};

			//REFILL TASER
			var refilltaser = new UIMenuItem("Refill Taser Cartridge", "");
			refilltaser.SetRightBadge(UIMenuItem.BadgeStyle.Ammo);
			mainMenu.AddItem(refilltaser);
			mainMenu.OnItemSelect += async (sender, item, index) =>
			{
				if (item == refilltaser)
				{
					if (Game.Player.Character.Weapons.HasWeapon(WeaponHash.StunGun))
					{
						//Animation
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@enter", "enter");
						await BaseScript.Delay(3000);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@base", "base");
						await BaseScript.Delay(1500);
						Game.Player.Character.Task.PlayAnimation("amb@prop_human_bum_bin@exit", "exit");
						await BaseScript.Delay(3000);

						//Execute Command
						API.ExecuteCommand("+taserrefill");

						//Notification
						if (_menuPool.IsAnyMenuOpen())
						{
							_menuPool.CloseAllMenus();
						}
					}
				}
			};
			//End of Non Menu Items

			//Add Sub Menus
			ObjectMenu(mainMenu);

			//Close Trunk Button
			var closetrunk = new UIMenuItem("~r~Close Trunk", "");
			mainMenu.AddItem(closetrunk);
			mainMenu.OnItemSelect += (sender, item, index) =>
			{
				if (item == closetrunk)
				{
					int lastvehicle = Game.Player.Character.LastVehicle.GetHashCode();
					API.SetVehicleDoorShut(lastvehicle, 5, false);
					if (_menuPool.IsAnyMenuOpen())
					{
						_menuPool.CloseAllMenus();
					}
				}
			};
			//END OF TRUNK CLOSE BUTTOM

			_menuPool.MouseEdgeEnabled = false;
			_menuPool.ControlDisablingEnabled = false;
			_menuPool.RefreshIndex();

			Tick += async () =>
			{
				_menuPool.ProcessMenus();
				if (Main.CanTrunkOpen & API.IsControlJustPressed(0, 38) && !_menuPool.IsAnyMenuOpen()) // Our menu on/off switch
					mainMenu.Visible = !mainMenu.Visible;
			};
		}
	}
}