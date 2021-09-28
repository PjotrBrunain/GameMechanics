using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    protected ShootingBehavior _shootingBehavior;
    protected MovementBehavior _movementBehavior;

    protected virtual void Awake()
    {
        _shootingBehavior = GetComponent<ShootingBehavior>();
        _movementBehavior = GetComponent<MovementBehavior>();
    }
}
