using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Savegame.Model;
using UniRx;
using UnityEngine;
using Zenject;

namespace Savegame
{
    public class SavegameSaver : IInitializable, IDisposable
    {
        private readonly SavegameModel _savegame;
        private readonly string _savePath;
        private readonly TimeSpan _saveInterval;
        private readonly CompositeDisposable _disposer;

        public SavegameSaver(SavegameModel savegame,
            [Inject(Id = "SavePath")] string savePath,
            [Inject(Id = "SaveInterval")] TimeSpan saveInterval)
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
            _disposer = new CompositeDisposable();
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
                .Subscribe(_ => SaveToDisk())
                .AddTo(_disposer);
        }

        private void ScheduleSaveToDisk()
        {
            Observable.Timer(TimeSpan.Zero, _saveInterval)
                .Subscribe(_ => SaveToDisk())
                .AddTo(_disposer);
        }

        private void SaveToDisk()
        {
            Debug.Log("Writing savegame file to disk..");
            var bf = new BinaryFormatter();
            var stream = File.Create(_savePath);
            bf.Serialize(stream, _savegame);
            stream.Close();
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