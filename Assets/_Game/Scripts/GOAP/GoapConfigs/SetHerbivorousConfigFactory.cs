using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Resolver;

namespace GOAP
{
    public class SetHerbivorousConfigFactory : GoapSetFactoryBase
    {
        public override IGoapSetConfig Create()
        {
            GoapSetBuilder builder = new GoapSetBuilder(GoapConfigID.HerbivorousID);

            SetupWanderingBehaviour(builder);

            SetupFixHungerBehaviour(builder);

            builder.SetAgentDebugger<AgentDebuger>();

            return builder.Build();
        }

        private void SetupFixHungerBehaviour(GoapSetBuilder builder)
        {
            builder.AddGoal<FixHungerGoal>()
                .AddCondition<IsHungry>(Comparison.SmallerThan, 1);

            builder.AddAction<FixHungerAction>()
                .SetTarget<FoodTarget>()
                .AddEffect<IsHungry>(EffectType.Decrease)
                .SetBaseCost(1)
                .SetInRange(0.1f);

            builder.AddTargetSensor<FoodTargetSensor>()
                .SetTarget<FoodTarget>();
        }

        private void SetupWanderingBehaviour(GoapSetBuilder builder)
        {
            builder.AddGoal<WanderGoal>()
                .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, 1);

            builder.AddAction<WanderAction>()
                .SetTarget<WanderTarget>()
                .AddEffect<IsWandering>(EffectType.Increase)
                .SetBaseCost(1)
                .SetInRange(0.3f);

            builder.AddTargetSensor<WanderTargetSensor>()
                .SetTarget<WanderTarget>();
        }
    }
}