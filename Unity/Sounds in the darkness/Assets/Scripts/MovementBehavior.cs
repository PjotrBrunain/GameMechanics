using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] protected float _movementSpeed = 1.0f;

    protected Rigidbody _rigidBody;
    
    protected Vector3 _desiredMovementDirection = Vector3.zero;

    protected float _stunTime = 0.0f;

    public float StunTime
    {
        set => _stunTime = value;
        get => _stunTime;
    }

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

    private const string STATICLEVEL_LAYER = "StaticLevel";

    protected virtual void HandleMovement()
    {
        Vector3 movement = _desiredMovementDirection.normalized;
        movement *= _movementSpeed;

        if (_stunTime <= 0)
            _rigidBody.velocity = movement;
        else
        {
            _stunTime -= Time.deltaTime;
            _rigidBody.velocity = Vector3.zero;
        }

        if (!Physics.Raycast(gameObject.transform.position,new Vector3( 0.0f, -1.0f,0.0f), 0.2f, LayerMask.GetMask(STATICLEVEL_LAYER)))
            _rigidBody.AddForce(new Vector3(0.0f, -500.0f, 0.0f), ForceMode.Acceleration);
    }
}
