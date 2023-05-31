using EnemyLogic;
using UnityEngine;

namespace StaticData.Enemies
{
  [CreateAssetMenu(menuName = "Static Data/Enemy static data", fileName = "EnemyStaticData")]
  public class EnemyStaticData : ScriptableObject
  {
    public EnemyId EnemyId;
    public EnemySettings Settings;
    public EnemyBase Prefab;
  }
}