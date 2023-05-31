using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
  public class ObjectPool<T> : IObjectPool<T> where T : MonoBehaviour, IPoolElement
  {
    #region Properties

    public HashSet<T> PoolElements => _poolElements;

    #endregion

    #region Fields

    private readonly Func<T> _factoryMethod;
    
    private HashSet<T> _poolElements;

    #endregion

    public ObjectPool(Func<T> factoryMethod) => 
      _factoryMethod = factoryMethod;

    public void CreatePool(int elementsCount)
    {
      _poolElements = new HashSet<T>();

      for (int i = 0; i < elementsCount; i++)
        CreateElement();
    }

    public T GetFreeElement()
    {
      if (HasFreeElement(out T element))
        return element;

#if UNITY_EDITOR
      Debug.LogWarning($"{this} A new item was created while retrieving from the pool");
#endif

      return CreateElement();
    }
    
    private T CreateElement()
    {
      T poolElement = _factoryMethod.Invoke();
      poolElement.Deactivate();

      _poolElements.Add(poolElement);

      return poolElement;
    }

    private bool HasFreeElement(out T element)
    {
      foreach (T poolElement in _poolElements)
      {
        if (!poolElement.IsActive)
        {
          poolElement.Activate();
          element = poolElement;

          return true;
        }
      }

      element = null;
      return false;
    }
  }
}