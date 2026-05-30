using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DeepEchoGame
{
    public class MonsterManager //리스트 몬스터 다 죽으면 턴 체크
    {
        private readonly Map map;
        private PlayerManager playerManager;
        private readonly MonsterSpawner spawner;
        public List<Monster> monsterList;
        private Random ran;
        private int turn = 0;
        private bool comeReady = false;

        public MonsterManager(Map _map)
        {
            this.map = _map;
            this.spawner = new MonsterSpawner();

            this.monsterList = spawner.Spawn(turn);
            this.ran = new Random();
        }

        public int Turn {get { return turn; }}
        public void SetPlayerManager(PlayerManager _playerManager)
        {
            this.playerManager = _playerManager;
        }
        public void SpawnMonster(Map _map, Submarine _sub)
        {
            if (monsterList.Count == 0)
            {
                turn++;
                monsterList = spawner.Spawn(turn);

                foreach (Monster i in monsterList)
                {
                    i.Position = ran.Next(1, 6);
                    i.monsterCam = ran.Next(0, 5);
                }
            }
        }
        public void MoveMonsters(Map _map, Submarine _sub)
        {
            SpawnMonster(_map, _sub);
            for (int i = monsterList.Count - 1; i >= 0; i--)
            {
                var m = monsterList[i];
                Zone cam = _map.Zones[m.monsterCam];  

                if (m.Position > 1)
                {
                    map.MonsterIn(m.monsterCam);
                    m.Move();
                    ///////////////
                    Console.WriteLine("{0} moved to position {1}.", m.Name, m.Position);
                }
                else
                {
                    if(comeReady == false)
                    {
                        Console.WriteLine($"[WARNING]{m.Name}이(가) 함선 앞까지 다가왔다");
                        comeReady = true;
                        continue;
                    }
                    if (cam.Light == true)
                    {
                        m.Attack(true);
                        m.Position = ran.Next(3, 6);
                        map.MonsterOut(m.monsterCam);
                        Console.WriteLine($"[{cam.Name}] {m.Name}이(가) 불빛을 보고 후퇴했습니다!\n");
                        comeReady = false;
                    }
                    else if (playerManager.sonicAttackSuccess == true)
                    {
                        monsterList.Remove(m);
                        map.MonsterOut(m.monsterCam);
                        Console.WriteLine($"[{cam.Name}] {m.Name}이(가) 음파를 맞고 처치되었습니다!\n");
                        playerManager.sonicAttackSuccess = false;
                        comeReady = false;
                    }
                    else
                    {
                        m.Attack(false);
                        _sub.damage(m.AttackPower);
                        monsterList.Remove(m);
                        map.MonsterOut(m.monsterCam);
                        comeReady = false;
                    }

                }
            }
        }
    }
}
