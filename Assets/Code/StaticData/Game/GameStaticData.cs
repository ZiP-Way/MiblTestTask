using Data;
using UnityEngine;

namespace StaticData.Game
{
  [CreateAssetMenu(menuName = "Static Data/Game static data", fileName = "GameStaticData")]
  public class GameStaticData : ScriptableObject
  {
    public float DelayBeforeSpawnEnemy;

    public AreaData EnemyAreaData;
    public Vector3 CharacterSpawnPosition;
  }
}