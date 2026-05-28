using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    class Zone
    {
        private string name;
        private List<Zone> connectedZones;
        private bool hasMonster;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public List<Zone> ConnectedZones
        {
            get { return connectedZones; }
            private set { connectedZones = value; }
        }
        public bool HasMonster
        {
            get { return hasMonster; }
            private set { hasMonster = value; }
        }

        public Zone(string name) //생성 시 zone 정의
        {
            this.Name = name;
            this.ConnectedZones = new List<Zone>();
            this.HasMonster = false;
        }

        public void Connect(Zone name) //생성 시 zone 연결
        {
            ConnectedZones.Add(name);
        }

        public void MonsterIn() //zone에 몬스터 생김
        {
            HasMonster = true;
        }

        public void MonsterOut() //zone에 몬스터 사라짐
        {
            HasMonster = false;
        }
    }
}