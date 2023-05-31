using UI.Services.Factory;

namespace UI.Services.Windows
{
  public class WindowService : IWindowService
  {
    #region Fields

    private readonly IUIFactory _uiFactory;

    #endregion

    public WindowService(IUIFactory uiFactory) => 
      _uiFactory = uiFactory;

    public void Open(WindowId windowId)
    {
      switch (windowId)
      {
        case WindowId.LevelResultWindow:
          _uiFactory.CreateLevelResultWindow();
          break;
      }
    }
  }
}