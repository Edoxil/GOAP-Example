namespace GOAP
{
    public interface IHungryAgentData
    {
        public int HungerAmount { get; }
        public int MaxHungerAmount { get; }
        public bool IsMaxHungry { get; }
        public FoodFindTrigger FoodFindTrigger { get; }

        public void IncreaseHunger(int amount);
        public void DecreaseHunger(int amount);
    }
}