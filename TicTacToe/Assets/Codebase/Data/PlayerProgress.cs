using System;
using System.Collections.Generic;

namespace Codebase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public PlayerProgress()
        {
            TileData = new TileData();
        }
        public TileData TileData;
    }
    
    
    [Serializable]
    public class TileData
    {
        public List<TileModel> tilesData = new List<TileModel>();
    }
}