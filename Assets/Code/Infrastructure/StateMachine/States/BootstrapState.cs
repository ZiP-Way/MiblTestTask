using Services.StaticData;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
  public class BootstrapState : IState
  {
    #region Fields

    private readonly GameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;

    #endregion

    public BootstrapState(GameStateMachine stateMachine, 
      IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
    }
    
    public void Enter()
    {
      Application.targetFrameRate = 60;
      
      _staticDataService.Load();
      MoveToLevel();
    }

    public void Exit()
    {
      
    }

    private void MoveToLevel() => 
      _stateMachine.Enter<LoadLevelState, string>("Game");
  }
}