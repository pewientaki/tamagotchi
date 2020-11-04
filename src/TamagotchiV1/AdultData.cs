using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_v1
{
    class AdultData : ILifeStageData
    {
        public LifeCycle LifeStage => LifeCycle.Adult;
        public int HappinessInterval => 40;
        public int HungerInterval => 40;
        public int MaxAge => 60;

    }
}
