using Services;

namespace UI.Services.Factory
{
  public interface IUIFactory : IService
  {
    void CreateHUD();
    void CreateUIContainer();
    void CreateLevelResultWindow();
  }
}