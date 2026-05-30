namespace DeepEchoGame
{
    public class MainProgram
    {
        public static MainProgram main;
        public Map map;
        public IntroManager input;
        public MonsterManager monster;
        public PlayerManager player;

        public MainProgram()
        {
            main = this;
        }

        static bool gameOver = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MainProgram mainProgram = new MainProgram();
            mainProgram.map = new Map();
            mainProgram.input = new IntroManager();
            mainProgram.monster = new MonsterManager();
            mainProgram.player = new PlayerManager();

            Sonar sonar = new Sonar(mainProgram.map);
            Submarine submarine = new Submarine();
            int cameraChoice = 0;
            Zone cam = mainProgram.map.Zones[cameraChoice];
            //input.PlayIntro();

            while (!gameOver)
            {
                mainProgram.input.PowerConsole(mainProgram.monster.Turn, submarine.Hp, submarine.Power);
                Console.Write("\n어떤 행동을 할까? (1. 소나 스캔, 2. 방어 행동)\n숫자 입력 :");

                switch (Console.ReadLine())
                {
                    case "1":
                        cameraChoice = mainProgram.input.SonarConsole();
                        sonar.Scan(cameraChoice);
                        if(cam.Light == true)
                        {
                            submarine.UsePower(Submarine.light);
                        }
                        break;
                    case "2":
                        cameraChoice = mainProgram.input.SonarConsole();
                        mainProgram.player.Depend(cameraChoice);
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요.");
                        return;
                }
                mainProgram.monster.MoveMonsters(mainProgram.map, submarine);
                cameraChoice = 0;

                gameOver = mainProgram.player.ending(submarine);
            }
            
        }

        public void LigthOnCam()
        {
            List<Zone> ligthOnCam = new List<Zone>();
            foreach(Zone z in map.Zones)
            {
                if (z.Light == true)
                {
                    ligthOnCam.Add(z);
                }
            }
            foreach (Zone zone in ligthOnCam)
            {
                int count = 1;
                if (count < ligthOnCam.Count)
                {
                    Console.Write($"cam{zone.Name}, ");
                }
                else
                    Console.Write($"cam{zone.Name} ");
            }
        }
    }
}
