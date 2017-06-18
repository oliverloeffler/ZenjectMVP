using System;
using Installer;
using UnityEngine;

namespace Corridor
{
    [Serializable]
    public class CorridorViewData : ICorridorViewData
    {
        public Sprite _Level1To5Sprite;
        public Sprite _Level6To10Sprite;

        public Sprite Level1To5Sprite
        {
            get { return _Level1To5Sprite; }
        }

        public Sprite Level6To10Sprite
        {
            get { return _Level6To10Sprite; }
        }
    }
}