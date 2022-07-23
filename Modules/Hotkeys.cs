using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game_7D2D.Modules
{
    class Hotkeys
    {
        public static void hotkeys()
        {
            
            if (Input.GetKeyDown(KeyCode.End)) // Kill hacks on "End" key pressed
            {
                Loader.unload();
            }
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                Hacks.Menu = !Hacks.Menu;
            }
            if (Input.GetKey(KeyCode.Mouse1) && UI.t_AAIM)
            {
                Aimbot.AimAssist();
            }
        }
    }
}
