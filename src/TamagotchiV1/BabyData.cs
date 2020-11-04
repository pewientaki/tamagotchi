using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_v1
{
    public class BabyData : ILifeStageData
    {
        public LifeCycle LifeStage => LifeCycle.Baby;
        public int HappinessInterval => 10;
        public int HungerInterval => 10;

        public int MaxAge => 20;

    }
}
