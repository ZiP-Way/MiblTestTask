using CharacterLogic.Services.Factory;
using Data;
using EnemyLogic;
using EnemyLogic.Services.Container;
using EnemyLogic.Services.Factory;
using EnemyLogic.Services.Module;
using EnemyLogic.Services.Spawner;
using EnemyLogic.Services.SpawnLocation;
using EnemyLogic.Types;
using Infrastructure.ProviderBase;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Pool;
using Services;
using Services.Input;
using Services.PlayedTime;
using Services.SceneLoader;
using Services.StaticData;
using StaticData.Enemies;
using UI.Services.Factory;
using UI.Services.Windows;
using UnityEngine;

namespace Infrastructure
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    #region Fields

    private GameStateMachine _gameStateMachine;
    private AllServices _services;

    #endregion

    private void Awake()
    {
      _services = AllServices.Container;

      RegisterServices();

      InitializeAndAddStateToStateMachine();

      MoveToBootstrapState();

      DontDestroyOnLoad(this);
    }

    private void RegisterServices()
    {
      BindGameStateMachine();

      BindStaticDataService();

      BindPlayedTimeTrackerService();

      BindInputService();
      BindSceneLoaderService();

      BindUIFactory();
      BindWindowService();

      BindCharacterDataProvider();

      BindCharacterFactory();

      BindEnemySpawnLocationGeneratorService();

      BindEnemiesContainer();
      BindEnemyFactory();
      BindEnemyPool();
      BindEnemySpawnerService();
      BindEnemiesModule();
    }

    private void BindEnemySpawnLocationGeneratorService()
    {
      _services.RegisterSingle<ISpawnLocationGeneratorService>(
        new SpawnLocationGeneratorService());
    }

    private void BindPlayedTimeTrackerService()
    {
      _services.RegisterSingle<IPlayedTimeTrackerService>(
        new PlayedTimeTrackerService(this));
    }

    private void BindEnemiesModule()
    {
      _services.RegisterSingle<IEnemiesModule>(
        new EnemiesModule(_services.Single<IEnemiesContainer>()));
    }

    private void BindEnemySpawnerService()
    {
      _services.RegisterSingle<IEnemySpawnerService>(
        new EnemySpawnerService(this,
          _services.Single<IStaticDataService>(),
          _services.Single<IObjectPool<EnemyCube>>(),
          _services.Single<ISpawnLocationGeneratorService>()));
    }

    private void BindEnemyFactory()
    {
      _services.RegisterSingle<IEnemyFactory>(
        new EnemyFactory(_services.Single<IStaticDataService>(),
          _services.Single<IEnemiesContainer>(),
          _services.Single<IProvider<CharacterData>>()));
    }

    private void BindEnemyPool()
    {
      IEnemyFactory enemyFactory = _services.Single<IEnemyFactory>();

      _services.RegisterSingle<IObjectPool<EnemyCube>>(
        new ObjectPool<EnemyCube>(() =>
          enemyFactory.CreateEnemy(EnemyId.Cube) as EnemyCube));
    }

    private void BindEnemiesContainer()
    {
      _services.RegisterSingle<IEnemiesContainer>(
        new EnemiesContainer());
    }

    private void BindCharacterFactory()
    {
      _services.RegisterSingle<ICharacterFactory>(
        new CharacterFactory(_services.Single<IRegistry<CharacterData>>()));
    }

    private void BindCharacterDataProvider()
    {
      Provider<CharacterData> characterDataProvider = new Provider<CharacterData>();
      _services.RegisterSingle<IProvider<CharacterData>>(characterDataProvider);
      _services.RegisterSingle<IRegistry<CharacterData>>(characterDataProvider);
    }

    private void BindWindowService()
    {
      _services.RegisterSingle<IWindowService>(
        new WindowService(_services.Single<IUIFactory>()));
    }

    private void BindUIFactory()
    {
      _services.RegisterSingle<IUIFactory>(
        new UIFactory(_services.Single<IStaticDataService>(),
          _services.Single<IPlayedTimeTrackerService>(),
          _services.Single<IStateMachine>()));
    }

    private void BindSceneLoaderService()
    {
      _services.RegisterSingle<ISceneLoaderService>(
        new SceneLoaderService(this));
    }

    private void BindInputService()
    {
      _services.RegisterSingle<IInputService>(
        new InputService());
    }

    private void BindStaticDataService()
    {
      _services.RegisterSingle<IStaticDataService>(
        new StaticDataService());
    }

    private void BindGameStateMachine()
    {
      _gameStateMachine = new GameStateMachine();
      _services.RegisterSingle<IStateMachine>(_gameStateMachine);
    }

    private void InitializeAndAddStateToStateMachine()
    {
      BootstrapState bootstrapState = new BootstrapState(_gameStateMachine,
        _services.Single<IStaticDataService>());

      LoadLevelState loadLevelState = new LoadLevelState(_gameStateMachine,
        _services.Single<ISceneLoaderService>());

      LevelWarmUpState levelWarmUpState = new LevelWarmUpState(_gameStateMachine,
        _services.Single<IStaticDataService>(),
        _services.Single<IUIFactory>(),
        _services.Single<ICharacterFactory>(),
        _services.Single<IEnemyFactory>(),
        _services.Single<IEnemiesContainer>(),
        _services.Single<ISpawnLocationGeneratorService>(),
        _services.Single<IObjectPool<EnemyCube>>());

      GameLoopState gameLoopState = new GameLoopState(
        _services.Single<IEnemySpawnerService>(),
        _services.Single<IEnemiesModule>(),
        _services.Single<IPlayedTimeTrackerService>(),
        _services.Single<IInputService>());

      DebriefingState debriefingState = new DebriefingState(
        _services.Single<IWindowService>(),
        _services.Single<IInputService>());

      _gameStateMachine.AddState(typeof(BootstrapState), bootstrapState);
      _gameStateMachine.AddState(typeof(LoadLevelState), loadLevelState);
      _gameStateMachine.AddState(typeof(LevelWarmUpState), levelWarmUpState);
      _gameStateMachine.AddState(typeof(GameLoopState), gameLoopState);
      _gameStateMachine.AddState(typeof(DebriefingState), debriefingState);
    }

    private void MoveToBootstrapState() =>
      _gameStateMachine.Enter<BootstrapState>();
  }
}