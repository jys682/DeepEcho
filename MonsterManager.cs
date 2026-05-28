using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    public class MonsterManager
    {
        public void spawn()
        {
            List<Monster> monsters = new List<Monster>();
            SpawnMonster spawner = new SpawnMonster();
            Random ran = new Random();
            Map map = new Map();

            monsters.Add(new Spearfish());
            monsters.Add(new Leviathan());
            monsters.Add(new Siren());
            monsters.Add(new PaleWhale());
            int ranPosition = ran.Next(0, 4);

            Monster m = spawner.Spawn();

            foreach (Monster i in monsters)
            {
                if (i.Name == m.Name)
                {
                    map.MonsterIn(ranPosition);
                    break;
                }

            }

        }
    }
}
