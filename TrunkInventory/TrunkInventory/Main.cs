using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System.Threading.Tasks;

namespace TrunkInventory
{
	public class Main : BaseScript
	{
		public static bool CanScriptRun = false;
		public static bool CanTrunkOpen = false;
		public static bool IsSpikesInHand = false;
		public static bool IsPropInHand = false;

		public static bool RifleRacked = true;
		public static bool ShotgunRacked = true;
		

		public static float distance;

		public static Vehicle lastvehicle;

		public Main()
		{
			Debug.WriteLine("Trunk Inventory Script by Abel Gaming has loaded");
			Tick += OnTick;
			Tick += TrunkCheck;
			Tick += ConeCheck;
			Tick += PoliceBarrierCheck;
			Tick += RoadConstructionBarrierCheck;
			Tick += RoadWorkBarrierCheck;
			Tick += PlaceProp;
			Tick += WeaponCheck;
		}

		private static async Task WeaponCheck()
        {
			if (RifleRacked)
            {
				if (Game.Player.Character.Weapons.HasWeapon(WeaponHash.CarbineRifle))
                {
					Game.Player.Character.Weapons.Remove(WeaponHash.CarbineRifle);
                }
            }

			if (ShotgunRacked)
            {
				if (Game.Player.Character.Weapons.HasWeapon(WeaponHash.PumpShotgun))
                {
					Game.Player.Character.Weapons.Remove(WeaponHash.PumpShotgun);
                }
            }
        }

		private static async Task PlaceProp()
		{
			if (IsPropInHand & distance >= 1.26f)
            {
				Screen.DisplayHelpTextThisFrame("Press ~INPUT_MULTIPLAYER_INFO~ to place object.");
				if (Game.IsControlJustReleased(0, Control.MultiplayerInfo))
				{
					if (MainMenu.currentobject == "Road Cone")
					{
						//Define Model
						var prop = "prop_roadcone01a";
						var propHash = API.GetHashKey(prop);

						//Get Position
						Vector3 pos = Game.Player.Character.Position;

						//Create
						Prop cone = await World.CreateProp(prop, MainMenu.previewcone.Position, MainMenu.previewcone.Rotation, true, true);

						await Delay(1500);

						cone.IsPositionFrozen = true;
					}

					if (MainMenu.currentobject == "Police Barrier")
					{
						//Define Model
						var prop = "prop_barrier_work05";
						var propHash = API.GetHashKey(prop);

						//Get Position
						Vector3 pos = Game.Player.Character.Position;

						//Create
						Prop cone = await World.CreateProp(prop, MainMenu.previewpolicebarrier.Position, MainMenu.previewpolicebarrier.Rotation, true, true);
					}

					if (MainMenu.currentobject == "Construction Barrier")
					{
						//Define Model
						var prop = "prop_barrier_work06a";
						var propHash = API.GetHashKey(prop);

						//Get Position
						Vector3 pos = Game.Player.Character.Position;

						//Create
						Prop cone = await World.CreateProp(prop, MainMenu.previewconstructionbarrier.Position, MainMenu.previewconstructionbarrier.Rotation, true, true);
					}

					if (MainMenu.currentobject == "Road Work Barrier")
					{
						//Define Model
						var prop = "prop_barrier_work06b";
						var propHash = API.GetHashKey(prop);

						//Get Position
						Vector3 pos = Game.Player.Character.Position;

						//Create
						Prop cone = await World.CreateProp(prop, MainMenu.previewroadworkbarrier.Position, MainMenu.previewroadworkbarrier.Rotation, true, true);
					}
				}
			}
		}

		private static async Task RoadWorkBarrierCheck()
		{
			//Define Model
			var prop = "prop_barrier_work06b";
			var propHash = API.GetHashKey(prop);
			var uintprop = (uint)API.GetHashKey(prop);

			//Define Position
			Vector3 pos = Game.Player.Character.Position;

			//Check for cone
			int cone = API.GetClosestObjectOfType(pos.X, pos.Y, pos.Z, 10f, uintprop, false, false, false);

			//Get Cone Coords
			Vector3 conecoords = API.GetEntityCoords(cone, false);

			//Get Distance
			float conedistance = World.GetDistance(pos, conecoords);

			//Check Distance
			if (!IsPropInHand & conedistance <= 2f)
			{
				Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to delete object");
				API.DrawMarker(0, conecoords.X, conecoords.Y, conecoords.Z + 3, 0.0f, 0.0f, 0.0f, 0.0f, 0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
				if (Game.IsControlPressed(0, Control.Pickup))
				{
					API.DeleteObject(ref cone);
					Screen.ShowNotification("~g~[SUCCESS]~w~ Object Deleted");
				}
			}
		}

		private static async Task RoadConstructionBarrierCheck()
		{
			//Define Model
			var prop = "prop_barrier_work06a";
			var propHash = API.GetHashKey(prop);
			var uintprop = (uint)API.GetHashKey(prop);

			//Define Position
			Vector3 pos = Game.Player.Character.Position;

			//Check for cone
			int cone = API.GetClosestObjectOfType(pos.X, pos.Y, pos.Z, 10f, uintprop, false, false, false);

			//Get Cone Coords
			Vector3 conecoords = API.GetEntityCoords(cone, false);

			//Get Distance
			float conedistance = World.GetDistance(pos, conecoords);

			//Check Distance
			if (!IsPropInHand & conedistance <= 2f)
			{
				Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to delete object");
				API.DrawMarker(0, conecoords.X, conecoords.Y, conecoords.Z + 3, 0.0f, 0.0f, 0.0f, 0.0f, 0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
				if (Game.IsControlPressed(0, Control.Pickup))
				{
					API.DeleteObject(ref cone);
					Screen.ShowNotification("~g~[SUCCESS]~w~ Object Deleted");
				}
			}
		}

		private static async Task PoliceBarrierCheck()
		{
			//Define Model
			var prop = "prop_barrier_work05";
			var propHash = API.GetHashKey(prop);
			var uintprop = (uint)API.GetHashKey(prop);

			//Define Position
			Vector3 pos = Game.Player.Character.Position;

			//Check for cone
			int cone = API.GetClosestObjectOfType(pos.X, pos.Y, pos.Z, 10f, uintprop, false, false, false);

			//Get Cone Coords
			Vector3 conecoords = API.GetEntityCoords(cone, false);

			//Get Distance
			float conedistance = World.GetDistance(pos, conecoords);

			//Check Distance
			if (!IsPropInHand & conedistance <= 2f)
			{
				Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to delete object");
				API.DrawMarker(0, conecoords.X, conecoords.Y, conecoords.Z + 3, 0.0f, 0.0f, 0.0f, 0.0f, 0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
				if (Game.IsControlPressed(0, Control.Pickup))
				{
					API.DeleteObject(ref cone);
					Screen.ShowNotification("~g~[SUCCESS]~w~ Object Deleted");
				}
			}
		}

		private static async Task ConeCheck()
        {
			//Define Model
			var prop = "prop_roadcone01a";
			var propHash = API.GetHashKey(prop);
			var uintprop = (uint)API.GetHashKey(prop);

			//Define Position
			Vector3 pos = Game.Player.Character.Position;

			//Check for cone
			int cone = API.GetClosestObjectOfType(pos.X, pos.Y, pos.Z, 10f, uintprop, false, false, false);

			//Get Cone Coords
			Vector3 conecoords = API.GetEntityCoords(cone, false);

			//Get Distance
			float conedistance = World.GetDistance(pos, conecoords);

			//Check Distance
			if (!IsPropInHand & conedistance <= 2f)
            {
				Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to delete object");
				API.DrawMarker(0, conecoords.X, conecoords.Y, conecoords.Z + 3, 0.0f, 0.0f, 0.0f, 0.0f, 0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
				if (Game.IsControlPressed(0, Control.Pickup))
                {
					API.DeleteObject(ref cone);
					Screen.ShowNotification("~g~[SUCCESS]~w~ Object Deleted");
                }
			}
        }

		private static async Task TrunkCheck()
		{
			if (CanTrunkOpen)
			{
				Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to open the trunk");
				if (Game.IsControlJustPressed(0, Control.Pickup))
                {
					int lastvehicle = Game.Player.Character.LastVehicle.GetHashCode();
					API.SetVehicleDoorOpen(lastvehicle, 5, false, false);
                }
			}
		}

		private static async Task OnTick()
		{
			if (!CanScriptRun & Game.Player.Character.IsInVehicle())
            {
				CanScriptRun = true;
            }

			if (Game.Player.Character.IsInVehicle())
            {
				lastvehicle = Game.Player.Character.CurrentVehicle;
            }

			if (!Game.Player.Character.IsInVehicle() & CanScriptRun)
			{
				//Check to see if last vehicle exist
				if (lastvehicle.Exists())
                {
					if (lastvehicle.ClassType == VehicleClass.Emergency)
					{
						//Get Vehicle Coords
						Vector3 vehpos = lastvehicle.Position;

						//Get Trunk Coords
						int trunk = API.GetEntityBoneIndexByName(lastvehicle.GetHashCode(), "boot");
						Vector3 trunkcoords = API.GetWorldPositionOfEntityBone(lastvehicle.GetHashCode(), trunk);

						//Get Distance Between
						distance = World.GetDistance(Game.Player.Character.Position, trunkcoords);

						//Check Distance
						if (distance <= 1.25f)
						{
							CanTrunkOpen = true;
						}
						else
						{
							CanTrunkOpen = false;
						}
					}
				}
			}
			else
            {
				CanTrunkOpen = false;
            }
		}
	}
}
