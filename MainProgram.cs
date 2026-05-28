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

            int turn = 1;
            int cameraChoice = 0;

            //input.PlayIntro();
            /*
            while (!gameOver)
            {
                input.PowerConsole(turn, submarine.Hp, submarine.Power);

                Console.Write("\n어떤 행동을 할까? (1. 소나 스캔, 2. 방어 행동)\n숫자 입력 :");
                switch (Console.ReadLine())
                {
                    case "1":
                        cameraChoice = input.SonarConsole();
                        sonar.Scan(cameraChoice);
                        break;
                    case "2":
                        cameraChoice = input.SonarConsole();
                        Console.WriteLine("어떤 방어 행동을 할까? (1. 불 키기, 2. 음파 공격)\n숫자 입력 :");
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다. 다시 시도해주세요.");
                        break;
                }

                turn++;

                if (submarine.Hp <= 0)
                {
                    input.HpDownEnding();
                    gameOver = true;
                }
                else if (submarine.Power <= 0)
                {
                    input.PowerDownEnding();
                    gameOver = true;
                }
                else if (turn > 10)
                {
                    input.TrueEnding();
                    gameOver = true;
                }
            }
            */
        }
    }
}
