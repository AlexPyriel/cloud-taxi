using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxWidth;
    [SerializeField] private float _minWidth;

    private PlayerInput _input;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Player.MoveUp.performed += ctx => TryMoveUp();
        _input.Player.MoveLeft.performed += ctx => TryMoveLeft();
        _input.Player.MoveDown.performed += ctx => TryMoveDown();
        _input.Player.MoveRight.performed += ctx => TryMoveRight();
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Player.MoveUp.performed -= ctx => TryMoveUp();
        _input.Player.MoveLeft.performed -= ctx => TryMoveLeft();
        _input.Player.MoveDown.performed -= ctx => TryMoveDown();
        _input.Player.MoveRight.performed -= ctx => TryMoveRight();
        _input.Disable();
    }

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
    }

    private void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPositionY(_stepSize);
    }

    private void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPositionY(-_stepSize);
    }

    private void TryMoveRight()
    {
        if (_targetPosition.x < _maxWidth)
            SetNextPositionX(_stepSize);
    }

    private void TryMoveLeft()
    {
        if (_targetPosition.x > _minWidth)
            SetNextPositionX(-_stepSize);
    }

    private void SetNextPositionX(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x + stepSize, _targetPosition.y, transform.position.z);
    }

    private void SetNextPositionY(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + stepSize, transform.position.z);
    }
}
