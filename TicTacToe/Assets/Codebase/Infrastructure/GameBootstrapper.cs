using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour
  {
    private GameStateMachine _stateMachine;

    [Inject]
    public void Construct(GameStateMachine stateMachine,
      LoadProgressState loadProgressState, LoadLevelState loadLevelState, GameLoopState gameLoopState)
    {
      _stateMachine = stateMachine;
      _stateMachine.AddState(typeof(LoadProgressState), loadProgressState);
      _stateMachine.AddState(typeof(LoadLevelState), loadLevelState);
      _stateMachine.AddState(typeof(GameLoopState), gameLoopState);
    }

    private void Awake()
    {
      _stateMachine.Enter<LoadProgressState>();
    }

  }
}