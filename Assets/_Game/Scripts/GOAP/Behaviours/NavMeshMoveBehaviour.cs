using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using TriInspector;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP
{
    public class NavMeshMoveBehaviour : MonoBehaviour
    {
        [SerializeField, Required] private NavMeshAgent _agent;
        [SerializeField, Required] private AgentBehaviour _goapAgent;

        private ITarget _currentTarget;

        private void OnEnable()
        {
            _goapAgent.Events.OnTargetOutOfRange += OnTargetOutOfRange;
            _goapAgent.Events.OnTargetInRange += OnTargetInRange;
            _goapAgent.Events.OnTargetChanged += OnTargetChanged;
        }

        private void OnDisable()
        {
            _goapAgent.Events.OnTargetOutOfRange -= OnTargetOutOfRange;
            _goapAgent.Events.OnTargetInRange -= OnTargetInRange;
            _goapAgent.Events.OnTargetChanged -= OnTargetChanged;
        }

        private void OnTargetChanged(ITarget target, bool inRange)
        {
            _currentTarget = target;

            if (inRange == false)
                MoveToTargetPosition();
        }

        private void OnTargetInRange(ITarget target)
        {

        }

        private void OnTargetOutOfRange(ITarget target)
        {
            MoveToTargetPosition();
        }

        private void MoveToTargetPosition()
        {
            if (_currentTarget == null)
                return;

            _agent.SetDestination(_currentTarget.Position);
        }

        private void OnValidate()
        {
            if (TryGetComponent(out NavMeshAgent navMeshAgent))
                _agent = navMeshAgent;

            if (TryGetComponent(out AgentBehaviour agentBehaviour))
                _goapAgent = agentBehaviour;
        }
    }
}