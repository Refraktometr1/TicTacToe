using Codebase.Infrastructure.Services;

namespace Codebase
{
    public class TileController : ITileController
    {
        private IPlayerTurnOrderService _playerTurnOrderService;
        
        public TileController(IPlayerTurnOrderService playerTurnOrderService)
        {
            _playerTurnOrderService = playerTurnOrderService;
        }
        
        public void FillModel(TileModel tileModel)
        {
            tileModel.IsCross = _playerTurnOrderService.IsCrossTurn();
            tileModel.IsFilled = true;
        }
    }

    public interface ITileController
    {
        public void FillModel(TileModel tileModel);
    }
}