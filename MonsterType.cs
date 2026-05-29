using System;

namespace DeepEchoGame
{
    // 1. 세이렌
    public class Siren : Monster
    {
        private static readonly Random random = new Random();

        public Siren()
        {
            Name = "세이렌";
            AttackPower = 5;
            IsAlive = true;
        }

        public override void Move()
        {
            int moveAmount = random.Next(0, 3);

            Position -= moveAmount;

            if (Position < MinPosition)
                Position = MinPosition;

            Console.WriteLine($"{Name}의 위치 신호가 불안정하다...");
        }

        public override void UseAbility()
        {
            Console.WriteLine($"{Name}이 불규칙한 음파로 소나 신호를 흔든다.");
        }
    }

    // 2. 창백한 고래
    public class PaleWhale : Monster
    {
        private const int HullDamage = 25;

        public PaleWhale()
        {
            Name = "창백한 고래";
            AttackPower = 40;
            IsAlive = true;
        }

        public override void Move()
        {
            Position--;

            if (Position < MinPosition)
                Position = MinPosition;

            Console.WriteLine($"{Name}의 거대한 그림자가 천천히 다가온다...");
        }

        public override void UseAbility()
        {
            Console.WriteLine($"{Name}이 선체를 압박한다!");
            Console.WriteLine($"선체 내구도 {HullDamage} 감소!");
        }
    }

    // 3. 심해 아귀
    public class Anglerfish : Monster
    {
        public Anglerfish()
        {
            Name = "심해 아귀";
            AttackPower = 15;
            IsAlive = true;
        }

        public override void UseAbility()
        {
            Console.WriteLine($"{Name}이 희미한 빛으로 플레이어를 혼란시킨다.");
        }
    }

    // 4. 거대 오징어
    public class GiantSquid : Monster
    {
        public GiantSquid()
        {
            Name = "거대 오징어";
            AttackPower = 20;
            IsAlive = true;
        }

        public override void UseAbility()
        {
            Console.WriteLine($"{Name}이 먹물을 뿌려 시야를 방해한다.");
        }
    }
}