using AppCore;
using TriInspector;
using UnityEngine;

namespace GOAP
{
    public class HerbivorousAgentData : MonoBehaviour, IAgentData, IWanderingAgentData, IHungryAgentData
    {
        [field: SerializeField] public FloatRange WanderingDurationRange { get; private set; }

        [ShowInInspector, ReadOnly] public int HungerAmount { get; private set; }
        [field: SerializeField] public int MaxHungerAmount { get; private set; } = 100;
        [ShowInInspector, ReadOnly] public bool IsMaxHungry => HungerAmount == MaxHungerAmount;
        [field: SerializeField] public FoodFindTrigger FoodFindTrigger { get; private set; }

        public void DecreaseHunger(int amount)
        {
            HungerAmount -= amount;

            if (HungerAmount < 0)
                HungerAmount = 0;
        }

        public void IncreaseHunger(int amount)
        {
            HungerAmount += amount;

            if (HungerAmount > MaxHungerAmount)
                HungerAmount = MaxHungerAmount;
        }

        public string GetInfo()
        {
            return $"{nameof(AgentType)} : {AgentType.Herbivorous}" +
                $"\n{nameof(WanderingDurationRange)} : {WanderingDurationRange}" +
                $"\n{nameof(HungerAmount)} : {HungerAmount}";
        }

    }
}