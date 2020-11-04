using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_v1
{
    public class SeniorData : ILifeStageData
    {
        public LifeCycle LifeStage => LifeCycle.Senior;
        public int HappinessInterval => 30;
        public int HungerInterval => 30;
        public int MaxAge => 100;
    }
}
