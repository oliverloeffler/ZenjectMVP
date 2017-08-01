using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Savegame.Model;
using Zenject;

namespace Savegame
{
    public class SavegameLoader : ISavegameLoader
    {
        private readonly string _savePath;
        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        public SavegameLoader([Inject(Id = "SavePath")] string savePath)
        {
            _savePath = savePath;
        }

        public bool IsSavegameFileExistent()
        {
            return File.Exists(_savePath);
        }

        public SavegameModel LoadSavegame()
        {
            if (!File.Exists(_savePath))
            {
                throw new IOException("Couldn't access savegame path: " + _savePath);
            }

            var file = File.Open(_savePath, FileMode.Open);

            var savegame = (SavegameModel) _binaryFormatter.Deserialize(file);
            file.Close();

            return savegame;
        }
    }
}