public class Submarine
{
    private int hp = 100;
    private int power = 100;

    public const int scan = 3;
    public const int light = 8;
    public const int sonic = 10;

    public int Hp { get { return hp; } }
    public int Power { get { return power; } }

    public bool UsePower(int amount)
    {
        if (power >= amount)
        {
            power -= amount;
            return true;
        }
        return false;
    }

    public void damage(int amount)
    {
        hp = Math.Max(0, hp - amount);
    }

    public bool destroy()
    {
        if (hp <= 0 || power <= 0)
        {
            return true;
        }
        return false;
    }
}