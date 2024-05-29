using System;
using UnityEngine;

namespace GOAP
{
    [RequireComponent(typeof(Collider))]
    public class FoodFindTrigger : MonoBehaviour
    {
        [SerializeField] private FoodType _targetFood;

        public event Action<IFood> FoodFind;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IFood food))
            {
                if (food.FoodType == _targetFood)
                    FoodFind?.Invoke(food);
            }
        }
    }
}