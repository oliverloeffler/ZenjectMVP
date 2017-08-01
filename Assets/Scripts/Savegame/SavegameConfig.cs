using System;

namespace Savegame
{
    public static class SavegameConfig
    {
        public const string SavePath = "savegame.dat";
        public static readonly TimeSpan SaveInterval = TimeSpan.FromSeconds(30);
    }
}