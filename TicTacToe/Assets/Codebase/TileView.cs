using UnityEngine;
using UnityEngine.UI;

namespace Codebase
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Button button;
        private TileModel _tileModel;
        private PlayerMoveService _playerMoveService;

        public void Construct(TileModel tileModelModel, PlayerMoveService playerMoveService)
        {
            _tileModel = tileModelModel;
            _playerMoveService = playerMoveService;
        }

        private void Awake()
        {
            button.onClick.AddListener(OnTileClick);
        }

        private void OnTileClick()
        {
            if (_tileModel.IsFilled) 
                return;
            
            _tileModel.FillModel(_playerMoveService.isCross);
            text.text = _tileModel.IsCross ? "X" : "O";
            _playerMoveService.EndMove();
        }
    }
}