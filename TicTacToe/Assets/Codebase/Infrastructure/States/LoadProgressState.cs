using System.Collections.Generic;
using Codebase;
using Codebase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Infrastructure.States
{
  public class LoadProgressState : IState
  {
    private GameStateMachine _gameStateMachine;
    private IPersistentProgressService _progressService;
    private ISaveLoadService _saveLoadProgress;
    private IGameFactory _gameFactory;


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
      var mainCanvas = _gameFactory.CreateMainCanvas();
      var newGameButton = _gameFactory.CreateNewGameButton(mainCanvas.transform);
      newGameButton.onClick.AddListener(LoadGame);
      var loadGameButton = _gameFactory.CreateLoadGameButton(mainCanvas.transform);
      loadGameButton.onClick.AddListener(LoadProgressOrInitNew);
     
    }

    private void LoadGame()
    {
      _gameStateMachine.Enter<LoadLevelState, string>("Main");
    }

    public void Exit()
    {
    }

    private void LoadProgressOrInitNew()
    {
      _progressService.Progress = _saveLoadProgress.LoadProgress() ?? NewProgress();
      LoadGame();
    }

    private PlayerProgress NewProgress()
    {
      var progress = new PlayerProgress();
      List<TileModel> tileModels = new List<TileModel>();
      for (int i = 0; i < 9; i++)
      {
        var model = new TileModel();
        model.TileId = i;
        tileModels.Add(model);
      }

      progress.TileData.tilesData = tileModels;
      return progress;
    }
  }
}