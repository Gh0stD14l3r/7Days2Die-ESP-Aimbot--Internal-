using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game_7D2D.Modules
{
    class UI
    {
        //******* ESP Toggle Variables ********
        public static bool t_ESP = false;
        public static bool t_ZombieESP = false;
        public static bool t_EnemyESP = false;
        public static bool t_EnemyBones = false;
        public static bool t_ItemESP = false;
        public static bool t_NPCESP = false;
        public static bool t_PlayerESP = false;
        public static bool t_AnimalESP = false;
        public static bool t_ESPLines = false;
        public static bool t_ESPBoxes = true;

        private static bool toggleESP = false;
        private static bool toggleZombie = false;
        private static bool toggleEnemy = false;
        private static bool toggleEnemyBones = false;
        private static bool toggleItem = false;
        private static bool toggleNPC = false;
        private static bool togglePlayer = false;
        private static bool toggleAnimal = false;
        private static bool toggleESPLines = false;
        private static bool toggleESPBoxes = false;

        //******* Aimbot Toggle Variables ********
        public static bool t_AIM = false;
        public static bool t_ARecoil = false;
        public static bool t_AAIM = false;
        public static bool t_ATARGET_Z = true;
        public static bool t_ATARGET_A = true;
        public static bool t_ATARGET_P = false;

        public static bool t_TEnemies = false;
        public static bool t_TAnimals = false;
        public static bool t_TPlayers = false;
        public static bool t_TFOV = false;

        private static bool toggleAimBot = false;
        private static bool toggleAAim = false;

        private static bool toggleTEnemies = false;
        private static bool toggleTFOV = false;
        private static bool toggleTAnimals = false;
        private static bool toggleTPlayers = false;

        public static string dbg = "debug";
        public static void DrawMenu()
        {
            if (Hacks.Menu && Hacks.isLoaded) //Menu
            {
                GUI.Box(new Rect(5f, 5f, 250f, 105f), "");
                GUI.Label(new Rect(10f, 5f, 250f, 30f), "\x37\x44\x61\x79\x73\x32\x44\x69\x65\x20\x2d\x20\x47\x68\x30\x73\x74\x20\x4d\x6f\x64\x20\x4d\x65\x6e\x75");

                toggleESP = GUI.Toggle(new Rect(10f, 30f, 250f, 25f), t_ESP, "ESP Menu");
                if (toggleESP != t_ESP)
                {
                    if (t_AIM) { t_AIM = false; }

                    t_ESP = !t_ESP;
                }
                
                toggleAimBot = GUI.Toggle(new Rect(10f, 55f, 250f, 25f), t_AIM, "Aimbot Menu");
                if (toggleAimBot != t_AIM)
                {
                    if (t_ESP) { t_ESP = false; }

                    t_AIM = !t_AIM;
                }
                GUI.Label(new Rect(10f, 85f, (float)Screen.width, (float)Screen.height), dbg);

            }

            if (Hacks.Menu && Hacks.isLoaded && t_ESP)
            {
                float basex = 260f;

                GUI.Box(new Rect(basex, 5f, 210f, 160f), "");
                
                toggleEnemy = GUI.Toggle(new Rect(basex + 10f, 10f, 95f, 25f), t_EnemyESP, "Enemy ESP");
                if (toggleEnemy != t_EnemyESP)
                {
                    t_EnemyESP = !t_EnemyESP;
                }
                toggleItem = GUI.Toggle(new Rect(basex + 10f, 35f, 95f, 25f), t_ItemESP, "Item ESP");
                if (toggleItem != t_ItemESP)
                {
                    t_ItemESP = !t_ItemESP;
                }
                toggleNPC = GUI.Toggle(new Rect(basex + 10f, 60f, 95f, 25f), t_NPCESP, "NPC ESP");
                if (toggleNPC != t_NPCESP)
                {
                    t_NPCESP = !t_NPCESP;
                }
                togglePlayer = GUI.Toggle(new Rect(basex + 10f, 85f, 95f, 25f), t_PlayerESP, "Player ESP");
                if (togglePlayer != t_PlayerESP)
                {
                    t_PlayerESP = !t_PlayerESP;
                }
                toggleAnimal = GUI.Toggle(new Rect(basex + 10f, 110f, 95f, 25f), t_AnimalESP, "Animal ESP");
                if (toggleAnimal != t_AnimalESP)
                {
                    t_AnimalESP = !t_AnimalESP;
                }
                toggleEnemyBones = GUI.Toggle(new Rect(basex + 110f, 10f, 100f, 25f), t_EnemyBones, "Enemy Bones");
                if (toggleEnemyBones != t_EnemyBones)
                {
                    t_EnemyBones = !t_EnemyBones;
                }
                toggleESPLines = GUI.Toggle(new Rect(basex + 110f, 35f, 100f, 25f), t_ESPLines, "Draw Lines");
                if (toggleESPLines != t_ESPLines)
                {
                    t_ESPLines = !t_ESPLines;
                }
                toggleESPBoxes = GUI.Toggle(new Rect(basex + 110f, 60f, 100f, 25f), t_ESPBoxes, "Draw Boxes");
                if (toggleESPBoxes != t_ESPBoxes)
                {
                    t_ESPBoxes = !t_ESPBoxes;
                }
            }

            if (Hacks.Menu && Hacks.isLoaded && t_AIM)
            {
                float basex = 260f;

                GUI.Box(new Rect(basex, 5f, 140f, 160f), "");
                
                toggleAAim = GUI.Toggle(new Rect(basex + 10f, 10f, 130f, 25f), t_AAIM, "Activate Aimbot");
                if (toggleAAim != t_AAIM)
                {
                    t_AAIM = !t_AAIM;
                }

                toggleTEnemies = GUI.Toggle(new Rect(basex + 10f, 35f, 130f, 25f), t_TEnemies, "Target Enemies");
                if (toggleTEnemies != t_TEnemies)
                {
                    t_TEnemies = !t_TEnemies;
                }

                toggleTAnimals = GUI.Toggle(new Rect(basex + 10f, 60f, 130f, 25f), t_TAnimals, "Target Animals");
                if (toggleTAnimals != t_TAnimals)
                {
                    t_TAnimals = !t_TAnimals;
                }

                toggleTPlayers = GUI.Toggle(new Rect(basex + 10f, 85f, 130f, 25f), t_TPlayers, "Target Players");
                if (toggleTPlayers != t_TPlayers)
                {
                    t_TPlayers = !t_TPlayers;
                }

                toggleTFOV = GUI.Toggle(new Rect(basex + 10f, 110f, 130f, 25f), t_TFOV, "Show FOV");
                if (toggleTFOV != t_TFOV)
                {
                    t_TFOV = !t_TFOV;
                }

            }

        }
    }
}
