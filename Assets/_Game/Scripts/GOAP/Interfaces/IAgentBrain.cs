namespace GOAP
{
    public interface IAgentBrain
    {
        public bool IsRunning { get; }
        public void Run();
        public void Stop();
    }
}