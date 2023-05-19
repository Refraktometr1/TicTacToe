using UnityEngine;
using UnityEngine.UI;

namespace Codebase
{
    public class TileView : MonoBehaviour
    {
        public int Tileid;
        [SerializeField] private Text text;
        [SerializeField] private Button button;
        private Tile _tileModel;
        private ActivePlayer _activePlayer;

        public void Construct(Tile tileModel, ActivePlayer activePlayer)
        {
            _tileModel = tileModel;
            _activePlayer = activePlayer;
        }

        private void Awake()
        {
            button.onClick.AddListener(OnTileClick);
        }

        private void OnTileClick()
        {
            _tileModel.isCross = _activePlayer.isCross;
            _tileModel.isActive = false;
            _activePlayer.EndMove();
        }
    }
}