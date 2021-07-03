using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace EnterHouseScript.Resources
{
    public class Locations
    {
        public static Vector3 ApartmentSpawn;
        public static Vector3 ApartmentSpawn2;
        public static Vector3 ApartmentSpawn3;
        public static Vector3 ApartmentSpawn4;
        public static Vector3 ApartmentSpawn5;
        public static Vector3 ApartmentSpawn6;
        public static Vector3 ApartmentSpawn7;
        public static Vector3 ApartmentSpawn8;
        public static Vector3 ApartmentSpawn9;
        public static Vector3 ApartmentSpawn10;
        public static Vector3 ApartmentSpawn11;
        public static Vector3 ApartmentSpawn12;
        public static Vector3 ApartmentSpawn13;
        public static Vector3 ApartmentSpawn14;
        public static Vector3 ApartmentSpawn15;
        public static Vector3 ApartmentSpawn16;
        public static Vector3 ApartmentSpawn17;
        public static Vector3 ApartmentSpawn18;
        public static Vector3 ApartmentSpawn19;
        public static Vector3 ApartmentSpawn20;
        public static Vector3 ApartmentSpawn21;
        public static Vector3 ApartmentSpawn22;
        public static Vector3 ApartmentSpawn23;
        public static Vector3 ApartmentSpawn24;

        public static Vector3 TwoCarGarage;
        public static Vector3 SixCarGarage;
        public static Vector3 TenCarGarage;

        public static Vector3 LowEndApartment;
        public static Vector3 MediumEndApartment;

        public static Vector3 RandomOfficeSpawn;
        public static Vector3 Motel;
        public static Vector3 Bunker;
        public static Vector3 CharCreator;

        public static Vector3 CEOSpawn1;
        public static Vector3 CEOSpawn2;
        public static Vector3 CEOSpawn3;
        public static Vector3 CEOSpawn4;
        public static Vector3 CEOSpawn5;
        public static Vector3 CEOSpawn6;
        public static Vector3 CEOSpawn7;
        public static Vector3 CEOSpawn8;
        public static Vector3 CEOSpawn9;

        public static Vector3 MadrazaResidence;

        public static Vector3 marker1;
        public static Vector3 marker2;
        public static Vector3 marker3;
        public static Vector3 marker4;
        public static Vector3 marker5;
        public static Vector3 marker6;
        public static Vector3 marker7;
        public static Vector3 marker8;
        public static Vector3 marker9;
        public static Vector3 marker10;
        public static void RegisterLocations()
        {
            //Set Apartment Spawn
            ApartmentSpawn = new Vector3(-786.8663f, 315.7642f, 217.6385f);
            ApartmentSpawn2 = new Vector3(-784.73f, 323.55f, 212.0f);
            ApartmentSpawn3 = new Vector3(-786.9584f, 315.7974f, 187.9135f);
            ApartmentSpawn4 = new Vector3(-781.95f, 326.48f, 223.26f);
            ApartmentSpawn5 = new Vector3(-774.18f, 331.14f, 207.62f);
            ApartmentSpawn6 = new Vector3(-774.33f, 342.08f, 196.69f);
            ApartmentSpawn7 = new Vector3(-774.67f, 331.32f, 160.0f);
            ApartmentSpawn8 = new Vector3(341.77f, 437.67f, 149.39f);

            LowEndApartment = new Vector3(266.06f, -1007.18f, -101.01f);
            MediumEndApartment = new Vector3(347.2686f, -999.2955f, -99.19622f);

            //Set Garage Spawns
            TwoCarGarage = new Vector3(173.2903f, -1003.6f, -99.65707f);
            SixCarGarage = new Vector3(197.8153f, -1002.293f, -99.65749f);
            TenCarGarage = new Vector3(229.9559f, -981.7928f, -99.66071f);

            //Set Random Spawn
            RandomOfficeSpawn = new Vector3(-67.37f, -825.0f, 222f);
            Motel = new Vector3(152.2605f, -1004.471f, -98.99999f);
            Bunker = new Vector3(895.25f, -3245.9f, -98.25f);
            CharCreator = new Vector3(402.5164f, -1002.847f, -99.2587f);

            //Set CEO 1 Spawn
            CEOSpawn1 = new Vector3(-141.1987f, -620.913f, 168.8205f);
            CEOSpawn2 = new Vector3(-141.5429f, -620.9524f, 168.8204f);
            CEOSpawn3 = new Vector3(-141.2896f, -620.9618f, 168.8204f);
            CEOSpawn4 = new Vector3(-141.4966f, -620.8292f, 168.8204f);
            CEOSpawn5 = new Vector3(-141.3997f, -620.9006f, 168.8204f);
            CEOSpawn6 = new Vector3(-141.5361f, -620.9186f, 168.8204f);
            CEOSpawn7 = new Vector3(-141.392f, -621.0451f, 168.8204f);
            CEOSpawn8 = new Vector3(-141.1945f, -620.8729f, 168.8204f);
            CEOSpawn9 = new Vector3(-141.4924f, -621.0035f, 168.8205f);

            //Set Madraza Residence Outside
            MadrazaResidence = new Vector3(1396.63f, 1141.81f, 114.33f);

            //SetMarkerLocations
            marker1 = new Vector3(1534.98f, 2231.86f, 77.7f); //4001 Senora Freeway (ABEL)
            marker2 = new Vector3(1662.22f, 3820.46f, 35.47f); //3019 Cholla Springs Ave (BOBBY)
            marker3 = new Vector3(-44.12f, 1960.62f, 190.35f); //5001 Baytree Canyon Road (DEMON'S OLD HOUSE)
            marker4 = new Vector3(1881.38f, 3810.92f, 32.78f); //3007 Niland Ave (SANDY)
            marker5 = new Vector3(1424.94f, 3671.92f, 34.17f); //3025 Marina Drive (SANDY)
            marker6 = new Vector3(246.07f, 3169.41f, 42.83f); //4013 Joshua Road (SANDY/HARMONY)
            marker7 = new Vector3(192.15f, 3082.13f, 43.47f); //4014 Joshua Road (SANDY/HARMONY)
            marker8 = new Vector3(471.08f, 2608.08f, 44.48f); //4018 Route 68 (DOBBS)
            marker9 = new Vector3(1394.92f, 1142.05f, 114.62f); //5024 Senora Road (MADRAZA)
            marker10 = new Vector3(-818.26f, 177.72f, 72.22f); //7064 Portola Drive (Michael's House)
        }
    }
}
