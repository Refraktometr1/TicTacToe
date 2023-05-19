using System.Collections.Generic;
using Codebase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Codebase
{
    public class Tilemap : MonoBehaviour , IProgressReader , IProgressWriter
    {
        public GameObject[] tiles;
        private List<TileModel> _tileModels = new List<TileModel>();

        public void Construct(List<TileModel> tileModels, PlayerMoveService playerMoveService)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].GetComponent<TileView>().Construct(tileModels[i], playerMoveService);
            }
        }

        public void LoadProgress(PlayerProgress progress)
        {
            var playerMoveService = new PlayerMoveService();
            _tileModels = progress.TileData.tilesData;
          
            
            Construct(_tileModels, playerMoveService);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.TileData.tilesData = _tileModels;
        }
    }
}