using CrashKonijn.Goap.Interfaces;
using Zenject;

namespace GOAP
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGoapInjector();
            BindGoapSetBindingService();
        }

        private void BindGoapInjector()
        {
            Container.Bind<IGoapInjector>()
                .To<ZenjectToGoapInjectionService>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindGoapSetBindingService()
        {
            Container.Bind<GoapSetBindingService>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}