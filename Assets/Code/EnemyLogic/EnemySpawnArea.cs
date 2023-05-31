using UnityEngine;

namespace EnemyLogic
{
  public class EnemySpawnArea : MonoBehaviour
  {
    [SerializeField]
    private Vector3 _size;

    [SerializeField]
    private Color _gizmoColor;

    #region Properties

    public Vector3 Size => _size;
    public Vector3 Center => transform.position;

    #endregion

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
      Gizmos.color = _gizmoColor;
      Gizmos.DrawCube(transform.position, _size);
    }
#endif
  }
}