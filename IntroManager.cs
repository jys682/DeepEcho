using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    public class IntroManager
    {
        public void TypeMessage(string message, int speed) // 글자 타이핑하는 효과
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
        }
        public void PlayIntro()
        {
            Console.WriteLine("=== Deep Echo ===\n\n");
            Console.WriteLine("계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
            Console.WriteLine("==================================================");
            Console.WriteLine(" 기록: 2026년 5월, 해저 5,000m 지구 최저점 탐사");
            Console.WriteLine(" 소속: 심해 탐사선 'Deep Echo' 제어실");
            Console.WriteLine(" 직책: 탐사 대장 (플레이어)");
            Console.WriteLine("==================================================");
            Thread.Sleep(4000);
            Console.WriteLine("\n[SYSTEM] 현재 자율 항해 시스템 정상 구동 중...");
            Console.WriteLine("[SYSTEM] 선체 압력 안정적. 외부 기온 2도.");
            Thread.Sleep(4000);
            Console.WriteLine("\n[RADIO] \"대장님, 샘플 채취 완료했습니다. 이제 복귀하...\"");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n삐------------!!! 삐------------!!!");
            Thread.Sleep(2000);
            Console.WriteLine("\n위이이이이이이이이이이잉-------------");
            Thread.Sleep(2000);
            Console.WriteLine("\n💥 콰아아아아엉-------!!!! 💥");
            Thread.Sleep(2000);
            Console.ResetColor();
            Console.WriteLine("\n[암전: 충격으로 인해 잠시 정신을 잃었습니다.]");
            Thread.Sleep(2000);
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine(".");

            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine(" [비상 전력 가동] SYSTEM REBOOT COMPLETE.");
            Console.WriteLine("==================================================");
            Thread.Sleep(2000);
            TypeMessage("\n[WARNING] 주 엔진 파손. 자가 발전 불가.", 70);
            TypeMessage("\n[SYSTEM] 비상 전력 모드로 전환합니다. (남은 전력: 100%)", 70);
            TypeMessage("\n[SYSTEM] 산소 공급 장치 정상 작동 중...", 70);
            TypeMessage("\n구조대 도착까지 남은 시간...", 70);
            TypeMessage("6시간", 200);
            Thread.Sleep(2000);
            TypeMessage("\n[SONAR] ...치익... 치지직... 외부 구역에서 이상 음파 포착.", 70);
            TypeMessage("\n[SONAR] 거대한 생물체가 탐사선을 향해 접근 중입니다.", 70);
            Thread.Sleep(2500);
            Console.WriteLine("\n\n구조대가 오기 전까지 시스템을 제어해 살아남으십시오.\n\n");
            Console.WriteLine("계속하려면 아무 키나 누르세요...");
            Console.ReadKey();

        }

        public void PowerConsole(int _turn, int _hp, int _power) // 임의 로직 나중에 값 연동
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"[DEEP ECHO - 제어 콘솔]\tTURN: {_turn}/10");
            Console.WriteLine("==================================================");
            Console.WriteLine($"선체 내구도: {_hp}");
            Console.WriteLine($"비상 전력  : {_power}");
            Console.WriteLine("==================================================");
            Console.WriteLine("[LOG] 불 켜진 캠: ");
            Console.WriteLine("[LOG] 음파 활성화된 캠: ");
        }

        public int SonarConsole()
        {
            Console.WriteLine("\n[LOG] 행동 가동 준비");
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(@"       ┌───────┐       ");
            Console.WriteLine(@"       │ cam1  │       ");
            Console.WriteLine(@"       └───────┘       ");
            Console.WriteLine(@"          ┌─┐          ");
            Console.WriteLine(@"         ╱   ╲         ");
            Console.WriteLine(@"        │     │        ");
            Console.WriteLine(@"      ┌─┴─────┴─┐      ");
            Console.WriteLine(@"┌────┐│ ┌─────┐ │┌────┐");
            Console.WriteLine(@"│cam3││ │cam5 │ ││cam2│");
            Console.WriteLine(@"└────┘│ └─────┘ │└────┘");
            Console.WriteLine(@"     ─┤         │      ");
            Console.WriteLine(@"      │    ┌┐   │      ");
            Console.WriteLine(@"       ╲   ││  ╱       ");
            Console.WriteLine(@"        ╲  └┘ ╱        ");
            Console.WriteLine(@"         └───┘         ");
            Console.WriteLine(@"       ┌───────┐       ");
            Console.WriteLine(@"       │ cam4  │       ");
            Console.WriteLine(@"       └───────┘       ");

            Console.Write("\n어떤 카메라를 고를까? cam_ \n숫자만 입력 :");
            int answer = int.Parse(Console.ReadLine());
            return answer;

        }

        public void TrueEnding()
        {
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine("[SYSTEM] 외부 도킹 신호 감지. 구조선 '아틀라스 호'가 도착했습니다.");
            Thread.Sleep(2000);
            TypeMessage("\n\"치이익-- 대장님! 제어실 해치를 개방합니다. 무사하셨군요!\"",70);
            Console.WriteLine("\n암흑 같던 제어실 창밖으로 구조선의 강렬한 서치라이트 빛이 쏟아져 들어옵니다.");
            Thread.Sleep(2000);
            Console.WriteLine("빛이 비치자, 잠수함을 에워싸고 있던 거대한 그림자들이 황급히 심해의 심연 속으로 흩어집니다.");
            Thread.Sleep(2000);
            Console.WriteLine("마침내 수압의 공포와 정체불명의 괴성으로부터 해방되었습니다.");
            Thread.Sleep(2000);
            Console.WriteLine("당신은 무사히 지상으로 귀환합니다.");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeMessage("[ 탈출 성공: TRUE ENDING - 심해의 생존자 ]",200);
            Console.ResetColor();

        }

        public void PowerDownEnding()
        {
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine("[SYSTEM] 비상 배터리가 완전히 방전되었습니다. 모든 시스템이 다운됩니다.");
            Thread.Sleep(2000);
            TypeMessage("\n탁.탁.탁...\n", 200);
            Thread.Sleep(2000);
            Console.WriteLine("제어 콘솔의 모니터가 차례로 꺼지더니, 마지막 남은 비상등마저 암전됩니다.");
            Thread.Sleep(2000);
            Console.WriteLine("완벽한 어둠. 이제 탐사선 내부에는 아무런 방어 장치도, 소나 스캔도 작동하지 않습니다.");
            Thread.Sleep(2000);
            Console.WriteLine("칠흑 같은 침묵 속에서... 오직 탐사선 외벽을 타고 흐르는 거대한 생물의 호흡 소리만 들려옵니다.");
            Thread.Sleep(2000);
            TypeMessage("\n스스스슥... 콰직.\n", 200);
            Console.WriteLine("어둠 속에서 무언가 제어실 유리창을 깨고 들어옵니다. 당신의 비명은 심해 속에 묻힙니다.");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TypeMessage("[ 게임 오버: BAD ENDING - 심연의 먹이 ]", 200);
            Console.ResetColor();

        }

        public void HpDownEnding()
        {
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine(".");
            Thread.Sleep(2000);
            Console.WriteLine("[CRITICAL] 선체 장갑 파손율 100%. 수압 제어 불가..");
            Thread.Sleep(2000);
            TypeMessage("\n쩌적... 콰르르릉!\n", 200);
            Thread.Sleep(2000);
            Console.WriteLine("버텨주던 제어실의 특수 강화 유리창에 거대한 균열이 가기 시작합니다.");
            Thread.Sleep(2000);
            Console.WriteLine("5,000m 아래의 가공할 심해 압력을 강철판은 더 이상 버텨내지 못합니다.");
            Thread.Sleep(2000);
            Console.WriteLine("순식간에 폭발하듯 쏟아져 들어오는 수만 톤의 심해수가 제어실을 집어삼킵니다.");
            Thread.Sleep(2000);
            Console.WriteLine("비명을 지를 시간조차 없이, 강력한 수압이 탐사선과 당신의 신체를 순식간에 으스러뜨립니다.");
            Thread.Sleep(2000);
            Console.WriteLine("Deep Echo 호는 흔적도 없이 파괴되어 해저의 고요한 무덤이 되었습니다.");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TypeMessage("[ 게임 오버: BAD ENDING - 수압 분쇄 ]", 200);
            Console.ResetColor();

        }
    }
}

