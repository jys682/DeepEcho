namespace DeepEchoGame
{
    public class MainProgram
    {
        public Map map;
        public MonsterManager monster;
        public PlayerManager player;

        private List<Zone> ligthOnCam = new List<Zone>();

        public MainProgram()
        {
            this.map = new Map();
            this.monster = new MonsterManager(map);
            this.player = new PlayerManager(map, monster);
            this.monster.SetPlayerManager(this.player);
        }
        static bool gameOver = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MainProgram main = new MainProgram();
            IntroManager input = new IntroManager();
            Sonar sonar = new Sonar(main.map);
            Submarine submarine = new Submarine();
            int cameraChoice = 0;
            Zone cam;
            //input.PlayIntro();

            while (!gameOver)
            {
                input.PowerConsole(main.monster.Turn, submarine.Hp, submarine.Power);
                main.LightOnCam();
                main.LightOnCamPrint();
                Console.Write("\n어떤 행동을 할까? (1. 소나 스캔, 2. 방어 행동)\n숫자 입력 :");
                bool success = int.TryParse(Console.ReadLine(), out int choose);
                switch (choose)
                {
                    case 1:
                        cameraChoice = input.SonarConsole(main.map);
                        cam = main.map.Zones[cameraChoice-1];
                        sonar.Scan(cameraChoice);
                        if(cam.Light == true)
                        {
                            submarine.UsePower(Submarine.light);
                        }
                        break;
                    case 2:
                        cameraChoice = input.SonarConsole(main.map);
                        main.player.Depend(cameraChoice, submarine);
                        main.LightOnCam();
                        foreach (Zone z in main.ligthOnCam)
                        {
                            submarine.UsePower(Submarine.light);
                        }
                        break;
                    default:
                        Console.WriteLine("[ERROR] 다시 입력해 주세요\n");
                        continue;
                }
                main.monster.MoveMonsters(main.map, submarine);
                //////////////
                foreach(Zone z in main.map.Zones)
                {
                    Console.WriteLine(z.HasMonster);
                }
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
    }
}
