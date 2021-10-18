using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShadowCharacter : BasicCharacter
{
    private GameObject _playerTarget = null;
    [SerializeField] private float _attackRange = 2.0f;
    private Health _playerHealth = null;
    [SerializeField] private int _damage = 5;

    private ParticleSystem _soundRippleSystem = null;

    [SerializeField] private float _emitTime = 5.0f;
    private float _accuTime = 0.0f;

    private void Start()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

        if (player) _playerTarget = player.gameObject;

        ParticleSystem rippleSystem = GetComponentInChildren<ParticleSystem>();

        if (rippleSystem) _soundRippleSystem = rippleSystem;

        _accuTime = Random.Range(0.0f, _emitTime);
    }

    private void Update()
    {
        HandleMovement();
        HandleAttacking();
        HandleRipple();
    }

    void HandleMovement()
    {
        if (_movementBehavior == null) return;

        _movementBehavior.Target = _playerTarget;
    }

    void HandleAttacking()
    {
        if (_playerTarget == null) return;

        if ((transform.position - _playerTarget.transform.position).sqrMagnitude < _attackRange * _attackRange)
        {
            _playerHealth = _playerTarget.GetComponent<Health>();
            if (_playerHealth != null)
            {
                _playerHealth.Damage(_damage);
            }
        }
    }

    void HandleRipple()
    {
        _accuTime += Time.deltaTime;
        if (_accuTime >= _emitTime)
        {
            _soundRippleSystem.Play();
            _accuTime = 0.0f;
        }
    }

    const string KILL_METHODNAME = "Kill";
    void Kill()
    {
        Destroy(gameObject);
    }
}
