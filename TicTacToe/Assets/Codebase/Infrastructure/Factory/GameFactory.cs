using System.Collections.Generic;
using Codebase;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        [Inject]
        public GameFactory(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }

        public List<IProgressReader> ProgressReaders { get; } = new List<IProgressReader>();
        public List<IProgressWriter> ProgressWriters { get; } = new List<IProgressWriter>();

        private IPersistentProgressService _progressService;
       
        public Button CreateNewGameButton(Transform parent)
        {
            var gameObject = Object.Instantiate(Resources.Load<GameObject>("NewGameButton"), parent);
            return gameObject.GetComponent<Button>(); 
        }
        
        public Button CreateLoadGameButton(Transform parent)
        {
            var gameObject = Object.Instantiate(Resources.Load<GameObject>("LoadGameButton"), parent);
            return gameObject.GetComponent<Button>();
        }

        public GameObject CreateMainCanvas() => Object.Instantiate(Resources.Load<GameObject>("MainMenuCanvas"));
        
        public Tilemap CreateTileMap(Transform parent)
        {
            var gameObject = Object.Instantiate(Resources.Load<GameObject>("Tilemap"), parent);
            var tilemap = gameObject.GetComponent<Tilemap>();
            ProgressReaders.Add(tilemap);
            ProgressWriters.Add(tilemap);
            return tilemap;
        }
        
        public GameObject CreateGameInfoPanel(Transform parent)
        {
            return Object.Instantiate(Resources.Load<GameObject>("GameInfoPanel"), parent);
        }

        public Button CreateSaveButton(Transform infoPanelTransform)
        {
            var buttonGameObject = Object.Instantiate(Resources.Load<GameObject>("SaveButton"), infoPanelTransform);
            return buttonGameObject.GetComponent<Button>();
        }


        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
    }
}