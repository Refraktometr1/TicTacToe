using System.Collections.Generic;
using Codebase.GameLogic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        public List<IProgressReader> ProgressReaders { get; } = new List<IProgressReader>();

        public List<IProgressWriter> ProgressWriters { get; } = new List<IProgressWriter>();

        private IPersistentProgressService _progressService;

        [Inject]
        public GameFactory(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }

      

        public Button CreateButton(Transform parent, string path)
        {
            var gameObject = Object.Instantiate(Resources.Load<GameObject>(path), parent);
            return gameObject.GetComponent<Button>(); 
        }
        
        public GameObject CreateMainCanvas() => Object.Instantiate(Resources.Load<GameObject>("MainCanvas"));

        public Tilemap CreateTileMap(Transform parent)
        {
            var gameObject = Object.Instantiate(Resources.Load<GameObject>("Tilemap"), parent);
            var tilemap = gameObject.GetComponent<Tilemap>();
            
            PlayerTurnOrderService playerTurnOrderService = new PlayerTurnOrderService();
            ProgressReaders.Add(playerTurnOrderService);
            ProgressWriters.Add(playerTurnOrderService);
            
            ITileController tileController = new TileController(playerTurnOrderService);
            
            tilemap.Construct( playerTurnOrderService,  tileController);
            ProgressReaders.Add(tilemap);
            ProgressWriters.Add(tilemap);
            
            return tilemap;
        }

        public GameObject CreateGameInfoPanel(Transform parent)
        {
            return Object.Instantiate(Resources.Load<GameObject>("GameInfoPanel"), parent);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
    }
}