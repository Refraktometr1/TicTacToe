using Codebase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Button button;
        private TileModel _tileModel;
        private IPlayerTurnOrderService _playerTurnOrderService;
        private ITileController _tileController;

        public void Init(TileModel tileModelModel, ITileController tileController,  IPlayerTurnOrderService playerTurnOrderService)
        {
            _playerTurnOrderService = playerTurnOrderService;
            _tileController = tileController;
            _tileModel = tileModelModel;
        }

        private void Start()
        {
            button.onClick.AddListener(OnTileClick);
            UpdateView();
        }

        private void OnTileClick()
        {
            if (_tileModel.IsFilled) 
                return;
            
            _tileController.FillModel(_tileModel);
            UpdateView();
            _playerTurnOrderService.EndMove();
        }

        private void UpdateView()
        {
            if (_tileModel.IsFilled)
            {
                text.text = _tileModel.IsCross ? "X" : "O";
            }
        }
    }
}