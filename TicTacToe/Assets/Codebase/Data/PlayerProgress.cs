using System;

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
}