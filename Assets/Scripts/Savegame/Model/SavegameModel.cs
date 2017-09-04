using System;

namespace Savegame.Model
{
    [Serializable]
    public class SavegameModel
    {
        public MineSavegame MineSavegame { get; set; }
        public CorridorSavegame CorridorSavegame { get; set; }
    }
}