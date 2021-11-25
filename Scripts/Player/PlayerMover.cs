using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;

    private float _minHeight;
    private float _maxHeight;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
        _minHeight = -3;
        _maxHeight = 3;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void MoveUp()
    {
        SetNextPosition(_stepSize);
    }

    public void MoveDown()
    {
        SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, Mathf.Clamp(_targetPosition.y + stepSize, _minHeight, _maxHeight));
    }
}
