using CrashKonijn.Goap.Behaviours;
using UnityEngine;

namespace GOAP
{
    [RequireComponent(typeof(AgentBehaviour))]
    public class HerbivorousAgentBrain : MonoBehaviour, IAgentBrain
    {
        private AgentBehaviour _agent;
        public bool IsRunning { get; protected set; }

        private HerbivorousAgentData _data;

        private void Awake()
        {
            _agent = GetComponent<AgentBehaviour>();
            _data = GetComponent<HerbivorousAgentData>();
        }

        private void Update()
        {
            if (IsRunning == false)
                return;

            if (_data.HungerAmount > 50)
            {
                _agent.SetGoal<FixHungerGoal>(false);
            }
            else
            {
                _agent.SetGoal<WanderGoal>(false);
            }
        }

        public void Run()
        {
            _agent.SetGoal<WanderGoal>(false);
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}