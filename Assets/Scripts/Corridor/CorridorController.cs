using System;
using JetBrains.Annotations;
using UniRx;
using Zenject;

namespace Corridor
{
    public class CorridorController : IInitializable
    {
        public ReactiveCommand UpgradeLevel { get; private set; }
        private readonly CorridorModel _corridorModel;
        
        
        public CorridorController([NotNull] CorridorModel corridorModel)
        {
            if (corridorModel == null) 
                throw new ArgumentNullException("corridorModel");
            _corridorModel = corridorModel;
        }
        
        public void Initialize()
        {
            InitUpgradeLevel();
        }

        private void InitUpgradeLevel()
        {
            UpgradeLevel = _corridorModel.Level
                .Select(level => level < _corridorModel.MaxLevel)
                .ToReactiveCommand();

            UpgradeLevel.Subscribe(_ => _corridorModel.Level.Value += 1);
        }

    }
}