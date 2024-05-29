using AppCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TriInspector;
using UnityEngine;

namespace GOAP
{
    public class AppleSpawner : MonoBehaviour, IHerbivourusFoodProvider
    {
        [SerializeField, Required] private Apple _prefab;

        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private float _spawnRadius;
        [SerializeField] private float _spawnInterval;
        [ShowInInspector, ReadOnly] private List<Apple> _spawnedApples;

        private Coroutine _spawnRoutine;
        private WaitForSeconds _waitForInterval;

        public bool HasFood => _spawnedApples != null && _spawnedApples.Count > 0;

        private void Start()
        {
            _spawnedApples = new List<Apple>();
            _waitForInterval = new WaitForSeconds(_spawnInterval);

            _spawnRoutine = StartCoroutine(SpawnRoutine());
        }

        private void OnDestroy()
        {
            if (_spawnRoutine != null)
                StopCoroutine(_spawnRoutine);
        }

        private IEnumerator SpawnRoutine()
        {
            Spawn();
            yield return _waitForInterval;
            _spawnRoutine = StartCoroutine(SpawnRoutine());
        }

        private void Spawn()
        {
            Apple apple = Instantiate(_prefab, transform);
            apple.HasBeenEaten += OnAppleHasBeanEaten;

            Vector2 spawnPosOffset = Random.insideUnitCircle * Random.Range(0f, _spawnRadius);
            Transform randomPoint = _spawnPoints.GetRandom();
            apple.transform.position = randomPoint.position + new Vector3(spawnPosOffset.x, 0f, spawnPosOffset.y);

            _spawnedApples.Add(apple);
        }

        private void OnAppleHasBeanEaten(Apple apple)
        {
            if(_spawnedApples.Remove(apple))
            {
                apple.HasBeenEaten -= OnAppleHasBeanEaten;
                Destroy(apple.gameObject);
            }
        }

        public Vector3 ClosestFoodPos(Vector3 fromPos)
        {
            return _spawnedApples.OrderBy(apple => Vector3.Distance(fromPos, apple.transform.position)).First().transform.position;
        }


        private void OnDrawGizmos()
        {
            if (_spawnPoints == null || _spawnPoints.Count <= 0)
                return;

            Gizmos.color = Color.red;
            foreach (var point in _spawnPoints)
            {
                Gizmos.DrawWireSphere(point.position, _spawnRadius);
            }
        }

    }
}