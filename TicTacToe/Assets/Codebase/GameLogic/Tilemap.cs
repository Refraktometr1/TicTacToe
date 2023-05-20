using System.Collections.Generic;
using Codebase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Codebase.GameLogic
{
    public class Tilemap : MonoBehaviour , IProgressReader , IProgressWriter
    {
        public GameObject[] tiles;
        private List<TileModel> _tileModels = new List<TileModel>();
        private ITileController _tileController;
        private IPlayerTurnOrderService _playerTurnOrderService;


       
        public void Construct(IPlayerTurnOrderService playerTurnOrderService, ITileController tileController)
        {
            _tileController = tileController;
            _playerTurnOrderService = playerTurnOrderService;
            _playerTurnOrderService = playerTurnOrderService;
        }
        

        private void Init(List<TileModel> tileModels)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].GetComponent<TileView>().Init(tileModels[i], _tileController, _playerTurnOrderService);
            }
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