using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshBehavior : MovementBehavior
{
    private NavMeshAgent _navMeshAgent;

    private Vector3 _previousTargetPosition = Vector3.zero;

    [SerializeField] private float wanderRadius;
    [SerializeField] private float wanderTime;

    private float timer;

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

    const float MOVEMENT_EPSILON = .25f;
    protected override void HandleMovement()
    {
        if (_target == null)
        {
            _navMeshAgent.isStopped = true;
            return;
        }

        timer += Time.deltaTime;

        if (timer >= wanderTime)
        {
            _navMeshAgent.SetDestination(RandomNavSphere(_navMeshAgent.transform.position, 1.0f, /*LayerMask.GetMask(STATICLEVEL_LAYER)*/ -1));
            _navMeshAgent.isStopped = false;
            timer = 0;
        }


        //if ((_target.transform.position - _previousTargetPosition).sqrMagnitude > MOVEMENT_EPSILON)
        //{
        //    _navMeshAgent.SetDestination(_target.transform.position);
        //    _navMeshAgent.isStopped = false;
        //    _previousTargetPosition = _target.transform.position;
        //}
    }

    private static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }

}
