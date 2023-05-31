using Services;
using StaticData.Enemies;
using UnityEngine;

namespace EnemyLogic.Services.Factory
{
  public interface IEnemyFactory : IService
  {
    void CreateContainer();
    EnemyBase CreateEnemy(EnemyId enemyId, Vector3 at);
    EnemyBase CreateEnemy(EnemyId enemyId);
  }
}