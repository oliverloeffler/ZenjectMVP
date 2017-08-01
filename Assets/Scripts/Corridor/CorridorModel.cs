using System;
using JetBrains.Annotations;
using Savegame;
using UniRx;

namespace Corridor
{
    public class CorridorModel : IDisposable
    {
        public ReactiveProperty<int> Level { get; private set; }
        private readonly ICorridorData _corridorData;
        private readonly CorridorSavegame _savegameModel;

        public int MaxLevel
        {
            get { return _corridorData.MaxLevel; }
        }

        private readonly CompositeDisposable _disposer;

        public CorridorModel([NotNull] ICorridorData corridorData, [NotNull] CorridorSavegame savegameModel)
        {
            if (corridorData == null)
            {
                throw new ArgumentNullException("corridorData");
            }
            if (savegameModel == null)
            {
                throw new ArgumentNullException("savegameModel");
            }
            
            _disposer = new CompositeDisposable();
            _savegameModel = savegameModel;
            _corridorData = corridorData;
            Level = new ReactiveProperty<int>(_savegameModel.Level).AddTo(_disposer);
            Level.Subscribe(level => _savegameModel.Level = level);
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