using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    [SerializeField] private float _pickupSpeed = 10f;
    [SerializeField] private List<GameObject> _pickups = null;
    [SerializeField] private float _pickupRadius = 5f;
    private float _accuTime;
    private bool _pickingUp;

    GameObject _closestPickup = null;

    private void Update()
    {
        HandleMovement();
        HandlePickup();
    }

    private void HandleMovement()
    {
        _closestPickup = GetClosestPickup(_pickups);
    }

    GameObject GetClosestPickup(List<GameObject> pickups)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in pickups)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }

    private void HandlePickup()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (_accuTime < _pickupSpeed) _accuTime += Time.deltaTime;
            else print("Picked up");
        }
e    }
}
