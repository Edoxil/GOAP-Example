using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using System;
using Zenject;

namespace GOAP
{
    public class GoapSetBindingService
    {
        private IGoapRunner _goapRunner;

        [Inject]
        public void Construct(IGoapRunner goapRunner)
        {
            _goapRunner = goapRunner;
        }

        public void Bind(AgentBase agent)
        {
            BindTo(agent.AgentBehaviour, agent.AgentType);
        }

        private void BindTo(AgentBehaviour agent, AgentType agentType)
        {
            switch (agentType)
            {
                case AgentType.Herbivorous:
                    agent.GoapSet = _goapRunner.GetGoapSet(GoapConfigID.HerbivorousID);
                    break;
                case AgentType.Predatory:
                    agent.GoapSet = _goapRunner.GetGoapSet(GoapConfigID.PredatoryID);
                    break;
                default:
                    throw new ArgumentException($"Invalid {nameof(AgentType)} : {agentType}.");
            }
        }
    }
}