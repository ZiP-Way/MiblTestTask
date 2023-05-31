using Data;
using Infrastructure;
using Infrastructure.ProviderBase;
using UnityEngine;

namespace CharacterLogic.Services.Factory
{
  public class CharacterFactory : ICharacterFactory
  {
    #region Fields

    private readonly IRegistry<CharacterData> _characterDataProvider;

    #endregion

    public CharacterFactory(IRegistry<CharacterData> characterDataProvider) => 
      _characterDataProvider = characterDataProvider;

    public GameObject CreateCharacter(Vector3 at)
    {
      GameObject characterPrefab = Resources
        .Load<GameObject>(AssetsAddresses.CharacterPrefabPath);
      GameObject characterObject = Object.Instantiate(characterPrefab, at, Quaternion.identity);

      CharacterData characterData = new CharacterData(characterObject.transform);
      _characterDataProvider.Registry(characterData);

      return characterObject;
    }
  }
}