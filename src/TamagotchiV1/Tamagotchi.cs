using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tamagotchi_v1
{
    class Tamagotchi
    {
        public Timer IntervalTimer { get; private set; }
        public  ILifeStageData LifeStageData { get; private set; }
        private  string _name;
        private GenderType gender;
        public int happiness = 40;
        public int hungriness = 0;
        private double age = 0;
        public static int totalCount = 0;

        public LifeCycle Stage => LifeStageData.LifeStage;

        public Tamagotchi(string aName, GenderType aGender)
        {
            Name = aName;
            Gender = aGender;
            totalCount++;

            LifeStageData = new BabyData();

            IntervalTimer = new Timer(5000);
            IntervalTimer.Elapsed += OnTimedEvent;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public GenderType Gender { get; set; }

        public enum GenderType
        {
            Male,
            Female
        }
        
        public int Feed()
        {
            if (hungriness < 100)
            {
                Console.WriteLine("Omnomnomnomnom");
                return hungriness += 10;
            }
            else
            {
                Console.WriteLine("I'm full! Cannot eat anymore.");
                return hungriness;
            }
        }
        public int Pet()
        {
            happiness += 10;
            Console.WriteLine(happiness);

            if (hungriness > 30 && happiness < 100)
            {
                Console.WriteLine("Mrrrrrauu");
                return happiness += 10;
            }
            else if (happiness == 100)
            {
                Console.WriteLine("I can't get any happier! :)");
                return happiness;
            }
            else
            {
                Console.WriteLine("I'm starving, can't play now! :(");
                return happiness;
            }
        }
        public void Check()
        {
            Console.WriteLine($"Your {_name} is in {Stage} age, is {happiness.ToString()}% happy and {hungriness.ToString()}%hungry");
        }

        public bool IsHappy => !IsHungry && happiness > 20;
        
        public bool IsHungry => hungriness < 20;
        public bool IsHungry2 { get { return hungriness < 20; } }

        public void ChangeAge(LifeCycle lifeCycle)
        {
            switch (lifeCycle)
            {
                case LifeCycle.Child:
                    LifeStageData = new SeniorData();
                    break;
                case LifeCycle.Teen:
                    LifeStageData = new SeniorData();
                    break;
                case LifeCycle.Adult:
                    LifeStageData = new SeniorData();
                    break;
                case LifeCycle.Senior:
                    LifeStageData = new SeniorData();
                    break;
                case LifeCycle.Death:
                    // Kill tamagochi of old age
                    break;
            }

            Console.WriteLine($"{_name} is a{LifeStageData.LifeStage} now!");

        }
        public void ChooseAction()
        {
            string option;
            bool loop = true;

            Console.WriteLine("What would you like to do:");
            Console.WriteLine("Feed your tamagotchi - 'feed' or");
            Console.WriteLine("Feed your tamagotchi - 'pet' or");
            Console.WriteLine("or type 'LEAVE' to exit");
            option = Console.ReadLine();

            if (option.ToLower() == "feed")
            {
                Feed();
            }
            else if (option.ToLower() == "pet")
            {
                Pet();
            }
            else if (option.ToLower() == "leave")
            {
                loop = false;
            }
            else
            {
                Console.WriteLine("Choose between 'feed', 'pet' or 'LEAVE' to exit");
            }
            Check();
            if (loop)
            {
                ChooseAction();
            }
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Do interval stuff
            ChangeStates();
            if (age > LifeStageData.MaxAge)
                ChangeAge(LifeStageData.LifeStage + 1);
        }
        public void ChangeStates()
        {
            happiness -= LifeStageData.HappinessInterval;
            hungriness += LifeStageData.HungerInterval;
            age += 0.1;
        }
    }
}
