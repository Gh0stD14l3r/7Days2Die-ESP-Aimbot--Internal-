using System;
using System.Threading;
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
        public static List<vp_FPWeapon> eWeapons = new List<vp_FPWeapon>();
        public static List<EntitySupplyCrate> eLoot = new List<EntitySupplyCrate>();

        public static EntityPlayerLocal eLocalPlayer;

        //Menu Variables
        public static bool Menu = true;

        public static bool isLoaded = GameManager.Instance.gameStateManager.IsGameStarted();
        public static ConsoleCmdGiveQualityItem console = new ConsoleCmdGiveQualityItem();

        public void Start()
        {
           
        }

        public void Update()
        {
            Modules.Hotkeys.hotkeys();

            // 5 Second timer to loop entities and objects to return to lists
            Timer += Time.deltaTime; 
            if (Timer >= 5f) 
            {
                Timer = 0f;

                MainCamera = Camera.main;

                eEnemy = UnityEngine.GameObject.FindObjectsOfType<EntityEnemy>().ToList();
                eItem = UnityEngine.GameObject.FindObjectsOfType<EntityItem>().ToList();
                eNPC = UnityEngine.GameObject.FindObjectsOfType<EntityNPC>().ToList();
                ePlayers = UnityEngine.GameObject.FindObjectsOfType<EntityPlayer>().ToList();
                eAnimal = UnityEngine.GameObject.FindObjectsOfType<EntityAnimal>().ToList();
                eWeapons = UnityEngine.GameObject.FindObjectsOfType<vp_FPWeapon>().ToList();
                eLoot = UnityEngine.GameObject.FindObjectsOfType<EntitySupplyCrate>().ToList();
                
                eLocalPlayer = UnityEngine.GameObject.FindObjectOfType<EntityPlayerLocal>();
            }
            

            checkState();
            
        }

        public void OnGUI()
        {
            Modules.UI.DrawMenu();
            
            if (Modules.UI.t_EnemyESP)
            {
                foreach (EntityEnemy Enemy in eEnemy)
                {
                    if (Enemy != null)
                    {
                        if (Enemy.IsAlive() && Enemy.IsSpawned())
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

    }
}
