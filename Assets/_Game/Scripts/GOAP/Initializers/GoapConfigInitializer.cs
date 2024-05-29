using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using Zenject;

namespace GOAP
{
    public class GoapConfigInitializer : GoapConfigInitializerBase
    {
        private IGoapInjector _injector;

        [Inject]
        public void Construct(IGoapInjector goapInjector)
        {
            _injector = goapInjector;
        }

        public override void InitConfig(GoapConfig config)
        {
            config.GoapInjector = _injector;
        }
    }
}