using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UniRx;
using UnityEngine;
using Zenject;

namespace Savegame
{
    public class SavegameSaver : IInitializable
    {
        private readonly SavegameModel _savegame;
        private readonly string _savePath;
        private readonly TimeSpan _saveInterval;

        public SavegameSaver(SavegameModel savegame, string savePath, TimeSpan saveInterval)
        {
            if (savegame == null)
            {
                throw new ArgumentNullException("savegame");
            }
            if (savePath == null)
            {
                throw new ArgumentNullException("savePath");
            }

            _savegame = savegame;
            _savePath = savePath;
            _saveInterval = saveInterval;
        }

        public void Initialize()
        {
            ScheduleSaveToDisk();
            SaveToDiskOnSessionEnd();
        }

        private void SaveToDiskOnSessionEnd()
        {
            Observable.EveryApplicationPause()
                .Where(pause => pause)
                .AsUnitObservable()
                .Merge(Observable.OnceApplicationQuit())
                .Subscribe(_ => SaveToDisk());
        }

        private void ScheduleSaveToDisk()
        {
            Observable.Timer(TimeSpan.Zero, _saveInterval)
                .Subscribe(_ => SaveToDisk());
        }

        private void SaveToDisk()
        {
            Debug.Log("Writing savegame file to disk..");
            var bf = new BinaryFormatter();
            var stream = File.Create(_savePath);
            bf.Serialize(stream, _savegame);
            stream.Close();
        }
    }
}