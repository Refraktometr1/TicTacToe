using System.Collections.Generic;
using Codebase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Codebase.GameLogic
{
    public class Tilemap : MonoBehaviour , IProgressReader , IProgressWriter
    {
        public GameObject[] tiles;
        public List<TileModel> _tileModels = new List<TileModel>();
        
        private ITileController _tileController;
        private IPlayerTurnOrderService _playerTurnOrderService;
        private EndGameText _endGameText;


        public void Construct(IPlayerTurnOrderService playerTurnOrderService, ITileController tileController,
            EndGameText endGameText)
        {
            _endGameText = endGameText;
            _tileController = tileController;
            _playerTurnOrderService = playerTurnOrderService;

            _playerTurnOrderService.MoveEnded += CheckWin;
        }

        private void Init(List<TileModel> tileModels)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].GetComponent<TileView>().Init(tileModels[i], _tileController, _playerTurnOrderService);
            }
        }

        private void CheckWin()
        {
            bool rowWin = CheckWinByTileIndex(0, 1, 2) || CheckWinByTileIndex(3, 4, 5) || CheckWinByTileIndex(6, 7, 8);
            bool columnsWin = CheckWinByTileIndex(0, 3, 6) || CheckWinByTileIndex(1, 4, 7) || CheckWinByTileIndex(2, 5, 8);
            bool diagonalWin = CheckWinByTileIndex(0, 4, 8) || CheckWinByTileIndex(2, 4, 6);
            
            if (rowWin || columnsWin || diagonalWin)
            {
                if ( !_playerTurnOrderService.IsCrossTurn())
                {
                    CrossWin();
                }
                else
                {
                    CircleWin();
                }
            }
        }

        private void CircleWin()
        {
            _endGameText.Text.text = "Circle Win";
            foreach (var tileModel in _tileModels)
            {
                tileModel.IsFilled = true;
            }
        }

        private void CrossWin()
        {
            _endGameText.Text.text = "Cross Win";
            foreach (var tileModel in _tileModels)
            {
                tileModel.IsFilled = true;
            }
        }

        private bool CheckWinByTileIndex(int i, int i1, int i2)
        {
           return  _tileModels[i].IsFilled && _tileModels[i1].IsFilled && _tileModels[i2].IsFilled &&
                (_tileModels[i].IsCross == _tileModels[i1].IsCross) && (_tileModels[i1].IsCross == _tileModels[i2].IsCross);
        }


        public void LoadProgress(PlayerProgress progress)
        {
            _tileModels = progress.TileData.tilesData;
            Init(_tileModels);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.TileData.tilesData = _tileModels;
        }
    }
}