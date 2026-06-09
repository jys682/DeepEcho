namespace DeepEchoGame
{
    public class MainProgram
    {
        public Map map;
        public MonsterManager monster;
        public PlayerManager player;
        public Sonar sonar;

        private List<Zone> ligthOnCam = new List<Zone>();

        public MainProgram()
        {
            this.map = new Map();
            this.monster = new MonsterManager(map);
            this.player = new PlayerManager(map, monster);
            this.monster.SetPlayerManager(this.player);
            this.sonar = new Sonar(map);
        }
        static bool gameOver = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MainProgram main = new MainProgram();
            IntroManager input = new IntroManager();
            Submarine submarine = new Submarine();
            Zone cam;
            int cameraChoice = 0;

            input.PlayIntro();

            while (!gameOver)
            {
                input.PowerConsole(main.monster.Turn, submarine.Hp, submarine.Power);
                main.LightOnCam();
                main.LightOnCamPrint();
                main.monster.SpawnMonster(main.map, submarine);
                Console.Write("\n어떤 행동을 할까? (1. 소나 스캔, 2. 방어 행동)\n숫자 입력 :");
                bool success = int.TryParse(Console.ReadLine(), out int choose);
                if (!success)
                {
                    Console.WriteLine("[ERROR] 숫자로 입력해 주세요\n");
                    continue;
                }
                switch (choose)
                {
                    case 1:
                        cameraChoice = input.SonarConsole(main.map, main.sonar);
                        main.sonar.Scan(cameraChoice);
                        submarine.UsePower(Submarine.scan);
                        cam = main.map.Zones[cameraChoice - 1];
                        main.LightOnCheck(submarine);
                        break;
                    case 2:
                        if(submarine.Power < Submarine.light)
                        {
                            Console.WriteLine("[WARNING] 방어 행동을 할 만큼 전력이 남아있지 않다 ");
                            continue;
                        }
                        cameraChoice = input.SonarConsole(main.map, main.sonar);

                        main.player.Depend(cameraChoice, submarine);
                        main.LightOnCam();
                        main.LightOnCheck(submarine);
                        break;
                    default:
                        Console.WriteLine("[ERROR] 다시 입력해 주세요\n");
                        continue;
                }
                main.monster.MoveMonsters(main.map, submarine);
                cameraChoice = 0;

                gameOver = main.player.ending(submarine, input);
            }
            
        }

        public void LightOnCam()
        {
            ligthOnCam.Clear();
            foreach (Zone z in map.Zones)
            {
                if (z.Light == true)
                {
                    ligthOnCam.Add(z);
                }
            }
            return;
        }

        public void LightOnCamPrint()
        {
            for (int i = 0; i < ligthOnCam.Count; i++)
            {
                if (i < ligthOnCam.Count - 1)
                {
                    Console.Write($"{ligthOnCam[i].Name}, ");
                }
                else
                {
                    Console.Write(ligthOnCam[i].Name);
                }
            }
        }

        public void LightOnCheck(Submarine _sub)
        {
            foreach (Zone z in ligthOnCam)
            {
                _sub.UsePower(Submarine.light);
            }
        }

        public IntroManager input
        {
            get => default;
            set
            {
            }
        }

        public Submarine submarine
        {
            get => default;
            set
            {
            }
        }
    }
}
