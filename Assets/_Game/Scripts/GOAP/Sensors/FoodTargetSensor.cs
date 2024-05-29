using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using Zenject;

namespace GOAP
{
    public class FoodTargetSensor : LocalTargetSensorBase
    {
        private IHerbivourusFoodProvider _herbivourusFoodProvider;

        [Inject]
        public void Construct(IHerbivourusFoodProvider herbivourusFoodProvider)
        {
            _herbivourusFoodProvider = herbivourusFoodProvider;
        }

        public override void Created()
        {

        }

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            PositionTarget result = new PositionTarget(agent.transform.position);

            if (agent.TryGetComponent(out AgentBase agentBase))
            {
                if (agentBase.AgentType == AgentType.Herbivorous)
                {
                    if (_herbivourusFoodProvider.HasFood)
                        result = new PositionTarget(_herbivourusFoodProvider.ClosestFoodPos(agent.transform.position));
                }

            }

            return result;
        }

        public override void Update()
        {

        }
    }
}