using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using StaticData.Enemies;
using StaticData.Game;
using StaticData.Windows;
using UI.Services.Windows;
using UnityEngine;

namespace Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    #region Fields

    private Dictionary<WindowId, WindowConfig> _windows;
    private Dictionary<EnemyId, EnemyStaticData> _enemies;

    private GameStaticData _gameStaticData;

    #endregion

    public void Load()
    {
      _windows = Resources
        .Load<WindowStaticData>(AssetsAddresses.WindowStaticDataPath)
        .Configs
        .ToDictionary(x => x.WindowId, x => x);

      _enemies = Resources
        .LoadAll<EnemyStaticData>(AssetsAddresses.EnemyStaticDataPath)
        .ToDictionary(x => x.EnemyId, x => x);

      _gameStaticData = Resources
        .Load<GameStaticData>(AssetsAddresses.GameStaticDataPath);
    }

    public WindowConfig ForWindow(WindowId windowId)
    {
      return _windows.TryGetValue(windowId, out WindowConfig windowConfig)
        ? windowConfig
        : throw new Exception($"Not found {windowId} window");
    }

    public EnemyStaticData ForEnemy(EnemyId enemyId)
    {
      return _enemies.TryGetValue(enemyId, out EnemyStaticData data)
        ? data
        : throw new Exception($"Not found {enemyId} enemy");
    }

    public GameStaticData ForGame() => 
      _gameStaticData;
  }
}