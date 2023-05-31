using System;
using UnityEngine;

namespace Tools
{
  [RequireComponent(typeof(Collider))]
  public class TriggerObserver : MonoBehaviour
  {
    #region Actions

    public event Action<Collider> TriggerEnter;
    public event Action<Collider> TriggerExit;

    #endregion
    
    private void OnTriggerEnter(Collider other) => 
      TriggerEnter?.Invoke(other);

    private void OnTriggerExit(Collider other) => 
      TriggerExit?.Invoke(other);
  }
}