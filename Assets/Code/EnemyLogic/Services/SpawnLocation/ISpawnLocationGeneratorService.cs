using Data;
using Services;
using UnityEngine;

namespace EnemyLogic.Services.SpawnLocation
{
  public interface ISpawnLocationGeneratorService : IService
  {
    void SetArea(AreaData areaData);
    Vector3 GetRandomPositionInsideArea();
  }
}