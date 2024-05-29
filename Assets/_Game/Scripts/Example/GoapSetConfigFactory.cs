using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Resolver;

namespace GOAP.Example
{
    public class GoapSetConfigFactory : GoapSetFactoryBase
    {
        public override IGoapSetConfig Create()
        {
            GoapSetBuilder builder = new GoapSetBuilder("GettingStartedSet");

            builder.AddGoal<WanderGoal>()
                .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, 1);

            builder.AddAction<WanderAction>()
                .SetTarget<WanderTarget>()
                .AddEffect<IsWandering>(EffectType.Increase)
                .SetBaseCost(1)
                .SetInRange(0.3f);

            builder.AddTargetSensor<WanderTargetSensor>()
            .SetTarget<WanderTarget>();

            return builder.Build();
        }
    }
}