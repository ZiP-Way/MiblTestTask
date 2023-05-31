using System.Collections;
using Infrastructure;
using UnityEngine;

namespace Services.PlayedTime
{
  public class PlayedTimeTrackerService : IPlayedTimeTrackerService
  {
    #region Properties

    public float PlayedTime => _playedTime;

    #endregion

    #region Fields

    private readonly ICoroutineRunner _coroutineRunner;

    private Coroutine _coroutine;
    private float _playedTime;

    #endregion

    public PlayedTimeTrackerService(ICoroutineRunner coroutineRunner) => 
      _coroutineRunner = coroutineRunner;

    public void StartTracking()
    {
      if (_coroutine != null)
        return;

      _playedTime = 0;
      _coroutine = _coroutineRunner.StartCoroutine(Tracking());
    }

    public void StopTracking()
    {
      if (_coroutine == null)
        return;

      _coroutineRunner.StopCoroutine(_coroutine);
      _coroutine = null;
    }

    private IEnumerator Tracking()
    {
      while (true)
      {
        yield return null;
        _playedTime += Time.deltaTime;
      }
    }
  }
}