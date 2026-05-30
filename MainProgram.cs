namespace DeepEchoGame
{
    public class MainProgram
    {
        static bool gameOver = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IntroManager input = new IntroManager();
            Submarine submarine = new Submarine();

            Map map = new Map();
            Sonar sonar = new Sonar(map);
            MonsterManager monster = new MonsterManager(map);
            PlayerManager player = new PlayerManager(map);
            int cameraChoice = 0;
            Zone cam = map.FindZone(cameraChoice);
            //input.PlayIntro();

            while (!gameOver)
            {
                input.PowerConsole(monster.Turn, submarine.Hp, submarine.Power);
                Console.Write("\n어떤 행동을 할까? (1. 소나 스캔, 2. 방어 행동)\n숫자 입력 :");

                switch (Console.ReadLine())
                {
                    case "1":
                        cameraChoice = input.SonarConsole();
                        sonar.Scan(cameraChoice);
                        if(cam.Light == true)
                        {
                            submarine.UsePower(Submarine.light);
                        }
                        break;
                    case "2":
                        cameraChoice = input.SonarConsole();
                        player.Depend(cameraChoice);
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요.");
                        return;
                }
                monster.MoveMonsters(map, submarine);
                cameraChoice = 0;

                gameOver = player.ending(submarine);
            }
            
        }
    }
}
