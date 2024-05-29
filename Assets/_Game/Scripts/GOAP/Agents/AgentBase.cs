using CrashKonijn.Goap.Behaviours;
using System;
using UnityEngine;

namespace GOAP
{
    [RequireComponent(typeof(IAgentBrain))]
    public abstract class AgentBase : MonoBehaviour
    {
        [field: SerializeField] public AgentType AgentType { get; private set; }
        [field: SerializeField] public AgentBehaviour AgentBehaviour { get; private set; }

        protected IAgentBrain _brain;

        public event Action<AgentBase> AgentDied;

        private void Awake()
        {
            _brain = GetComponent<IAgentBrain>();
        }

        protected abstract void RunBehaviours();
        protected abstract void StopBehaviours();

        protected void NotifyAgentDeath()
        {
            AgentDied?.Invoke(this);
        }
    }
}