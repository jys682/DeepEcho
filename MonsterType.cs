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


    }

    // 2. 창백한 고래
    public class PaleWhale : Monster
    {
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

        public override void Move()
        {
            Position--;

            if (Position < MinPosition)
                Position = MinPosition;

            Console.WriteLine($"{Name}의 초롱 불빛이 점멸하며 다가온다...");
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

        public override void Move()
        {
            Position--;

            if (Position < MinPosition)
                Position = MinPosition;

            Console.WriteLine($"{Name}의 여러 촉수들이 점점 조여온다...");
        }


    }
}