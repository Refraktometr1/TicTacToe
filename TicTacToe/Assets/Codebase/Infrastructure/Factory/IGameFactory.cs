using System.Collections.Generic;
using Codebase;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Factory
{
  public interface IGameFactory
  {
   
    List<IProgressReader> ProgressReaders { get; }
   
    List<IProgressWriter> ProgressWriters { get; }
    void Cleanup();

    Button CreateNewGameButton(Transform parent);
    Button CreateLoadGameButton(Transform parent);
    
    GameObject CreateMainCanvas();
    Tilemap CreateTileMap(Transform parent);
    GameObject CreateGameInfoPanel(Transform parent);
    Button CreateSaveButton(Transform infoPanelTransform);
  }
}