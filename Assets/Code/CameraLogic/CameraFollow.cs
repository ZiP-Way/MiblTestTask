using UnityEngine;

namespace CameraLogic
{
  public class CameraFollow : MonoBehaviour
  {
    #region Fields

    private Transform _target;
    private Vector3 _offset;

    #endregion

    private void Awake() =>
      _offset = transform.position;

    public void SetTarget(Transform target) =>
      _target = target;

    private void LateUpdate()
    {
      if (_target == null)
      {
#if UNITY_EDITOR
        Debug.LogWarning($"{this}: Target not found");
#endif
        return;
      }

      transform.position = _target.position + _offset;
    }
  }
}