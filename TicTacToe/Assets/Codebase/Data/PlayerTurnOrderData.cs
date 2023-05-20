using System;

namespace Codebase.Data
{
    [Serializable]
    public class PlayerTurnOrderData
    {
        public bool isCross;
        public bool isActiveFirstPlayer;
        public int moveCounter;
    }
}