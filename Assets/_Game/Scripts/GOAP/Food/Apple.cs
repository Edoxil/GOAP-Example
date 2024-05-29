using System;
using UnityEngine;

namespace GOAP
{
    public class Apple : MonoBehaviour, IFood
    {
        [field: SerializeField] public FoodType FoodType { get; private set; } = FoodType.ForHerbivorous;

        [field: SerializeField] public int Fullness { get; private set; }

        public event Action<Apple> HasBeenEaten;

        public void BeEaten()
        {
            HasBeenEaten?.Invoke(this);
        }
    }
}