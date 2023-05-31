using EnemyLogic.Services.Container;

namespace EnemyLogic.Services.Module
{
  public class EnemiesModule : IEnemiesModule
  {
    #region Fields

    private readonly IEnemiesContainer _enemiesContainer;

    #endregion

    public EnemiesModule(IEnemiesContainer enemiesContainer) => 
      _enemiesContainer = enemiesContainer;

    public void StopAll()
    {
      foreach (EnemyBase enemy in _enemiesContainer.Enemies) 
        enemy.Follow.StopFollowing();
    }
  }
}