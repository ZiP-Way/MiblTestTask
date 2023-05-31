using Services;
using UnityEngine;

namespace CharacterLogic.Services.Factory
{
  public interface ICharacterFactory : IService
  {
    GameObject CreateCharacter(Vector3 at);
  }
}