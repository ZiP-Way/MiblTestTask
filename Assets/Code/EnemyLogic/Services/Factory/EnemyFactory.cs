using System;
using Data;
using EnemyLogic.Services.Container;
using Infrastructure.ProviderBase;
using Services.StaticData;
using StaticData.Enemies;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EnemyLogic.Services.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    private const string ContainerName = "EnemiesContainer";

    #region Properties

    private Transform CharacterTransform => _characterDataProvider.Instance.Transform; 

    #endregion
    
    #region Fields

    private readonly IStaticDataService _staticDataService;
    private readonly IEnemiesContainer _enemiesContainer;
    private readonly IProvider<CharacterData> _characterDataProvider;
    
    private Transform _container;

    #endregion

    public EnemyFactory(IStaticDataService staticDataService, 
      IEnemiesContainer enemiesContainer,
      IProvider<CharacterData> characterDataProvider)
    {
      _staticDataService = staticDataService;
      _enemiesContainer = enemiesContainer;
      _characterDataProvider = characterDataProvider;
    }

    public void CreateContainer() =>
      _container = new GameObject(ContainerName).transform;

    public EnemyBase CreateEnemy(EnemyId enemyId) => 
      CreateEnemy(enemyId, Vector3.zero);

    public EnemyBase CreateEnemy(EnemyId enemyId, Vector3 at)
    {
      EnemyStaticData staticData = _staticDataService.ForEnemy(enemyId);
      EnemyBase enemyPrefab = staticData.Prefab;

      EnemyBase enemy = Object.Instantiate(enemyPrefab, at, Quaternion.identity, _container);
      enemy.Follow.Construct(staticData.Settings.MovementSpeed, CharacterTransform);
      
      _enemiesContainer.Add(enemy);

      return enemy;
    }
  }
}