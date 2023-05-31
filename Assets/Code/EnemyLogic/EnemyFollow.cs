using System.Collections;
using UnityEngine;

namespace EnemyLogic
{
  [RequireComponent(typeof(Rigidbody))]
  public class EnemyFollow : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private Rigidbody _rigidbody;

    #region Fields

    private float _speed;
    private Transform _target;

    private Coroutine _coroutine;

    #endregion

    public void Construct(float speed, Transform target)
    {
      _target = target;
      _speed = speed;
    }

    private void OnEnable() => 
      StartFollowing();

    private void OnDisable() => 
      StopFollowing();

    public void StartFollowing()
    {
      if (_coroutine == null)
        _coroutine = StartCoroutine(Updating());
    }

    public void StopFollowing()
    {
      if (_coroutine != null)
      {
        StopCoroutine(_coroutine);
        _coroutine = null;
      }
    }

    private IEnumerator Updating()
    {
      while (true)
      {
        yield return new WaitForFixedUpdate();
        Follow();
      }
    }

    private void Follow()
    {
      Vector3 direction = GetDirection();
      _rigidbody.velocity = direction * _speed;
    }

    private Vector3 GetDirection()
    {
      Vector3 direction = _target.position - transform.position;
      direction.Normalize();

      return direction;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_rigidbody == null)
        _rigidbody = GetComponent<Rigidbody>();
    }
#endif
  }
}