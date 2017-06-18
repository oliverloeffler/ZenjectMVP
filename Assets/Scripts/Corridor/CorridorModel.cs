using UniRx;

namespace Corridor
{
    public class CorridorModel
    {
        public ReactiveProperty<int> Level { get; private set; }
        public int MaxLevel = 10;

        public CorridorModel()
        {
            Level = new ReactiveProperty<int>();
        }
        
    }
}