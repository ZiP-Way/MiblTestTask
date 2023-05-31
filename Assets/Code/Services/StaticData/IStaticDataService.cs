using StaticData.Enemies;
using StaticData.Game;
using StaticData.Windows;
using UI.Services.Windows;

namespace Services.StaticData
{
  public interface IStaticDataService : IService
  {
    void Load();
    WindowConfig ForWindow(WindowId windowId);
    EnemyStaticData ForEnemy(EnemyId enemyId);
    GameStaticData ForGame();
  }
}