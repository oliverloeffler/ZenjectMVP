using Savegame.Model;

namespace Savegame
{
    public interface ISavegameLoader
    {
        SavegameModel LoadSavegame();
        bool IsSavegameFileExistent();
    }
}