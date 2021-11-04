using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    [SerializeField] private float _pickupSpeed = 2f;
    public float PickupSpeed => _pickupSpeed;
    [SerializeField] private List<GameObject> _pickups;
    [SerializeField] private float _pickupRadius = 5f;
    private float _accuTime;
    public float AccuTime => _accuTime;
    private List<GameObject> _pickedUpItems;

    public List<GameObject> PickedUpItems => _pickedUpItems;
    public List<GameObject> Pickups => _pickups;
    GameObject _closestPickup = null;
    private bool _hasPickupInRange;
    public bool HasPickupInRange => _hasPickupInRange;

    private void Start()
    {
        _pickedUpItems = new List<GameObject>();
    }

    private void Update()
    {
        HandleMovement();
        HandlePickup();
    }

    private void HandleMovement()
    {
        if (_pickups != null)
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
        if (_closestPickup == null)
        {
            _hasPickupInRange = false;
            return;
        }
        if (Vector3.Distance(_closestPickup.transform.position, transform.position) < _pickupRadius)
        {
            _hasPickupInRange = true;
            if (Input.GetKey(KeyCode.E))
            {
                if (_accuTime < _pickupSpeed) _accuTime += Time.deltaTime;
                else
                {
                    Debug.Log("Picked Up");
                    _pickedUpItems.Add(_closestPickup);
                    _pickups.Remove(_closestPickup);
                    _accuTime = 0;
                }
            }
            else
            {
                _accuTime = 0;
            }
        }
        else
        {
            _accuTime = 0;
            _hasPickupInRange = false;
        }
    }
}
