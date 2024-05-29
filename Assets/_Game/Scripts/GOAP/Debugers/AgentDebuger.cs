using CrashKonijn.Goap.Interfaces;

namespace GOAP
{
    public class AgentDebuger : IAgentDebugger
    {
        public string GetInfo(IMonoAgent agent, IComponentReference references)
        {
            string result = "Agent Info is empty";

            if (agent == null)
                return result;

            if (agent.TryGetComponent(out IAgentData agentData))
                result = agentData.GetInfo();

            return result;
        }
    }
}