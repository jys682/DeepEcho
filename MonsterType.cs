using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DeepEchoGame
{
    public class Spearfish : Monster
    {
        public Spearfish()
        {
            Name = "청새치";
            AttackPower = 25;
            Position = 3;
            IsAlive = true;
        }

        public override void Move()
        {
            Position -= 2;

            if (Position < 0)
            {
                Position = 0;
            }

            Console.WriteLine($"{Name}가 엄청난 속도로 돌진한다!");
            Console.WriteLine($"현재 위치: {Position}");
        }

        public override void UseAbility()
        {
            Console.WriteLine($"{Name}가 날카로운 주둥이로 선체를 꿰뚫으려 한다!");
        }
    }
    public class Leviathan : Monster
    {
        public int PowerDrain;

        public Leviathan()
        {
            Name = "레비아탄";
            AttackPower = 10;
            Position = 3;
            IsAlive = true;

            PowerDrain = 15;
        }

        public override void Move()
        {
            Position--;

            if (Position < 0)
            {
                Position = 0;
            }

            Console.WriteLine($"{Name}이 전력 신호를 따라 조용히 접근한다...");
            Console.WriteLine($"현재 위치: {Position}");
        }

        public override void UseAbility()
        {
            Console.WriteLine($"{Name}이 탐사선 전력을 갉아먹는다!");
            Console.WriteLine($"전력 {PowerDrain} 감소!");
        }
    }
    public class Siren : Monster
    {
        public Siren()
        {
            Name = "세이렌";
            AttackPower = 5;
            Position = 3;
            IsAlive = true;
        }

        public override void Move()
        {
            Random random = new Random();

            int moveAmount = random.Next(0, 3);//0~3중 랜덤한만큼 이동

            Position -= moveAmount; //위치에서 이동 값만큼 마이너스

            if (Position < 0)
            {
                Position = 0;// 위치는 0 혹은 그 이상
            }

            Console.WriteLine($"{Name}의 위치 신호가 불안정하다...");
            Console.WriteLine($"추정 위치: {Position}");
        }

        public override void UseAbility() //몬스터 특수능력 사용
        {
            Console.WriteLine($"{Name}이 불규칙한 음파로 소나 신호를 흔든다.");
        }
    }
    public class PaleWhale : Monster
    {
        public int HullDamage;

        public PaleWhale()
        {
            Name = "창백한 고래";
            AttackPower = 40;
            Position = 3;
            IsAlive = true;

            HullDamage = 25;
        }

        public override void Move()
        {
            Position--;

            if (Position < 0)
            {
                Position = 0;
            }

            Console.WriteLine($"{Name}의 거대한 그림자가 천천히 다가온다...");
            Console.WriteLine("탐사선 전체가 낮게 흔들린다.");
            Console.WriteLine($"현재 위치: {Position}");
        }

        public override void UseAbility()
        {
            Console.WriteLine($"{Name}이 선체를 압박한다!");
            Console.WriteLine($"선체 내구도 {HullDamage} 감소!");
        }
    }
}
