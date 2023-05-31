using UnityEngine;

namespace Services.Input
{
  public class InputService : IInputService
  {
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";

    #region Properties

    public Vector2 Axis => _isJoystickEnabled ? SimpleInputAxis() : Vector2.zero;

    #endregion

    #region Fields

    private bool _isJoystickEnabled;

    #endregion

    private static Vector2 SimpleInputAxis() => 
      new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

    // This is a very quick implementation that toggles player input.
    // In a project in which there are more player inputs, I would use state machine for InputService(GameLoop, UI, etc.)
    public void ToggleJoystick(bool state) => 
      _isJoystickEnabled = state;
  }
}