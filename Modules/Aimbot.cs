using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game_7D2D.Modules
{

    class Aimbot
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public static bool hasTarget = false;

        public static void AimAssist()
        {
            //Aimbot is semi copy and pasted
            float minDist = 9999f;

            Vector2 target = Vector2.zero;

            if (UI.t_TAnimals)
            {
                foreach (EntityAnimal animal in Hacks.eAnimal)
                {
                    if (animal && animal.IsAlive())
                    {
                        Vector3 lookAt = animal.emodel.GetHeadTransform().position;
                        Vector3 w2s = Camera.main.WorldToScreenPoint(lookAt);

                        // If they're outside of our FOV.
                        if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > 150f)
                            continue;

                        if (IsOnScreen(w2s))
                        {
                            float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));

                            if (distance < minDist)
                            {
                                minDist = distance;
                                target = new Vector2(w2s.x, Screen.height - w2s.y);
                            }
                        }
                    }
                }
            }

            if (UI.t_TPlayers)
            {
                foreach (EntityPlayer player in Hacks.ePlayers)
                {
                    if (player && player.IsAlive())
                    {
                        Vector3 lookAt = player.emodel.GetHeadTransform().position;
                        Vector3 w2s = Camera.main.WorldToScreenPoint(lookAt);

                        // If they're outside of our FOV.
                        if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > 150f)
                            continue;

                        if (IsOnScreen(w2s))
                        {
                            float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));

                            if (distance < minDist)
                            {
                                minDist = distance;
                                target = new Vector2(w2s.x, Screen.height - w2s.y);
                            }
                        }
                    }
                }
            }

            if (UI.t_TEnemies) {
                foreach (EntityEnemy enemy in Hacks.eEnemy)
                {
                    if (enemy && enemy.IsAlive())
                    {
                        Vector3 lookAt = enemy.emodel.GetHeadTransform().position;
                        Vector3 w2s = Camera.main.WorldToScreenPoint(lookAt);
                    
                        // If they're outside of our FOV.
                        if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > 150f)
                            continue;

                        if (IsOnScreen(w2s))
                        {
                            float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));

                            if (distance<minDist)
                            {
                                minDist = distance;
                                target = new Vector2(w2s.x, Screen.height - w2s.y);
                            }
                        }
                    }
                }
            }


            

            if (target != Vector2.zero)
            {
                double distX = target.x - Screen.width / 2f;
                double distY = target.y - Screen.height / 2f;

                distX /= 5;
                distY /= 5;

                mouse_event(0x0001, (int)distX, (int)distY, 0, 0);
            }

        }

        public static bool IsOnScreen(Vector3 position)
        {
            return position.y > 0.01f && position.y < Screen.height - 5f && position.z > 0.01f;
        }

    }
}
