using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game_7D2D
{
    class Hacks : MonoBehaviour
    {
        public static Camera MainCamera = null;
        public static float Timer = 0f;

        //Entities
        public static List<EntityZombie> eZombie = new List<EntityZombie>();
        public static List<EntityEnemy> eEnemy = new List<EntityEnemy>();
        public static List<EntityItem> eItem = new List<EntityItem>();
        public static List<EntityNPC> eNPC = new List<EntityNPC>();
        public static List<EntityPlayer> ePlayers = new List<EntityPlayer>();
        public static List<EntityAnimal> eAnimal = new List<EntityAnimal>();
        public static List<EntitySupplyCrate> eLoot = new List<EntitySupplyCrate>();
        public static LocalPlayer localP;
        public static EntityPlayerLocal eLocalPlayer;

        //Menu Variables
        public static bool Menu = true;

        public static bool isLoaded = GameManager.Instance.gameStateManager.IsGameStarted();

        public void Start()
        {
            
        }

        public void Update()
        {
            if (isLoaded)
            {
                Modules.Hotkeys.hotkeys();
                Timer += Time.deltaTime;

                if (Timer >= 5f)
                {
                    Timer = 0f;

                    updateObjects();

                }

                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    GameStats.Set(EnumGameStats.IsCreativeMenuEnabled, true);
                }


            }
            
            checkState();
        }

        public void OnGUI()
        {
            if (!isLoaded)
            {
                GUI.Box(new Rect(5f, 5f, 250f, 35f), "");
                GUI.Label(new Rect(10f, 5f, 250f, 30f), "Menu will load when in a game");
                return;
            }

            Modules.UI.DrawMenu();

            if (Modules.UI.t_AAIM && Modules.UI.t_TFOV)
            {
                Render.DrawCircle(new Vector2((float)Screen.width / 2, (float)Screen.height / 2), 150, Color.green, 1f, false, 150);
            }

            if (Modules.UI.t_EnemyESP)
            {
                foreach (EntityEnemy Enemy in eEnemy)
                {
                    if (Enemy != null)
                    {
                        if (Enemy.IsAlive())
                        {
                            Modules.ESP.esp_drawBox(Enemy, Color.red);
                        }
                    }
                    
                }
            }
            if (Modules.UI.t_ItemESP)
            {
                foreach (EntityItem Item in eItem)
                {
                    if (Item != null)
                    {
                        Modules.ESP.esp_drawBox(Item, Color.white);
                    }
                }
                foreach (EntitySupplyCrate Item in eLoot)
                {
                    if (Item != null)
                    {
                        Modules.ESP.esp_drawBox(Item, Color.magenta);
                    }
                }
            }
            if (Modules.UI.t_NPCESP)
            {
                foreach (EntityNPC NPC in eNPC)
                {
                    if (NPC != null)
                    {
                        if (NPC.IsAlive() && NPC.IsSpawned())
                        {
                            Modules.ESP.esp_drawBox(NPC, Color.magenta);
                        }
                    }
                }
            }
            if (Modules.UI.t_PlayerESP)
            {
                foreach (EntityPlayer Player in ePlayers)
                {
                    if (Player != null)
                    {
                        if (Player.IsAlive() && Player.IsSpawned())
                        {
                            Modules.ESP.esp_drawBox(Player, Color.cyan);
                        }
                    }
                }
            }
            if (Modules.UI.t_AnimalESP)
            {
                foreach (EntityAnimal Animal in eAnimal)
                {
                    if (Animal != null)
                    {
                        if (Animal.IsAlive() && Animal.IsSpawned())
                        {
                            Modules.ESP.esp_drawBox(Animal, Color.yellow);
                        }
                    }
                }
            }

            

        }
        private void checkState()
        {
            if (isLoaded != GameManager.Instance.gameStateManager.IsGameStarted())
            {
                isLoaded = !isLoaded;
            }
        }

        public static void updateObjects()
        {
            if (Modules.UI.t_EnemyESP)
            {
                Hacks.eEnemy = UnityEngine.GameObject.FindObjectsOfType<EntityEnemy>().Where<EntityEnemy>(s => s.IsAlive()).ToList();
                Modules.UI.dbg = $"{Hacks.eEnemy.Count}";
            }
            if (Modules.UI.t_ItemESP)
            {
                Hacks.eItem = UnityEngine.GameObject.FindObjectsOfType<EntityItem>().ToList();
                Hacks.eLoot = UnityEngine.GameObject.FindObjectsOfType<EntitySupplyCrate>().ToList();
            }
            if (Modules.UI.t_NPCESP)
            {
                Hacks.eNPC = UnityEngine.GameObject.FindObjectsOfType<EntityNPC>().ToList();
            }
            if (Modules.UI.t_PlayerESP)
            {
                Hacks.ePlayers = UnityEngine.GameObject.FindObjectsOfType<EntityPlayer>().ToList();
            }
            if (Modules.UI.t_AnimalESP)
            {
                Hacks.eAnimal = UnityEngine.GameObject.FindObjectsOfType<EntityAnimal>().Where<EntityAnimal>(a => a.IsAlive()).ToList();
            }
            Hacks.localP = UnityEngine.GameObject.FindObjectOfType<LocalPlayer>();
            Hacks.eLocalPlayer = UnityEngine.GameObject.FindObjectOfType<EntityPlayerLocal>();


            /*await Task.Run(() =>
            {
                
                if (Modules.UI.t_EnemyESP)
                {
                    Hacks.eEnemy = UnityEngine.GameObject.FindObjectsOfType<EntityEnemy>().ToList();
                }
                if (Modules.UI.t_ItemESP)
                {
                    Hacks.eItem = UnityEngine.GameObject.FindObjectsOfType<EntityItem>().ToList();
                    Hacks.eLoot = UnityEngine.GameObject.FindObjectsOfType<EntitySupplyCrate>().ToList();
                }
                if (Modules.UI.t_NPCESP)
                {
                    Hacks.eNPC = UnityEngine.GameObject.FindObjectsOfType<EntityNPC>().ToList();
                }
                if (Modules.UI.t_PlayerESP)
                {
                    Hacks.ePlayers = UnityEngine.GameObject.FindObjectsOfType<EntityPlayer>().ToList();
                }
                if (Modules.UI.t_AnimalESP)
                {
                    Hacks.eAnimal = UnityEngine.GameObject.FindObjectsOfType<EntityAnimal>().ToList();
                }

                Hacks.localP = UnityEngine.GameObject.FindObjectOfType<LocalPlayer>();
                Hacks.eLocalPlayer = UnityEngine.GameObject.FindObjectOfType<EntityPlayerLocal>();
            });*/
        }

        
    }

}
