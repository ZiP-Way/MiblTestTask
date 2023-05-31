using System;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Services.PlayedTime;

namespace UI.Windows.LevelResult
{
  public class LevelResultViewModel : ViewModelBase
  {
    #region Fields

    private readonly IPlayedTimeTrackerService _playedTimeTrackerService;
    private readonly IStateMachine _stateMachine;

    #endregion

    public LevelResultViewModel(IPlayedTimeTrackerService playedTimeTrackerService, IStateMachine stateMachine)
    {
      _playedTimeTrackerService = playedTimeTrackerService;
      _stateMachine = stateMachine;
    }

    public int GetPlayedTime()
    {
      float playedTime = _playedTimeTrackerService.PlayedTime;
      return (int)Math.Round(playedTime, MidpointRounding.AwayFromZero);
    }
    
    public void RestartLevel()
    {
      _stateMachine.Enter<LoadLevelState, string>("Game");
    }
  }
}