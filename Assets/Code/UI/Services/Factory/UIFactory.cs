using Infrastructure;
using Infrastructure.StateMachine;
using Services.PlayedTime;
using Services.StaticData;
using StaticData.Windows;
using UI.Services.Windows;
using UI.Windows.LevelResult;
using UnityEngine;

namespace UI.Services.Factory
{
  public class UIFactory : IUIFactory
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IPlayedTimeTrackerService _playedTimeTrackerService;
    private readonly IStateMachine _stateMachine;

    #region Fields

    private Transform _uiContainer;

    #endregion

    public UIFactory(IStaticDataService staticDataService,
      IPlayedTimeTrackerService playedTimeTrackerService,
      IStateMachine stateMachine)
    {
      _staticDataService = staticDataService;
      _playedTimeTrackerService = playedTimeTrackerService;
      _stateMachine = stateMachine;
    }

    public void CreateHUD()
    {
      GameObject hudPrefab = Resources.Load<GameObject>(AssetsAddresses.HUDPrefabPath);
      Object.Instantiate(hudPrefab);
    }

    public void CreateUIContainer()
    {
      GameObject uiContainerPrefab = Resources.Load<GameObject>(AssetsAddresses.UIContainerPrefabPath);
      _uiContainer = Object.Instantiate(uiContainerPrefab).transform;
    }

    public void CreateLevelResultWindow()
    {
      WindowConfig windowConfig = _staticDataService.ForWindow(WindowId.LevelResultWindow);
      LevelResultWindow windowObject = Object.Instantiate(windowConfig.Template, _uiContainer) as LevelResultWindow;

      LevelResultViewModel levelResultViewModel = new LevelResultViewModel(_playedTimeTrackerService, _stateMachine);
      windowObject.Construct(levelResultViewModel);
    }
  }
}