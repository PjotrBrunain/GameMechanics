using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikazeCharacter : BasicCharacter
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
        HandleAttacking();
    }

    void HandleMovement()
    {
        if (_movementBehavior == null)
            return;

        _movementBehavior.Target = _playerTarget;
    }

    void HandleAttacking()
    {
        if (_shootingBehavior == null) return;
        if (_playerTarget == null) return;

        if ((transform.position - _playerTarget.transform.position).sqrMagnitude < _attackRange * _attackRange)
        {
            _shootingBehavior.PrimaryFire();

            Invoke(KILL_METHODNAME, 0.2f);
        }
    }

    const string KILL_METHODNAME = "Kill";
    void Kill()
    {
        Destroy(gameObject);
    }
}
