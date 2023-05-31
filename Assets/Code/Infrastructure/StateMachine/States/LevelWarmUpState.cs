using CameraLogic;
using CharacterLogic.Services.Factory;
using EnemyLogic;
using EnemyLogic.Services.Container;
using EnemyLogic.Services.Factory;
using EnemyLogic.Services.SpawnLocation;
using EnemyLogic.Types;
using Pool;
using Services.StaticData;
using UI.Services.Factory;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
  public class LevelWarmUpState : IState
  {
    #region Fields

    private readonly GameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly IUIFactory _uiFactory;
    private readonly ICharacterFactory _characterFactory;
    private readonly IEnemyFactory _enemyFactory;
    private readonly IEnemiesContainer _enemiesContainer;
    private readonly ISpawnLocationGeneratorService _spawnLocationGeneratorService;
    private readonly IObjectPool<EnemyCube> _enemiesPool;

    #endregion

    public LevelWarmUpState(GameStateMachine stateMachine,
      IStaticDataService staticDataService,
      IUIFactory uiFactory,
      ICharacterFactory characterFactory,
      IEnemyFactory enemyFactory,
      IEnemiesContainer enemiesContainer,
      ISpawnLocationGeneratorService spawnLocationGeneratorService,
      IObjectPool<EnemyCube> enemiesPool)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
      _uiFactory = uiFactory;
      _characterFactory = characterFactory;
      _enemyFactory = enemyFactory;
      _enemiesContainer = enemiesContainer;
      _spawnLocationGeneratorService = spawnLocationGeneratorService;
      _enemiesPool = enemiesPool;
    }

    public void Enter()
    {
      _uiFactory.CreateHUD();
      _uiFactory.CreateUIContainer();
      
      _enemiesContainer.Clear();
      _enemyFactory.CreateContainer();
      
      CreateCharacter();

      SetEnemySpawnArea();

      _enemiesPool.CreatePool(10);
      
      MoveToGameLoopState();
    }

    private void SetEnemySpawnArea()
    {
      _spawnLocationGeneratorService
        .SetArea(_staticDataService.ForGame().EnemyAreaData);
    }

    private void CreateCharacter()
    {
      GameObject character = _characterFactory
        .CreateCharacter(_staticDataService.ForGame().CharacterSpawnPosition);

      Camera.main.GetComponent<CameraFollow>().SetTarget(character.transform);
    }

    public void Exit()
    {
    }
    
    private void MoveToGameLoopState() => 
      _stateMachine.Enter<GameLoopState>();
  }
}