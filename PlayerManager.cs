using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    public class PlayerManager
    {
        private readonly Map map;
        private readonly IntroManager input;
        private readonly MonsterManager monster;
        private readonly MainProgram mainProgram;

        public PlayerManager()
        {
            this.map = mainProgram.map;
            this.input = mainProgram.input;
            this.monster = mainProgram.monster;
            this.mainProgram = mainProgram;
        }
        public void Depend(int playercam)
        {
            Submarine submarine = new Submarine();
            bool roop = false;
            Zone cam = map.Zones[playercam];

            Console.WriteLine("어떤 방어 행동을 할까? (1. 불 키기, 2. 불 끄기, 3. 음파 공격)\t숫자 입력 :");
            int choose = int.Parse(Console.ReadLine());

            while(!roop)
            {
                switch (choose)
                {
                    case 1:
                        if (cam.Light == true)
                        {
                            Console.WriteLine("이미 불이 켜져있습니다.");
                            submarine.UsePower(Submarine.light);
                            return;
                        }
                        map.TurnOnLight(playercam);
                        submarine.UsePower(Submarine.light);
                        roop = true;
                        break;
                    case 2:
                        if (cam.Light == false)
                        {
                            Console.WriteLine("이미 불이 꺼져있습니다.");
                            return;
                        }
                        map.TurnOffLight(playercam);
                        roop = true;
                        break;
                    case 3:
                        map.SonicWaveOn(playercam);

                        if (cam.HasMonster == true)
                        {
                            Console.WriteLine("음파 공격이 적중했습니다!");
                            map.SonicWaveOff(playercam);
                        }
                        else
                        {
                            Console.WriteLine("음파 공격이 빗나갔습니다.");
                            map.SonicWaveOff(playercam);
                        }
                        submarine.UsePower(Submarine.sonic);
                        roop = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public bool ending(Submarine submarine)
        {
            if (submarine.Hp <= 0)
            {
                input.HpDownEnding();
            }
            else if (submarine.Power <= 0)
            {
                input.PowerDownEnding();
            }
            else if (monster.Turn >= 10)
            {
                input.TrueEnding();
            }
            return true;
        }
    }
}
