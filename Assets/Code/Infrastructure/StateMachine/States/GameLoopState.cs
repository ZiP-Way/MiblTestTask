using EnemyLogic.Services.Module;
using EnemyLogic.Services.Spawner;
using Services.Input;
using Services.PlayedTime;

namespace Infrastructure.StateMachine.States
{
  public class GameLoopState : IState
  {
    private readonly IEnemySpawnerService _enemySpawnerService;
    private readonly IEnemiesModule _enemiesModule;
    private readonly IPlayedTimeTrackerService _playedTimeTrackerService;
    private readonly IInputService _inputService;

    #region Fields

    #endregion

    public GameLoopState(IEnemySpawnerService enemySpawnerService, 
      IEnemiesModule enemiesModule,
      IPlayedTimeTrackerService playedTimeTrackerService,
      IInputService inputService)
    {
      _enemySpawnerService = enemySpawnerService;
      _enemiesModule = enemiesModule;
      _playedTimeTrackerService = playedTimeTrackerService;
      _inputService = inputService;
    }

    public void Enter()
    {
      _inputService.ToggleJoystick(true);
      
      _playedTimeTrackerService.StartTracking();
      _enemySpawnerService.StartSpawning();
    }

    public void Exit()
    {
      _playedTimeTrackerService.StopTracking();
      _enemySpawnerService.StopSpawning();
      _enemiesModule.StopAll();
    }
  }
}