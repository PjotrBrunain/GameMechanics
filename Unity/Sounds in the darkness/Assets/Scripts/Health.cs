using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _startHealth = 1;
    private int _currentHealth = 0;

    void Awake()
    {
        _currentHealth = _startHealth;
    }

    public void Damage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
            Kill();
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}