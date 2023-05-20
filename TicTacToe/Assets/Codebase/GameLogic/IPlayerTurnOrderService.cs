using System;

namespace Codebase.GameLogic
{
    public interface IPlayerTurnOrderService
    {
        void EndMove();
        bool IsCrossTurn();
        event Action MoveEnded;
    }
}