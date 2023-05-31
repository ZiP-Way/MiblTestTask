using System;
using System.Collections;
using Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneLoader
{
  public class SceneLoaderService : ISceneLoaderService
  {
    #region Fields

    private readonly ICoroutineRunner _coroutineRunner;

    #endregion

    public SceneLoaderService(ICoroutineRunner coroutineRunner) => 
      _coroutineRunner = coroutineRunner;

    public void Load(string sceneName, Action onLoaded = null) => 
      _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

    private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
    {
      // if (SceneManager.GetActiveScene().name == sceneName)
      // {
      //   onLoaded?.Invoke();
      //   yield break;
      // }
      
      AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);

      while (!waitNextScene.isDone)
        yield return null;
      
      onLoaded?.Invoke();
    }
  }
}