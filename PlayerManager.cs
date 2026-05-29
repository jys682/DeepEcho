using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    internal class PlayerManager
    {
        private Map _map;
        private IntroManager _input;
        private MonsterManager _monster;

        public PlayerManager(Map map)
        {
            this._map = map;
            this._input = new IntroManager();
            this._monster = new MonsterManager(map);
        }
        public void Depend()
        {
            Submarine submarine = new Submarine();
            bool roop = false;

            Console.WriteLine("어떤 방어 행동을 할까? (1. 불 키기, 2. 불 끄기, 3. 음파 활성화, 4. 음파 비활성화)\n숫자 입력 :");
            int choose = int.Parse(Console.ReadLine());

            while(!roop)
            {
                switch (choose)
                {
                    case 1:
                        submarine.UsePower(Submarine.light);
                        if (true)//불 꺼져있을때
                        {
                            //불키기
                            roop = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("이미 불이 켜져있습니다.");
                            return;
                        }
                    case 2:
                        submarine.UsePower(Submarine.sonic);
                        // zone에 몬스터가 있으면 몬스터 죽이기
                        break;
                    case 3:
                        if (true)//불 켜져있을때
                        {
                            //불끄기
                            roop = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("이미 불이 꺼져있습니다.");
                            return;
                        }
                    default:
                        break;
                }
            }
        }

        public bool ending(Submarine submarine)
        {
            if (submarine.Hp <= 0)
            {
                _input.HpDownEnding();
            }
            else if (submarine.Power <= 0)
            {
                _input.PowerDownEnding();
            }
            else if (_monster.Turn > 10)
            {
                _input.TrueEnding();
            }
            return true;
        }
    }
}
