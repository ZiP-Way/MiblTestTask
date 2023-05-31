using Pool;
using UnityEngine;

namespace EnemyLogic
{
  public abstract class EnemyBase : MonoBehaviour, IPoolElement
  {
    [SerializeField, HideInInspector]
    private EnemyFollow _enemyFollow;

    #region Properties

    public bool IsActive => gameObject.activeInHierarchy;
    public EnemyFollow Follow => _enemyFollow;

    #endregion

    public void Activate() => 
      gameObject.SetActive(true);

    public void Deactivate() => 
      gameObject.SetActive(false);
    
#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_enemyFollow == null)
        _enemyFollow = GetComponent<EnemyFollow>();
    }
#endif
  }
}