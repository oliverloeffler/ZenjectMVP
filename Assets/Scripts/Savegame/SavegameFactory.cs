using System;
using JetBrains.Annotations;
using Savegame.Model;
using UnityEngine;
using Zenject;

namespace Savegame
{
    public class SavegameFactory : IFactory<SavegameModel>
    {
        private readonly ISavegameLoader _savegameLoader;
        private readonly NewSavegameCreator _newSavegameCreator;


        public SavegameFactory(ISavegameLoader savegameLoader, [NotNull] NewSavegameCreator newSavegameCreator)
        {
            if (savegameLoader == null)
            {
                throw new ArgumentNullException("savegameLoader");
            }
            if (newSavegameCreator == null)
            {
                throw new ArgumentNullException("newSavegameCreator");
            }
            _savegameLoader = savegameLoader;
            _newSavegameCreator = newSavegameCreator;
        }

        public SavegameModel Create()
        {
            SavegameModel savegame;
            if (!_savegameLoader.IsSavegameFileExistent())
            {
                savegame = _newSavegameCreator.CreateNewSavegame();
                Debug.Log("New savegame created");
            }
            else
            {
                savegame = _savegameLoader.LoadSavegame();
                Debug.Log("Loaded savegame");
            }

            return savegame;

        }
    }
}