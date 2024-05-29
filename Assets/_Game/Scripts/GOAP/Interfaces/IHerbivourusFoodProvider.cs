using UnityEngine;

namespace GOAP
{
    public interface IHerbivourusFoodProvider
    {
        public Vector3 ClosestFoodPos(Vector3 fromPos);
        public bool HasFood { get;  }
    }
}