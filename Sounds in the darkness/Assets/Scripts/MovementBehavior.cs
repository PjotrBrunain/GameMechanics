using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] protected float _movementSpeed = 1.0f;

    protected Rigidbody _rigidBody;
    
    protected Vector3 _desiredMovementDirection = Vector3.zero;

    public Vector3 DesiredMovementDirection
    {
        get => _desiredMovementDirection;
        set => _desiredMovementDirection = value;
    }

    protected GameObject _target;
    public GameObject Target
    {
        get => _target;
        set => _target = value;
    }    

    protected virtual void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        HandleMovement();
    }

    protected virtual void HandleMovement()
    {
        Vector3 movement = _desiredMovementDirection.normalized;
        movement *= _movementSpeed;

        _rigidBody.velocity = movement;
    }
}
