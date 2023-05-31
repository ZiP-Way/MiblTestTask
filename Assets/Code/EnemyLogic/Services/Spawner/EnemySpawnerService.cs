using System.Collections;
using EnemyLogic.Services.Factory;
using EnemyLogic.Services.SpawnLocation;
using EnemyLogic.Types;
using Infrastructure;
using Pool;
using Services.StaticData;
using StaticData.Enemies;
using UnityEngine;

namespace EnemyLogic.Services.Spawner
{
  public class EnemySpawnerService : IEnemySpawnerService
  {
    #region Fields

    private readonly ICoroutineRunner _coroutineRunner;
    private readonly IStaticDataService _staticDataService;
    private readonly IObjectPool<EnemyCube> _enemiesPool;
    private readonly ISpawnLocationGeneratorService _spawnLocationGeneratorService;

    private Coroutine _coroutine;

    #endregion

    public EnemySpawnerService(ICoroutineRunner coroutineRunner,
      IStaticDataService staticDataService,
      IObjectPool<EnemyCube> enemiesPool,
      ISpawnLocationGeneratorService spawnLocationGeneratorService)
    {
      _coroutineRunner = coroutineRunner;
      _staticDataService = staticDataService;
      _enemiesPool = enemiesPool;
      _spawnLocationGeneratorService = spawnLocationGeneratorService;
    }

    public void StartSpawning()
    {
      if (_coroutine != null)
      {
#if UNITY_EDITOR
        Debug.LogWarning($"{typeof(EnemySpawnerService)}: Attempting to launch an already running coroutine");
#endif
        return;
      }

      float delayBeforeSpawn = _staticDataService.ForGame().DelayBeforeSpawnEnemy;
      _coroutine = _coroutineRunner.StartCoroutine(SpawnEnemyWithDelay(delayBeforeSpawn));
    }

    public void StopSpawning()
    {
      if (_coroutine == null)
        return;

      _coroutineRunner.StopCoroutine(_coroutine);
      _coroutine = null;
    }

    private IEnumerator SpawnEnemyWithDelay(float delay)
    {
      float currentTime = delay;
      while (true)
      {
        yield return null;
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
          SpawnEnemy();
          currentTime = delay;
        }
      }
    }

    private void SpawnEnemy()
    {
      Vector3 position = _spawnLocationGeneratorService.GetRandomPositionInsideArea();

      EnemyBase freeEnemy = _enemiesPool.GetFreeElement();
      freeEnemy.transform.position = position;
    }
  }
}