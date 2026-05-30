using System;

namespace DeepEchoGame
{
    public abstract class Monster
    {
        public string Name { get; protected set; }
        public int AttackPower { get; protected set; }
        public int Position { get; set; }
        public int monsterCam { get; set; }
        public bool IsAlive { get; set; } = true;

        protected const int MinPosition = 1;
        protected const int MaxPosition = 5;

        public virtual void Move()
        {
            Position--;

            if (Position < MinPosition)
                Position = MinPosition;

            Console.WriteLine($"{Name}가 접근했다.");
        }

        public virtual void Attack(bool isLightOn)
        {
            if (isLightOn)
            {
                Console.WriteLine("강한 조명이 몬스터의 접근을 막았다!");
                return;
            }

            Console.WriteLine($"{Name}의 공격!");
            Console.WriteLine($"{AttackPower} 피해를 입힌다!");
        }

        public virtual void HitBySonicAttack()
        {
            Console.WriteLine($"{Name}이 음파 공격을 받고 쓰러졌다!");
        }


    }
}