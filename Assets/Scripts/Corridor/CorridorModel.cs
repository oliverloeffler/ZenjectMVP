using System;
using UniRx;

namespace Corridor
{
    public class CorridorModel : IDisposable
    {
        public ReactiveProperty<int> Level { get; private set; }
        public int MaxLevel = 10;
        private readonly CompositeDisposable _disposer;

        public CorridorModel()
        {
            _disposer = new CompositeDisposable();
            Level = new ReactiveProperty<int>().AddTo(_disposer);
        }

        public void Dispose()
        {
            if (_disposer != null)
            {
                _disposer.Dispose();
            }
        }
    }
}