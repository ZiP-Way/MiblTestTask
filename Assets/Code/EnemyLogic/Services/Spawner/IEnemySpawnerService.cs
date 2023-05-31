using Services;

namespace EnemyLogic.Services.Spawner
{
  public interface IEnemySpawnerService : IService
  {
    void StartSpawning();
    void StopSpawning();
  }
}