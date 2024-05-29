using System;
using System.Collections;
using UnityEngine;

namespace GOAP
{
    [RequireComponent(typeof(IHungryAgentData))]
    public class HungerBehaviour : MonoBehaviour
    {
        [SerializeField] private float _hungerTickTime = 1f;
        [SerializeField] private int _hungerPerTickAmount = 3;

        private IHungryAgentData _data;

        private Coroutine _routine;
        private WaitForSeconds _waitForHungerTick;

        public event Action MaxHungerReached;

        private void Awake()
        {
            _data = GetComponent<IHungryAgentData>();
            _waitForHungerTick = new WaitForSeconds(_hungerTickTime);
        }

        private void OnDestroy()
        {
            Stop();
        }

        public void Run()
        {
            _routine = StartCoroutine(HungerRoutine());
        }

        public void Stop()
        {
            if (_routine != null)
                StopCoroutine(_routine);
        }

        private IEnumerator HungerRoutine()
        {
            yield return _waitForHungerTick;
            _data.IncreaseHunger(_hungerPerTickAmount);

            if (_data.IsMaxHungry)
            {
                MaxHungerReached?.Invoke();
                Stop();
            }
            else
            {
                Run();
            }
        }

    }
}