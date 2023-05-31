using Services.SceneLoader;

namespace Infrastructure.StateMachine.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    #region Fields

    private readonly GameStateMachine _stateMachine;
    private readonly ISceneLoaderService _sceneLoaderService;

    #endregion

    public LoadLevelState(GameStateMachine stateMachine, 
      ISceneLoaderService sceneLoaderService)
    {
      _stateMachine = stateMachine;
      _sceneLoaderService = sceneLoaderService;
    }
    
    public void Enter(string sceneName)
    {
      _sceneLoaderService.Load(sceneName, OnLoaded);
    }

    public void Exit()
    {
    }

    private void OnLoaded()
    {
      _stateMachine.Enter<LevelWarmUpState>();
    }
  }
}