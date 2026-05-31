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
        public int turn = 0;
        private bool comeReady = false;

        public MonsterManager(Map _map)
        {
            this.map = _map;
            this.spawner = new MonsterSpawner();
            this.ran = new Random();
        }
        public void SetPlayerManager(PlayerManager _playerManager)
        {
            this.playerManager = _playerManager;
        }
        public void SpawnMonster(Map _map, Submarine _sub)
        {
            while (monsterList == null || monsterList.Count == 0)
            {
                turn++;
                monsterList = spawner.Spawn(turn);

                foreach (Monster i in monsterList)
                {
                    i.Position = ran.Next(1, 6);
                    i.monsterCam = ran.Next(1, 6);
                }
            }
        }
        public void MoveMonsters(Map _map, Submarine _sub)
        {
            SpawnMonster(_map, _sub);
            for (int idx = 1; idx <= _map.Zones.Count; idx++)
            {
                _map.MonsterOut(idx);
            }
            for (int i = monsterList.Count - 1; i >= 0; i--)
            {
                Monster m = monsterList[i];
                Zone cam = _map.Zones[m.monsterCam - 1];

                if (m.Position > 1)
                {
                    m.Move();
                    Console.WriteLine($"{m.Name}이(가) {m.Position}0m 이내에 들어왔다...");
                }
                else
                {
                    if (playerManager.sonicAttackSuccess == true)
                    {
                        monsterList.Remove(m);
                        Console.WriteLine($"[{cam.Name}] {m.Name}이(가) 음파를 맞고 처치되었습니다!\n");
                        playerManager.sonicAttackSuccess = false;
                        monsterList.Remove(m);
                        comeReady = false;
                    }
                    else if (cam.Light == true)
                    {
                        m.Attack(true);
                        m.Position = ran.Next(3, 6);
                        Console.WriteLine($"[{cam.Name}] {m.Name}이(가) 불빛을 보고 후퇴했습니다!\n");
                        comeReady = false;
                    }
                    else if (comeReady == false)
                    {
                        Console.WriteLine($"[WARNING]{m.Name}이(가) 함선 앞까지 다가왔다\n");
                        comeReady = true;
                        continue;
                    }
                    else
                    {
                        m.Attack(false);
                        _sub.damage(m.AttackPower);
                        monsterList.Remove(m);
                        comeReady = false;
                    }
                }
            }
            MonsterAlive(_map);
        }

        public void MonsterAlive(Map _map)
        {
            foreach (Monster m in monsterList)
            {
                _map.MonsterIn(m.monsterCam);
            }
        }
    }
}
