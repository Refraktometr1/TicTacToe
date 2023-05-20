using System;
using Codebase.Infrastructure.Services;

namespace Codebase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public PlayerProgress()
        {
            TileData = new TileData();
            PlayerTurnOrderData = new PlayerTurnOrderData();
        }

        public TileData TileData;
        public PlayerTurnOrderData PlayerTurnOrderData;
    }

    [Serializable]
    public class PlayerTurnOrderData
    {
        public bool isCross;
        public bool isActiveFirstPlayer;
        public int moveCounter;
    }
}