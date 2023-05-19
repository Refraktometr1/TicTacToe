using System;

namespace Codebase
{
    [Serializable]
    public class TileModel 
    {
        public int TileId;
        public bool IsFilled;

        public bool IsCross;

        public void FillModel(bool fillByCross)
        {
            IsCross = fillByCross;
            IsFilled = true;
        }
    }
}