using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DeepEchoGame
{
    public class MonsterManager //리스트 몬스터 다 죽으면 턴 체크
    {
        private readonly MonsterSpawner spawner;
        private List<Monster> monsterList;
        private Random ran;
        private readonly Map map;
        private int turn = 0;
        private int ranPosition;
        private int ranCam;

        public MonsterManager(Map _map)
        {
            this.spawner = new MonsterSpawner();
            this.monsterList = spawner.Spawn(turn);
            this.ran = new Random();
            this.map = _map;

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
                    Zone cam = _map.FindZone(ranCam);  //ㄱㅊ한거?

                    if (m.Position > 1)
                    {
                        m.Move(); 
                    }
                    else 
                    {
                        if (cam.Light == true)
                        {
                            m.Attack(true);
                            m.Position = ranPosition;
                            isTurnComplete = true;
                        }
                        else if (cam.SonicWave == true)
                        {
                            monsterList.Remove(m);
                            isTurnComplete = true;
                        }
                        else
                        {
                            m.UseAbility();
                            m.Attack(false);
                            _sub.damage(m.AttackPower);
                            monsterList.Remove(m);
                            isTurnComplete = true;
                        }
                    }
                }
            }
        }
    }
}
