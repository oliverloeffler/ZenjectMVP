﻿using System;
using JetBrains.Annotations;
using UniRx;
using Zenject;

namespace Corridor
{
    public class CorridorController : IDisposable
    {
        public ReactiveCommand UpgradeLevel { get; private set; }
        private readonly CorridorModel _corridorModel;
        private readonly CompositeDisposable _disposer = new CompositeDisposable();
        
        public CorridorController([NotNull] CorridorModel corridorModel)
        {
            if (corridorModel == null)
            {
                throw new ArgumentNullException("corridorModel");
            }
            
            _corridorModel = corridorModel;
            Initialize();
        }
        
        public void Initialize()
        {
            InitUpgradeLevel();
        }

        private void InitUpgradeLevel()
        {
            UpgradeLevel = _corridorModel.Level
                .Select(level => level < _corridorModel.MaxLevel)
                .ToReactiveCommand()
                .AddTo(_disposer);

            UpgradeLevel.Subscribe(_ => _corridorModel.Level.Value += 1).AddTo(_disposer);
        }

        public void Dispose()
        {
           if(_disposer != null)
           {
               _disposer.Dispose();
           }
        }
    }
}