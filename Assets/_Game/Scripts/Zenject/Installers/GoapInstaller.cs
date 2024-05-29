using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using TriInspector;
using UnityEngine;
using Zenject;

namespace GOAP
{
    public class GoapInstaller : MonoInstaller
    {
        [SerializeField, Required] private GoapRunnerBehaviour _goapRunner;

        public override void InstallBindings()
        {
            Container.Bind<IGoapRunner>()
                .To<GoapRunnerBehaviour>()
                .FromInstance(_goapRunner)
                .AsSingle()
                .NonLazy();
        }
    }

}