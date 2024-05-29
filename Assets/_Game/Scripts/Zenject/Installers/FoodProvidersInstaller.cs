using TriInspector;
using UnityEngine;
using Zenject;

namespace GOAP
{
    public class FoodProvidersInstaller : MonoInstaller
    {
        [SerializeField, Required] private AppleSpawner _appleSpawner;

        public override void InstallBindings()
        {
            BindhebivourusFoodProvider();

        }

        private void BindhebivourusFoodProvider()
        {
            Container.Bind<IHerbivourusFoodProvider>()
                 .To<AppleSpawner>()
                 .FromInstance(_appleSpawner)
                 .AsSingle()
                 .NonLazy();
        }
    }

}