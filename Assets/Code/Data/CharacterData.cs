using UnityEngine;

namespace Data
{
  public class CharacterData
  {
    #region Properties

    public Transform Transform => _transform;

    #endregion

    #region Fields

    private Transform _transform;

    #endregion

    public CharacterData(Transform characterTransform) => 
      _transform = characterTransform;
  }
}