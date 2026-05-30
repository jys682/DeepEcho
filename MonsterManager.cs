using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DeepEchoGame
{
    public class MonsterManager //리스트 몬스터 다 죽으면 턴 체크
    {
        private readonly MainProgram mainProgram;
        private readonly Map map;
        private readonly MonsterSpawner spawner;

        private List<Monster> monsterList;
        private Random ran;
        private int turn = 0;
        private int ranPosition;
        private int ranCam;

        public MonsterManager()
        {
            this.map = mainProgram.map;
            this.spawner = new MonsterSpawner();

            this.monsterList = spawner.Spawn(turn);
            this.ran = new Random();
            this.ranPosition = ran.Next(1, 6);
            this.ranCam = ran.Next(1, 6);
        }

        public int Turn
        {
            get { return turn; }
        }

        public void SpawnMonster(Map _map, Submarine _sub)
        {
            foreach (Monster i in monsterList)
            {
                i.Position = ranPosition;
            }
        }

        public void MoveMonsters(Map _map, Submarine _sub)
        {
            do
            {
                turn++;
                SpawnMonster(_map, _sub);
            }
            while (monsterList.Count == 0);

            for (int i = monsterList.Count - 1; i >= 0; i--)
            {
                var m = monsterList[i];
                bool isTurnComplete = false; 

                while (!isTurnComplete)
                {
                    Zone cam = _map.Zones[ranCam];  

                    if (m.Position > 1)
                    {
                        m.Move(); 
                    }
                    else 
                    {
                        map.MonsterIn(ranCam);
                        if (cam.Light == true)
                        {
                            m.Attack(true);
                            m.Position = ranPosition;
                            map.MonsterOut(ranCam);
                            isTurnComplete = true;
                        }
                        else if (cam.SonicWave == true)
                        {
                            monsterList.Remove(m);
                            map.MonsterOut(ranCam);
                            isTurnComplete = true;
                        }
                        else
                        {
                            m.Attack(false);
                            _sub.damage(m.AttackPower);
                            monsterList.Remove(m);
                            map.MonsterOut(ranCam);
                            isTurnComplete = true;
                        }
                    }
                }
            }
        }
    }
}
