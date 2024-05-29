using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace GOAP
{
    public class AgentFactory : MonoBehaviour
    {
        [SerializeField] private List<AgentBase> _prefabs;

        private GoapSetBindingService _goapSetBindingService;

        [Inject]
        public void Construct(GoapSetBindingService goapSetBindingService)
        {
            _goapSetBindingService = goapSetBindingService;
        }

        public AgentBase Create(AgentType agentType, Transform parent = null)
        {
            AgentBase agentPrefab = _prefabs.FirstOrDefault(prefab => prefab.AgentType == agentType);

            if (agentPrefab != null)
            {
                AgentBase agent = Instantiate(agentPrefab, parent ? parent : transform);
                _goapSetBindingService.Bind(agent);
                return agent;
            }
            else
            {
                Debug.LogError($"No prefab for {agentType}");
                return null;
            }
        }

    }
}