using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    public class Sonar
    {
        private Map map;

        public Sonar(Map map)
        {
            this.map = map;
        }

        public void Scan(int index) //구역의 몬스터 존재 스캔
        {
            Zone target = map.FindZone(index);

            // 찾았을 때 출력
            Console.WriteLine("=== 소나 스캔 ===");

            if (target.HasMonster)
                Console.WriteLine($"\n[{target.Name}] : 위협적인 반응이 감지됩니다.");
            else
                Console.WriteLine($"\n[{target.Name}] : 외부 반응이 느껴지지 않습니다.");
        }
    }
}