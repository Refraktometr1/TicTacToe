using Codebase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;

namespace Codebase.Infrastructure.Services
{
    public class PlayerTurnOrderService : IPlayerTurnOrderService , IProgressReader, IProgressWriter
    {
        private bool _isCross;
        private bool _isActiveFirstPlayer;
        private int _moveCounter;

        public PlayerTurnOrderService()
        {
            _isCross = true;
            _isActiveFirstPlayer = true;
            _moveCounter = 0;
        }

        public void EndMove()
        {
            _isCross = !_isCross;
            _isActiveFirstPlayer = !_isActiveFirstPlayer;
            _moveCounter++;
            if (_moveCounter == 9)
            {
                EndGame();
            }
        }

        public bool IsCrossTurn()
        {
            return _isCross;
        }

        private void EndGame()
        {
            throw new System.NotImplementedException();
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _isCross = progress.PlayerTurnOrderData.isCross;
            _isActiveFirstPlayer = progress.PlayerTurnOrderData.isActiveFirstPlayer;
            _moveCounter = progress.PlayerTurnOrderData.moveCounter;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.PlayerTurnOrderData.isCross = _isCross;
            progress.PlayerTurnOrderData.isActiveFirstPlayer = _isActiveFirstPlayer;
            progress.PlayerTurnOrderData.moveCounter = _moveCounter;
        }
    }
}