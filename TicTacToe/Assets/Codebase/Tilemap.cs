using System.Collections.Generic;
using UnityEngine;

namespace Codebase
{
    public class Tilemap : MonoBehaviour
    {
        public GameObject[] tiles;

        private void Awake()
        {
           
            var playerMoveService = new PlayerMoveService();
            List<TileModel> tileModels = new List<TileModel>();
            for (int i = 0; i < 9; i++)
            {
                var model = new TileModel();
                model.TileId = i;
                tileModels.Add(model);
            }
            
            Construct(tileModels, playerMoveService);

        }


        public void Construct(List<TileModel> tileModels, PlayerMoveService playerMoveService)
        {
           
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].GetComponent<TileView>().Construct(tileModels[i], playerMoveService);
            }
        }
    }
}