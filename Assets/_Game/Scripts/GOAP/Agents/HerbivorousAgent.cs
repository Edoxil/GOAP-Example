using TriInspector;
using UnityEngine;

namespace GOAP
{
    public class HerbivorousAgent : AgentBase
    {
        [SerializeField,Required] private HungerBehaviour _hungerBehaviour;

        private void Start()
        {
            RunBehaviours();
        }

        protected override void RunBehaviours()
        {
            _hungerBehaviour.Run();
            _hungerBehaviour.MaxHungerReached += OnFullHungry;
            _brain.Run();
        }

        protected override void StopBehaviours()
        {
            _hungerBehaviour.MaxHungerReached -= OnFullHungry;
            _hungerBehaviour.Stop();
            _brain.Stop();
        }

        private void OnFullHungry()
        {
            StopBehaviours();
            NotifyAgentDeath();
        }
    }
}