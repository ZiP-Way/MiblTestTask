using Services.Input;
using UI.Services.Windows;

namespace Infrastructure.StateMachine.States
{
  public class DebriefingState : IState
  {
    #region Fields

    private readonly IWindowService _windowService;
    private readonly IInputService _inputService;

    #endregion

    public DebriefingState(IWindowService windowService,
      IInputService inputService)
    {
      _windowService = windowService;
      _inputService = inputService;
    }

    public void Enter()
    {
      _inputService.ToggleJoystick(false);
      _windowService.Open(WindowId.LevelResultWindow);
    }

    public void Exit()
    {
    }
  }
}