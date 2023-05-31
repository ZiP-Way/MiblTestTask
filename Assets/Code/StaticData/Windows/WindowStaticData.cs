using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData.Windows
{
  [CreateAssetMenu(menuName = "Static Data/Window static data", fileName = "WindowStaticData")]
  public class WindowStaticData : ScriptableObject
  {
    [FormerlySerializedAs("Windows")]
    public WindowConfig[] Configs;
  }
}