namespace Savegame
{
    public class NewSavegameCreator
    {
        public SavegameModel CreateNewSavegame()
        {
            var corridorSavegame = new CorridorSavegame {Level = 1};
            var savegameModel = new SavegameModel {CorridorSavegame = corridorSavegame};
            return savegameModel;
        }
    }
}