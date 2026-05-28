using System;

public abstract class Monster
{
    public string Name; //이름
    public int AttackPower; //공격력
    public int Position; //위치
    public bool IsAlive; //생존 여부

    public virtual void Move()
    {
        Position--;

        if (Position < 0)
        {
            Position = 0;
        }

        Console.WriteLine($"{Name}가 접근했다.");
        Console.WriteLine($"현재 위치: {Position}");
    }

    // 불이 켜져 있으면 몬스터 공격을 막음
    public void Attack(bool isLightOn)
    {
        if (isLightOn)
        {
            Console.WriteLine("강한 조명이 몬스터의 접근을 막았다!");
            return;
        }

        Console.WriteLine($"{Name}의 공격!");
        Console.WriteLine($"{AttackPower} 피해를 입힌다!");
    }

    // 음파 공격을 받으면 뒤로 밀려남
    public void HitBySonicAttack()
    {
        Position++;

        if (Position > 3)
        {
            Position = 3;
        }

        Console.WriteLine($"{Name}이 음파 공격을 받고 뒤로 밀려났다!");
        Console.WriteLine($"현재 위치: {Position}");
    }
    // 몬스터별 특수 행동
    public virtual void UseAbility()
    {
        Console.WriteLine($"{Name}은 특별한 행동을 하지 않았다.");
    }
}