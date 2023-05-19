using UnityEngine;

namespace Codebase
{
    public class TileModel 
    {
        public int TileId;
        public bool IsFilled { get; private set; }

        public bool IsCross { get; private set; }

        public void FillModel(bool fillByCross)
        {
            IsCross = fillByCross;
            IsFilled = true;
        }
    }
}