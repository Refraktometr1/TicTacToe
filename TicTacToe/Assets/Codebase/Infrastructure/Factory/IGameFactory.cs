using System.Collections.Generic;
using Codebase;
using Codebase.GameLogic;
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
    
    GameObject CreateMainCanvas();
    Tilemap CreateTileMap(Transform parent);
    GameObject CreateGameInfoPanel(Transform parent);
    Button CreateButton(Transform parent, string path);
  }
}