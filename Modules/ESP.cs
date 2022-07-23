using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game_7D2D.Modules
{
    class ESP
    {
        private static Vector3 eb_head, eb_neck, eb_spine, eb_leftshoulder, eb_leftarm, eb_leftforearm, eb_lefthand, eb_rightshoulder, eb_rightarm, eb_rightforearm;
        private static Vector3 eb_righthand, eb_hips, eb_leftupleg, eb_leftleg, eb_leftfoot, eb_rightupleg, eb_rightleg, eb_rightfoot;
        public static void esp_drawBox(EntityEnemy entity, Color color)
        {
            Vector3 entity_head = entity.transform.position;
            Vector3 entity_feet = new Vector3(entity_head.x, entity_head.y + entity.height, entity_head.z);

            Vector3 w2s_head = Camera.main.WorldToScreenPoint(entity_head);
            Vector3 w2s_feet = Camera.main.WorldToScreenPoint(entity_feet);

            float Distance = Vector3.Distance(entity.transform.position, Hacks.eLocalPlayer.transform.position);
            Vector3 w2s_test = Camera.main.WorldToScreenPoint(entity.emodel.GetHeadTransform().position);

            if (w2s_head.z > 0f && w2s_head.x > 0 && w2s_head.x < (float)Screen.width && w2s_head.y > 0 && Distance <= 100f)
            {
                DrawESPBox(w2s_feet, w2s_head, color, entity.EntityName);
                DrawESPBox(w2s_test, new Vector3(w2s_test.x - 1f, w2s_test.y - 1f, w2s_test.z), Color.green, "");

                Transform[] entityBones = entity.GetComponentInChildren<SkinnedMeshRenderer>().bones;
                int canBone = 0;

                for (int j = 0; j < entityBones.Length; j++)
                {
                    if (entityBones[j].name == "Head") { eb_head = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Head
                    if (entityBones[j].name == "Neck") { eb_neck = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Neck
                    if (entityBones[j].name == "Spine") { eb_spine = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Spine
                    if (entityBones[j].name == "LeftShoulder") { eb_leftshoulder = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftShoulder
                    if (entityBones[j].name == "LeftArm") { eb_leftarm = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftArm
                    if (entityBones[j].name == "LeftForeArm") { eb_leftforearm = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftForeArm
                    if (entityBones[j].name == "LeftHand") { eb_lefthand = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftHand
                    if (entityBones[j].name == "RightShoulder") { eb_rightshoulder = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightShoulder
                    if (entityBones[j].name == "RightArm") { eb_rightarm = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightArm
                    if (entityBones[j].name == "RightForeArm") { eb_rightforearm = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightForeArm
                    if (entityBones[j].name == "RightHand") { eb_righthand = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightHand
                    if (entityBones[j].name == "Hips") { eb_hips = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Hips
                    if (entityBones[j].name == "LeftUpLeg") { eb_leftupleg = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftUpLeg
                    if (entityBones[j].name == "LeftLeg") { eb_leftleg = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftLeg
                    if (entityBones[j].name == "LeftFoot") { eb_leftfoot = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftFoot
                    if (entityBones[j].name == "RightUpLeg") { eb_rightupleg = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightUpLeg
                    if (entityBones[j].name == "RightLeg") { eb_rightleg = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightLeg
                    if (entityBones[j].name == "RightFoot") { eb_rightfoot = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightFoot
                }

                if (canBone >= 18)
                {
                    DrawESPLine(eb_head, eb_neck, Color.green);
                    DrawESPLine(eb_neck, eb_spine, Color.green);
                    DrawESPLine(eb_spine, eb_hips, Color.green);

                    DrawESPLine(eb_hips, eb_leftupleg, Color.green);
                    DrawESPLine(eb_leftupleg, eb_leftleg, Color.green);
                    DrawESPLine(eb_leftleg, eb_leftfoot, Color.green);
                    DrawESPLine(eb_hips, eb_rightupleg, Color.green);
                    DrawESPLine(eb_rightupleg, eb_rightleg, Color.green);
                    DrawESPLine(eb_rightleg, eb_rightfoot, Color.green);

                    DrawESPLine(eb_neck, eb_leftshoulder, Color.green);
                    DrawESPLine(eb_leftshoulder, eb_leftarm, Color.green);
                    DrawESPLine(eb_leftarm, eb_leftforearm, Color.green);
                    DrawESPLine(eb_leftforearm, eb_lefthand, Color.green);

                    DrawESPLine(eb_neck, eb_rightshoulder, Color.green);
                    DrawESPLine(eb_rightshoulder, eb_rightarm, Color.green);
                    DrawESPLine(eb_rightarm, eb_rightforearm, Color.green);
                    DrawESPLine(eb_rightforearm, eb_righthand, Color.green);
                }
                
            }
            
        }
        public static void esp_drawBox(EntityItem entity, Color color)
        {
            Vector3 entity_head = entity.transform.position;
            Vector3 entity_feet = new Vector3(entity_head.x, entity_head.y + entity.height, entity_head.z);

            Vector3 w2s_head = Camera.main.WorldToScreenPoint(entity_head);
            Vector3 w2s_feet = Camera.main.WorldToScreenPoint(entity_feet);

            float Distance = Vector3.Distance(entity.transform.position, Hacks.eLocalPlayer.transform.position);

            if (w2s_head.z > 0f && w2s_head.x > 0 && w2s_head.x < (float)Screen.width && w2s_head.y > 0 && Distance <= 100f)
            {
                DrawESPBox(w2s_feet, w2s_head, color, entity.name);
            }
        }

        public static void esp_drawBox(EntitySupplyCrate entity, Color color)
        {
            Vector3 entity_head = entity.transform.position;
            Vector3 entity_feet = new Vector3(entity_head.x, entity_head.y + entity.height, entity_head.z);

            Vector3 w2s_head = Camera.main.WorldToScreenPoint(entity_head);
            Vector3 w2s_feet = Camera.main.WorldToScreenPoint(entity_feet);

            float Distance = Vector3.Distance(entity.transform.position, Hacks.eLocalPlayer.transform.position);

            if (w2s_head.z > 0f && w2s_head.x > 0 && w2s_head.x < (float)Screen.width && w2s_head.y > 0 && Distance <= 100f)
            {
                //DrawESPBox(w2s_feet, w2s_head, color, entity.name);
                DrawESPText(w2s_feet, w2s_head, color, entity.name);
            }
        }
        public static void esp_drawBox(EntityNPC entity, Color color)
        {
            Vector3 entity_head = entity.transform.position;
            Vector3 entity_feet = new Vector3(entity_head.x, entity_head.y + entity.height, entity_head.z);

            Vector3 w2s_head = Camera.main.WorldToScreenPoint(entity_head);
            Vector3 w2s_feet = Camera.main.WorldToScreenPoint(entity_feet);

            float Distance = Vector3.Distance(entity.transform.position, Hacks.eLocalPlayer.transform.position);

            if (w2s_head.z > 0f && w2s_head.x > 0 && w2s_head.x < (float)Screen.width && w2s_head.y > 0)
            {
                DrawESPBox(w2s_feet, w2s_head, color, entity.EntityName);
            }
        }
        public static void esp_drawBox(EntityPlayer entity, Color color)
        {
            Vector3 entity_head = entity.transform.position;
            Vector3 entity_feet = new Vector3(entity_head.x, entity_head.y + entity.height, entity_head.z);

            Vector3 w2s_head = Camera.main.WorldToScreenPoint(entity_head);
            Vector3 w2s_feet = Camera.main.WorldToScreenPoint(entity_feet);
            Vector3 w2s_test = Camera.main.WorldToScreenPoint(entity.emodel.GetHeadTransform().position);

            if (w2s_head.z > 0f && w2s_head.x > 0 && w2s_head.x < (float)Screen.width && w2s_head.y > 0)
            {
                if (entity != Hacks.eLocalPlayer)
                {
                    if (entity.IsGodMode == true)
                    {
                        DrawESPBox(w2s_feet, w2s_head, color, $"{entity.EntityName} [GOD]");
                    }
                    else
                    {
                        DrawESPBox(w2s_feet, w2s_head, color, entity.EntityName);
                    }
                }
                
                DrawESPBox(w2s_test, new Vector3(w2s_test.x - 1f, w2s_test.y - 1f, w2s_test.z), Color.green, "");

            }
        }
        public static void esp_drawBox(EntityAnimal entity, Color color)
        {
            Vector3 entity_head = entity.transform.position;
            Vector3 entity_feet = new Vector3(entity_head.x, entity_head.y + entity.height, entity_head.z);

            Vector3 w2s_head = Camera.main.WorldToScreenPoint(entity_head);
            Vector3 w2s_feet = Camera.main.WorldToScreenPoint(entity_feet);
            Vector3 w2s_test = Camera.main.WorldToScreenPoint(entity.emodel.GetHeadTransform().position);

            float Distance = Vector3.Distance(entity.transform.position, Hacks.eLocalPlayer.transform.position);

            if (w2s_head.z > 0f && w2s_head.x > 0 && w2s_head.x < (float)Screen.width && w2s_head.y > 0 && Distance <= 100f)
            {
                DrawESPBox(w2s_feet, w2s_head, color, entity.EntityName.Replace("animal",""));
                DrawESPBox(w2s_test, new Vector3(w2s_test.x - 1f, w2s_test.y - 1f, w2s_test.z), Color.green, "");
            }
        }


        private static void DrawESPBox(Vector3 objfootPos, Vector3 objheadPos, Color objColor, String name)
        {
            //Draw Basic ESP Method from Vector3 W2S input
            float height = objheadPos.y - objfootPos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            Render.DrawBox(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height, width, height, objColor, 2f);
            if (name != "")
            {
                Render.DrawString(new Vector2(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height), $"{name}");
            }
        }

        private static void DrawESPText(Vector3 objfootPos, Vector3 objheadPos, Color objColor, String name)
        {
            //Draw Basic ESP Method from Vector3 W2S input
            float height = objheadPos.y - objfootPos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            Render.DrawString(new Vector2(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y), $"{name}");
            //GUI.Label(new Rect(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height, width, height), name);
        }
        private static void DrawESPLine(Vector3 pointA, Vector3 pointB, Color objColor)
        {
            Render.DrawLine(new Vector2(pointA.x, (float)Screen.height - pointA.y), new Vector2(pointB.x, (float)Screen.height - pointB.y), objColor, 1f);
        }

        
    }
}
