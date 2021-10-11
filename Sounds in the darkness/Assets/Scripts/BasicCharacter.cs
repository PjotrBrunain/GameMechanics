using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    protected MovementBehavior _movementBehavior;

    protected virtual void Awake()
    {
        _movementBehavior = GetComponent<MovementBehavior>();
    }
}
