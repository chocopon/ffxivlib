﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ffxivlib;
namespace PrecisionRep
{
    public class Helper
    {
        public static Entity[] FindEntityAt(float x, float y, float z,float range, Entity[] entities)
        {
            List<Entity> list = new List<Entity>();
            foreach (Entity ent in entities.Where(obj => obj.CurrentHP > 0 && obj.Invisible==0))
            {
                double dist = Math.Sqrt((x - ent.X) * (x - ent.X) + (y - ent.Y) * (y - ent.Y) + (z - ent.Z) * (z - ent.Z));

                if (ent.Name=="木人")
                {
                    dist = dist -0.5F;//木人は別？
                }
                else
                {
                    dist = dist - ent.HitCircleR;//モブのヒット半径を引く
                }
                if (dist < range)
                {
                    list.Add(ent);
                }
            }
            return list.ToArray();
        }

        public static Entity FindEntityByName(string name, Entity[] entities, int count = 0)
        {
            if (String.IsNullOrEmpty(name))
                return null;
            int c = 0;
            Entity entity = null;
            foreach (Entity ent in entities.Where(ent => ent.Name == name &&ent.Invisible==0))
            {
                entity = ent;
                if (count == c++)
                {
                    return entity;
                }
            }
            return entity;
        }

        public static Entity FindEntityByID(int id, Entity[] entities)
        {
            Entity entity = null;
            foreach (Entity ent in entities.Where(ent => ent.NPCId == id || ent.PCId == id))
            {
                entity = ent;
                return entity;
            }
            return entity;
        }
    }
}
