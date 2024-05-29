using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;

namespace GOAP
{
    public class WanderAction : ActionBase<WanderActionData>
    {
        public override void Created()
        {

        }

        public override void Start(IMonoAgent agent, WanderActionData data)
        {
            if (agent.TryGetComponent(out IWanderingAgentData agentData))
                data.Timer = agentData.WanderingDurationRange.GetRandom();
            else
                data.Timer = data.DefaultWanderingDurationRange.GetRandom();
        }

        public override ActionRunState Perform(IMonoAgent agent, WanderActionData data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;

            if (data.Timer > 0)
                return ActionRunState.Continue;

            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, WanderActionData data)
        {

        }

    }
}