using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    class Map
    {
        private List<Zone> Zones = new List<Zone>(); //모든 구역을 리스트에 저장

        public Map() //게임 시작 시 맵 생성
        {
            Zone cam1 = new Zone("cam1"); //앞쪽                ㅡ 1 ㅡㄱ
            Zone cam2 = new Zone("cam2"); //오른쪽            |    |    |
            Zone cam3 = new Zone("cam3"); //왼쪽              3 ㅡ 5 ㅡ 2  이런 식으로 연결?
            Zone cam4 = new Zone("cam4"); //뒷쪽              |    |    |
            Zone cam5 = new Zone("cam5"); //위쪽              ㄴㅡ 4 ㅡ 

            cam1.Connect(cam2);
            cam1.Connect(cam3);
            cam1.Connect(cam5);

            cam2.Connect(cam1);
            cam2.Connect(cam4);
            cam2.Connect(cam5);

            cam3.Connect(cam1);
            cam3.Connect(cam4);
            cam3.Connect(cam5);

            cam4.Connect(cam2);
            cam4.Connect(cam3);
            cam4.Connect(cam5);

            cam5.Connect(cam1);
            cam5.Connect(cam2);
            cam5.Connect(cam3);
            cam5.Connect(cam4);

            Zones.Add(cam1);
            Zones.Add(cam2);
            Zones.Add(cam3);
            Zones.Add(cam4);
            Zones.Add(cam5);
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

        public Zone FindZone(int index) //scan할 때 작동
        {
            if (index > 0 && index <= Zones.Count)
                return Zones[index - 1];

            return null;
        }
    }
}