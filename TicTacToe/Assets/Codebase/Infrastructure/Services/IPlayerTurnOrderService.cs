namespace Codebase.Infrastructure.Services
{
    public interface IPlayerTurnOrderService
    {
        void EndMove();
        bool IsCrossTurn();
    }
}