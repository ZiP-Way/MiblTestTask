using Data;
using UnityEngine;

namespace EnemyLogic.Services.SpawnLocation
{
  public class SpawnLocationGeneratorService : ISpawnLocationGeneratorService
  {
    #region Fields

    private AreaData _areaData;

    #endregion

    public void SetArea(AreaData areaData) => 
      _areaData = areaData;

    public Vector3 GetRandomPositionInsideArea()
    {
      Vector3 randomPositionInsideArea = new Vector3(
          _areaData.Center.x + Random.Range(-_areaData.Size.x / 2, _areaData.Size.x / 2),
          0,
          _areaData.Center.z + Random.Range(-_areaData.Size.z / 2, _areaData.Size.x / 2));
      
      return randomPositionInsideArea;
    }
  }
}