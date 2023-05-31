using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Services;
using UnityEngine;

namespace CharacterLogic
{
  public class Character : MonoBehaviour
  {
    [SerializeField]
    private ParticleSystem _explosionEffect;

    #region Fields

    private IStateMachine _stateMachine;

    #endregion

    private void Awake() => 
      _stateMachine = AllServices.Container.Single<IStateMachine>();

    public void Touch()
    {
      _explosionEffect.Play();
      _stateMachine.Enter<DebriefingState>();
    }
  }
}