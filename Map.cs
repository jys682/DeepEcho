using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    public class Map
    {
        private List<Zone> zones = new List<Zone>();

        public List<Zone> Zones
        {
            get { return zones; }
        }

        public Map()
        {
            int zoneCount = 5;

            for (int i = 1; i <= zoneCount; i++)
            {
                zones.Add(new Zone("cam" + i));
            }
        }

        //Zone에 접근
        public void MonsterIn(int index) //cam[번호]에 몬스터 생성
        {
            if (index > 0 && index <= Zones.Count)
                zones[index - 1].MonsterIn();
        }

        public void MonsterOut(int index) //cam[번호]에 몬스터 삭제
        {
            if (index > 0 && index <= Zones.Count)
                zones[index - 1].MonsterOut();
        }

        public void TurnOnLight(int index) //cam[번호]의 라이트 켜기
        {
            if (index > 0 && index <= Zones.Count)
                zones[index - 1].turnOnLight();
        }

        public void TurnOffLight(int index) //cam[번호]의 라이트 끄기
        {
            if (index > 0 && index <= Zones.Count)
                zones[index - 1].turnOffLight();
        }

        public void SonicWaveOn(int index) //cam[번호]에 음파공격 활성화
        {
            if (index > 0 && index <= Zones.Count)
                zones[index - 1].sonicWaveOn();
        }

        public void SonicWaveOff(int index) //cam[번호]에 음파공격 비활성화
        {
            if (index > 0 && index <= Zones.Count)
                zones[index - 1].sonicWaveOff();
        }
    }
}