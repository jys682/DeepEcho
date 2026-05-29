using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    public class Map
    {
        private List<Zone> Zones = new List<Zone>(); //모든 구역을 리스트에 저장

        public Map()
        {
            int zoneCount = 5;

            for (int i = 1; i <= zoneCount; i++)
            {
                Zones.Add(new Zone("cam" + i));
            }
        }

        //Zone에 접근
        public void MonsterIn(int index) //cam[번호]에 몬스터 생성
        {
            if (index > 0 && index <= Zones.Count)
                Zones[index - 1].MonsterIn();
        }

        public void MonsterOut(int index) //cam[번호]에 몬스터 삭제
        {
            if (index > 0 && index <= Zones.Count)
                Zones[index - 1].MonsterOut();
        }

        public void TurnOnLight(int index) //cam[번호]의 라이트 켜기
        {
            if (index > 0 && index <= Zones.Count)
                Zones[index - 1].turnOnLight();
        }

        public void TurnOffLight(int index) //cam[번호]의 라이트 끄기
        {
            if (index > 0 && index <= Zones.Count)
                Zones[index - 1].turnOffLight();
        }

        public void SonicWaveOn(int index) //cam[번호]에 음파공격 활성화
        {
            if (index > 0 && index <= Zones.Count)
                Zones[index - 1].sonicWaveOn();
        }

        public void SonicWaveOff(int index) //cam[번호]에 음파공격 비활성화
        {
            if (index > 0 && index <= Zones.Count)
                Zones[index - 1].sonicWaveOff();
        }

        public Zone FindZone(int index) //scan할 때 작동
        {
            if (index > 0 && index <= Zones.Count)
                return Zones[index - 1];

            return null;
        }
    }
}