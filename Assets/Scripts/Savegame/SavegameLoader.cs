using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Zenject;

namespace Savegame
{
    public interface ISavegameLoader
    {
        SavegameModel LoadSavegame();
        bool IsSavegameFileExistent();
    }

    public class SavegameLoader : ISavegameLoader
    {
        private readonly string _savePath;

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

            var bf = new BinaryFormatter();
            var file = File.Open(_savePath, FileMode.Open);

            var savegame = (SavegameModel) bf.Deserialize(file);
            file.Close();

            return savegame;
        }
    }
}