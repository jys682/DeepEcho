using System;
using System.Collections.Generic;
using System.Text;

namespace DeepEchoGame
{
    public class Zone
    {
        private string name;
        private bool hasMonster;
        private bool light;
        private bool sonicWave;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public bool HasMonster
        {
            get { return hasMonster; }
            private set { hasMonster = value; }
        }
        public bool Light
        {
            get { return light; }
            private set { light = value; }
        }
        public bool SonicWave
        {
            get { return sonicWave; }
            private set { sonicWave = value; }
        }

        public Zone(string name) //생성 시 zone 정의
        {
            this.Name = name;
            this.HasMonster = false;
            this.Light = false;
            this.SonicWave = false;
        }

        public void MonsterIn() //zone에 몬스터 생김
        {
            HasMonster = true;
        }

        public void MonsterOut() //zone에 몬스터 사라짐
        {
            HasMonster = false;
        }

        public void turnOnLight() //zone에 몬스터 생김
        {
            Light = true;
        }

        public void turnOffLight() //zone에 몬스터 생김
        {
            Light = false;
        }

        public void sonicWaveOn() //zone에 몬스터 생김
        {
            SonicWave = true;
        }

        public void sonicWaveOff() //zone에 몬스터 생김
        {
            SonicWave = false;
        }
    }
}