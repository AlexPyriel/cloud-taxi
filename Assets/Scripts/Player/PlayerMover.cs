using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxWidth;
    [SerializeField] private float _minWidth;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPositionY(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPositionY(-_stepSize);
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _maxWidth)
            SetNextPositionX(_stepSize);
    }

    public void TryMoveLeft()
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
