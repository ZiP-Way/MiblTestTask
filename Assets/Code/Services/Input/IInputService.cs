using UnityEngine;

namespace Services.Input
{
  public interface IInputService : IService
  {
    Vector2 Axis { get; }
    void ToggleJoystick(bool state);
  }
}