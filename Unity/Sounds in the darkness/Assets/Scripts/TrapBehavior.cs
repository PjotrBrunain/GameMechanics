using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TrapBehavior : MonoBehaviour
{
    [SerializeField] private float _stunTime = 1.0f;

    [SerializeField] private float _coolDownTime = 10.0f;
    private float _accuTime = 0.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (_accuTime >= _coolDownTime)
        {
            MovementBehavior behavior = other.GetComponent<MovementBehavior>();
            if (behavior != null)
            {
                behavior.StunTime = _stunTime;
                _accuTime = 0.0f;
            }
        }
    }

    private void Update()
    {
        if (_accuTime < _coolDownTime)
            _accuTime += Time.deltaTime;
    }
}
