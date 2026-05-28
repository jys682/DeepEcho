using DeepEchoGame;
using System.Security.Cryptography.X509Certificates;

public class SpawnMonster
{
    private Random random = new Random();

    public Monster Spawn()
    {
        int monsterType = random.Next(0, 4); //몹은 숫자에 따라 결정

        Monster spawnedMonster = null; //지역 변수 초기화

        switch (monsterType)
        {
            case 0: //0 = 청새치
                spawnedMonster = new Spearfish();
                break;

            case 1: //1 = 레비아탄
                spawnedMonster = new Leviathan();
                break;

            case 2://2 = 세이렌
                spawnedMonster = new Siren();
                break;

            case 3: //3 = 창백한 고래
                spawnedMonster = new PaleWhale();
                break;
        }

        return spawnedMonster;
    }
}