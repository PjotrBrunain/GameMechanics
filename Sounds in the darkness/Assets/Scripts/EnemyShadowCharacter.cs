using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShadowCharacter : BasicCharacter
{
    private GameObject _playerTarget = null;
    [SerializeField] private float _attackRange = 2.0f;

    private void Start()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

        if (player) _playerTarget = player.gameObject;
    }

    private void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (_movementBehavior == null) return;

        _movementBehavior.Target = _playerTarget;
    }

    const string KILL_METHODNAME = "Kill";
    void Kill()
    {
        Destroy(gameObject);
    }
}
