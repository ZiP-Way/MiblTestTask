using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Pool
{
  public interface IObjectPool<T> : IService 
    where T : MonoBehaviour, IPoolElement
  {
    HashSet<T> PoolElements { get; }
    T GetFreeElement();
    void CreatePool(int elementsCount);
  }
}