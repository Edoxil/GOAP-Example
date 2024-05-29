using AppCore;
using CrashKonijn.Goap.Interfaces;

namespace GOAP
{
    public class WanderActionData : IActionData
    {
        public ITarget Target { get; set; }
        public float Timer { get; set; }
        public FloatRange DefaultWanderingDurationRange { get; } = new FloatRange(1f, 1f);
    }
}