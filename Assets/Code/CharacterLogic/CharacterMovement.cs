using Services;
using Services.Input;
using UnityEngine;

namespace CharacterLogic
{
  [RequireComponent(typeof(CharacterController))]
  public class CharacterMovement : MonoBehaviour
  {
    [SerializeField]
    private float _movementSpeed;

    [SerializeField, HideInInspector]
    private CharacterController _characterController;

    #region Fields

    private IInputService _inputService;

    private Camera _camera;

    #endregion

    private void Awake() => 
      _inputService = AllServices.Container.Single<IInputService>();

    private void Start() => 
      _camera = Camera.main;

    private void Update() => 
      Move(Time.deltaTime);

    private void Move(float deltaTime)
    {
      Vector3 movementVector = Vector3.zero;

      if (IsAxisChanged())
      {
        Vector2 inputAxis = _inputService.Axis;
        
        movementVector.x = inputAxis.x;
        movementVector.y = 0;
        movementVector.z = inputAxis.y;
        
        transform.forward = movementVector;
      }

      movementVector += Physics.gravity;

      _characterController.Move(_movementSpeed * movementVector * deltaTime);
    }

    private bool IsAxisChanged() => 
      _inputService.Axis.sqrMagnitude > Constants.Epsilon;

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_characterController == null)
        _characterController = GetComponent<CharacterController>();
    }
#endif
    
  }
}