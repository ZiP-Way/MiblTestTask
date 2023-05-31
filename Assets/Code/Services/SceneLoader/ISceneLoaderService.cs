using System;

namespace Services.SceneLoader
{
  public interface ISceneLoaderService : IService
  {
    void Load(string sceneName, Action onLoaded = null);
  }
}