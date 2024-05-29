namespace GOAP
{
    public interface IFood
    {
        public FoodType FoodType { get; }
        public int Fullness { get; }
        public void BeEaten();
    }
}