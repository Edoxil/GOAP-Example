using System.Collections.Generic;
using TriInspector;
using UnityEngine;

namespace GOAP
{
    public class AgentSpawner : MonoBehaviour
    {
        [SerializeField, Required] private AgentFactory _factory;

        [ShowInInspector, ReadOnly] private List<AgentBase> _allAgents = new List<AgentBase>();
        [SerializeField] private int _agentsToSpawn = 5;


        private void Start()
        {
            for (int i = 0; i < _agentsToSpawn; i++)
            {
                SpawnHerbivorous();
            }
        }

        [Button]
        private void SpawnHerbivorous()
        {
            AgentBase agent = _factory.Create(AgentType.Herbivorous, transform);
            agent.AgentDied += OnAgentDeath;
            _allAgents.Add(agent);
        }


        private void OnAgentDeath(AgentBase agentBase)
        {
            agentBase.AgentDied -= OnAgentDeath;

            if (_allAgents.Remove(agentBase))
            {
                Destroy(agentBase.gameObject);
            }

        }
    }
}