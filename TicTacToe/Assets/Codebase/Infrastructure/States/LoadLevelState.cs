﻿using Codebase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly GameStateMachine _stateMachine;
    private readonly IGameFactory _gameFactory;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
   
    [Inject]
    public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory,
      IPersistentProgressService progressService, ISaveLoadService saveLoadService)
    {
      _stateMachine = gameStateMachine;
      _gameFactory = gameFactory;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
    }

    public void Enter(string sceneName)
    {
      _gameFactory.Cleanup();
      var loadScene =  SceneManager.LoadSceneAsync(sceneName);
      loadScene.completed += OnLoaded;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
    

    private void OnLoaded(AsyncOperation asyncOperation)
    {
      InitGameWorld();
      InformProgressReaders();

      _stateMachine.Enter<GameLoopState>();
    }

    private void InformProgressReaders()
    {
      foreach (IProgressReader progressReader in _gameFactory.ProgressReaders)
        progressReader.LoadProgress(_progressService.Progress);
    }

    private void InitGameWorld()
    {
      var mainCanvas = _gameFactory.CreateMainCanvas();
      
      var infoPanel = _gameFactory.CreateGameInfoPanel(mainCanvas.transform);
      
      _gameFactory.CreateTileMap(mainCanvas.transform, infoPanel.transform);

      var saveButton = _gameFactory.CreateButton(infoPanel.transform, AssetsPath.SaveButton);
      saveButton.onClick.AddListener(_saveLoadService.SaveProgress);

      var mainMenuButton = _gameFactory.CreateButton(infoPanel.transform, AssetsPath.MainMenuButton);
      mainMenuButton.onClick.AddListener(ToMainMenu);
    }

    private void ToMainMenu()
    {
      _stateMachine.Enter<LoadProgressState>();
    }
  }
}