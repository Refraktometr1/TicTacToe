namespace Codebase.GameLogic
{
    public interface IPlayerTurnOrderService
    {
        void EndMove();
        bool IsCrossTurn();
    }
}