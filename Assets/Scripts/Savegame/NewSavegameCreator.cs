using Savegame.Model;

namespace Savegame
{
    public class NewSavegameCreator
    {
        public SavegameModel CreateNewSavegame()
        {
            var mineSavegame = new MineSavegame {NumberCorridor = 3};
            var corridorSavegame = new CorridorSavegame {Level = 1};
            var savegameModel = new SavegameModel {CorridorSavegame = corridorSavegame, MineSavegame = mineSavegame};
            return savegameModel;
        }
    }
}