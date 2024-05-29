using CrashKonijn.Goap.Interfaces;
using Zenject;

namespace GOAP
{
    public class ZenjectToGoapInjectionService : IGoapInjector
    {
        private DiContainer _container;

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _container = diContainer;
        }

        public void Inject(IActionBase action)
        {
            _container.Inject(action);
        }

        public void Inject(IGoalBase goal)
        {
            _container.Inject(goal);
        }

        public void Inject(IWorldSensor worldSensor)
        {
            _container.Inject(worldSensor);
        }

        public void Inject(ITargetSensor targetSensor)
        {
            _container.Inject(targetSensor);
        }
    }
}