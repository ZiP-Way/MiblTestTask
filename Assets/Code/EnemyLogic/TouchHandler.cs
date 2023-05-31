using CharacterLogic;
using Tools;
using UnityEngine;

namespace EnemyLogic
{
  public class TouchHandler : MonoBehaviour
  {
    [SerializeField]
    private TriggerObserver _touchDetector;

    private void Awake() => 
      _touchDetector.TriggerEnter += TriggerEnter;

    private void OnDestroy() => 
      _touchDetector.TriggerEnter -= TriggerEnter;

    private void TriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Character character))
        character.Touch();
    }
  }
}