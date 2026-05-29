using System;
using System.Collections.Generic;

namespace DeepEchoGame
{
    public class MonsterSpawner
    {
        private static readonly Random random = new Random();

        public List<Monster> Spawn(int turn)
        {
            List<Monster> spawnedMonsters = new List<Monster>();

            int spawnCount = 1;

            if (turn >= 4 && turn <= 6)
                spawnCount = 2;
            else if (turn >= 7)
                spawnCount = 3;

            for (int i = 0; i < spawnCount; i++)
            {
                spawnedMonsters.Add(CreateRandomMonster());
            }

            return spawnedMonsters;
        }

        private Monster CreateRandomMonster()
        {
            int monsterType = random.Next(0, 4);

            switch (monsterType)
            {
                case 0:
                    return new Siren();

                case 1:
                    return new PaleWhale();

                case 2:
                    return new Anglerfish();

                case 3:
                    return new GiantSquid();

                default:
                    return new Anglerfish();
            }
        }
    }
}