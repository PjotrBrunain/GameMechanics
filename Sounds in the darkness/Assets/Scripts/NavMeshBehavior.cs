using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshBehavior : MovementBehavior
{
    private NavMeshAgent _navMeshAgent;

    private Vector3 _previousTargetPosition = Vector3.zero;

    [SerializeField] private float _wanderRadius;

    private bool _speedHalved;

    protected override void Awake()
    {
        base.Awake();

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _movementSpeed;

        _previousTargetPosition = transform.position;
    }

    //protected override void FixedUpdate()
    //{
    //    base.FixedUpdate();
    //    HandleMovement();
    //}

    private const string STATICLEVEL_LAYER = "StaticLevel";
    private const string PLAYER_TAG = "Player";

    const float MOVEMENT_EPSILON = .25f;
    protected override void HandleMovement()
    {
        if (_target == null)
        {
            _navMeshAgent.isStopped = true;
            return;
        }


        if (Physics.Raycast(transform.position, (_target.transform.position - transform.position).normalized, out var hit))
        {
            if (hit.transform.gameObject.tag == PLAYER_TAG)
            {
                if ((_target.transform.position - _previousTargetPosition).sqrMagnitude > MOVEMENT_EPSILON)
                {
                    _navMeshAgent.SetDestination(_target.transform.position);
                    _navMeshAgent.isStopped = false;
                    _previousTargetPosition = _target.transform.position;
                }
                if (_speedHalved)
                {
                    _navMeshAgent.speed *= 2;
                    _speedHalved = false;
                }
                return;
            }
        }

        if ((_navMeshAgent.destination - transform.position).magnitude < MOVEMENT_EPSILON)
        {
            Vector3 pos = RandomNavSphere(_navMeshAgent.transform.position,
                _wanderRadius, -1);
            _navMeshAgent.SetDestination(pos);
            _navMeshAgent.isStopped = false;
        }
        if (!_speedHalved)
        {
            _navMeshAgent.speed /= 2;
            _speedHalved = true;
        }
    }

    private static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        while (!NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask));

        return navHit.position;
    }

}
