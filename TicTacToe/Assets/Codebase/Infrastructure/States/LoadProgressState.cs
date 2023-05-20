using System.Collections.Generic;
using Codebase.Data;
using Codebase.GameLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.States
{
  public class LoadProgressState : IState
  {
    private GameStateMachine _gameStateMachine;
    private IPersistentProgressService _progressService;
    private ISaveLoadService _saveLoadProgress;
    private IGameFactory _gameFactory;
    private AsyncOperation _loadScene;


    [Inject]
    public void Construct(IPersistentProgressService progressService, ISaveLoadService saveLoadProgress,
      GameStateMachine gameStateMachine, IGameFactory gameFactory)
    {
      _gameStateMachine = gameStateMachine;
      _progressService = progressService;
      _saveLoadProgress = saveLoadProgress;
      _gameFactory = gameFactory;
    }

    public void Enter()
    {
      _loadScene = SceneManager.LoadSceneAsync("MainMenu");
      _loadScene.completed += OnLoaded;
    }

    private void OnLoaded(AsyncOperation obj)
    {
      var mainCanvas = _gameFactory.CreateMainCanvas();
      var newGameButton = _gameFactory.CreateButton(mainCanvas.transform, AssetsPath.NewGameButton);
      newGameButton.onClick.AddListener(LoadNewGame);
      var loadGameButton = _gameFactory.CreateButton(mainCanvas.transform, AssetsPath.LoadGameButton);
      loadGameButton.onClick.AddListener(LoadProgressOrInitNew);
    }

    public void Exit()
    {
      _loadScene.completed -= OnLoaded;
    }

    private void LoadNewGame()
    {
      _progressService.Progress = NewProgress();
      LoadGame();
    }

    private void LoadProgressOrInitNew()
    {
      _progressService.Progress = _saveLoadProgress.LoadProgress() ?? NewProgress();
      LoadGame();
    }

    private void LoadGame()
    {
      _gameStateMachine.Enter<LoadLevelState, string>("Main");
    }

    private PlayerProgress NewProgress()
    {
      var progress = new PlayerProgress();
      
      progress.TileData.tilesData = CreateTileModels();
      progress.PlayerTurnOrderData = CreatePlayerTurnOrderData();
      
      return progress;
    }

    private static PlayerTurnOrderData CreatePlayerTurnOrderData()
    {
      var playerTurnOrderData = new PlayerTurnOrderData();
      playerTurnOrderData.isCross = true;
      playerTurnOrderData.isActiveFirstPlayer = true;
      playerTurnOrderData.moveCounter = 0;
      
      return playerTurnOrderData;
    }

    private static List<TileModel> CreateTileModels()
    {
      List<TileModel> tileModels = new List<TileModel>();
      for (int i = 0; i < 9; i++)
      {
        var model = new TileModel();
        model.TileId = i;
        tileModels.Add(model);
      }

      return tileModels;
    }
  }
}