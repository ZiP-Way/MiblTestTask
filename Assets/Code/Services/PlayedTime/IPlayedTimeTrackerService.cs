namespace Services.PlayedTime
{
  public interface IPlayedTimeTrackerService : IService
  {
    float PlayedTime { get; }
    void StartTracking();
    void StopTracking();
  }
}