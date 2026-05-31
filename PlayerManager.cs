using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    public class PlayerManager
    {
        private readonly Map map;
        private readonly MonsterManager monsterMgr;
        public bool sonicAttackSuccess { get; set; }

        public PlayerManager(Map _map, MonsterManager _monsterMgr)
        {
            this.map = _map;
            this.monsterMgr = _monsterMgr;
        }
        public void Depend(int playercam, Submarine submarine)
        {
            bool roop = false;
            Zone cam = map.Zones[playercam-1];

            while (!roop)
            {
                Console.Write("\n어떤 방어 행동을 할까? (1. 불 키기, 2. 불 끄기, 3. 음파 공격)\n숫자 입력 :");
                if (!int.TryParse(Console.ReadLine(), out int choose))
                {
                    Console.WriteLine("[ERROR] 다시 입력해 주세요\n");
                    continue;
                }
                switch (choose)
                {
                    case 1:
                        if (cam.Light == true)
                        {
                            Console.WriteLine($"[{cam.Name}] 이미 불이 켜져있습니다.\n");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"[{cam.Name}] 불을 켰습니다.\n");
                            map.TurnOnLight(playercam);
                            roop = true;
                            break;
                        }
                    case 2:
                        if (cam.Light == false)
                        {
                            Console.WriteLine($"[{cam.Name}] 이미 불이 꺼져있습니다.\n");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"[{cam.Name}] 불을 껐습니다.\n");
                            map.TurnOffLight(playercam);
                            roop = true;
                            break;
                        }
                    case 3:
                        map.SonicWaveOn(playercam);
                        foreach (Monster m in monsterMgr.monsterList)
                        {
                            if (m.Position == 1 && cam.HasMonster)
                            {
                                Console.WriteLine($"[{cam.Name}] 음파 공격이 적중했습니다!");
                                sonicAttackSuccess = true;
                                break;
                            }
                        }
                        if(sonicAttackSuccess == true)
                        {
                            map.SonicWaveOff(playercam);
                            submarine.UsePower(Submarine.sonic);
                            roop = true;
                        }
                        else
                        {
                            Console.WriteLine($"[{cam.Name}] 음파 공격이 빗나갔습니다.");
                            sonicAttackSuccess = false;
                            map.SonicWaveOff(playercam);
                            submarine.UsePower(Submarine.sonic);
                            roop = true;
                        }
                        break;
                    default:
                        Console.WriteLine("[ERROR] 다시 입력해 주세요\n");
                        break;
                }
            }
        }

        public bool ending(Submarine submarine, IntroManager input)
        {
            if (submarine.Hp <= 0)
            {
                input.HpDownEnding();
                return true;
            }
            else if (submarine.Power <= 0)
            {
                input.PowerDownEnding();
                return true;
            }
            else if (monsterMgr.turn >= 10)
            {
                input.TrueEnding();
                return true;
            }
            return false;
        }
    }
}
