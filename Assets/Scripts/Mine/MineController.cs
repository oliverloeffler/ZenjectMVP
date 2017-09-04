using System;
using Corridor;
using JetBrains.Annotations;
using Savegame.Model;
using UnityEngine;

namespace Mine
{
    public class MineController
    {
        private readonly MineSavegame _mineSavegame;
        private readonly CorridorPresenter.Factory _corridorFactory;

        public MineController([NotNull] MineSavegame mineSavegame, [NotNull] CorridorPresenter.Factory corridorFactory)
        {
            if (mineSavegame == null)
            {
                throw new ArgumentNullException("mineSavegame");
            }
            if (corridorFactory == null)
            {
                throw new ArgumentNullException("corridorFactory");
            }
            
            _mineSavegame = mineSavegame;
            _corridorFactory = corridorFactory;
            Debug.Log("Created MineController");
            SpawnAllCorridors();
        }


        private void SpawnAllCorridors()
        {
            for (int i = 0; i < _mineSavegame.NumberCorridor; i++)
            {
                _corridorFactory.Create();
            }
        }
    }
}