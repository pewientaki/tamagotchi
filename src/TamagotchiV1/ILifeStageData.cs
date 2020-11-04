namespace Tamagotchi_v1
{
    internal interface ILifeStageData
    {
        LifeCycle LifeStage { get; }
        int HappinessInterval { get; }
        int HungerInterval { get; }
          int MaxAge { get; }
    }
}