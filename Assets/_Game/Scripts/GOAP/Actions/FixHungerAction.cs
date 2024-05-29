using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;

namespace GOAP
{
    public class FixHungerAction : ActionBase<FixHungerActionData>
    {
        private IHungryAgentData _agentData;

        public override void Created()
        {

        }

        public override void End(IMonoAgent agent, FixHungerActionData data)
        {
            _agentData.FoodFindTrigger.FoodFind -= OnFoodFind;
        }

        public override ActionRunState Perform(IMonoAgent agent, FixHungerActionData data, ActionContext context)
        {
            return ActionRunState.Stop;
        }

        public override void Start(IMonoAgent agent, FixHungerActionData data)
        {
            _agentData = agent.GetComponent<IHungryAgentData>();
            _agentData.FoodFindTrigger.FoodFind += OnFoodFind;
        }

        private void OnFoodFind(IFood food)
        {
            _agentData.DecreaseHunger(food.Fullness);
            food.BeEaten();
        }
    }
}