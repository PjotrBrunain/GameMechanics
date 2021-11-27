using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletTemplate = null;
    [SerializeField] private int _clipSize = 50;
    [SerializeField] private float _fireRate = 25.0f;
    [SerializeField] private List<Transform> _fireSockets = new List<Transform>();
    private bool _triggerPulled = false;
    private int _currentAmmo = 50;
    private float _fireTimer = 0.0f;
    
    ////Testing
    //private void Start()
    //{
    //    InvokeRepeating("Fire", 1.0f, 1.0f);
    //}

    private void Awake()
    {
        _currentAmmo = _clipSize;
    }

    private void Update()
    {
        if (_fireTimer > 0)
            _fireTimer -= Time.deltaTime;

        if (_fireTimer <= 0.0f && _triggerPulled)
            FireProjectile();

        _triggerPulled = false;
    }

    private void FireProjectile()
    {
        if (_currentAmmo <= 0)
            return;

        if (_bulletTemplate == null)
            return;

        --_currentAmmo;

        for (int i = 0; i < _fireSockets.Count; i++)
        {
            Instantiate(_bulletTemplate, _fireSockets[i].position, _fireSockets[i].rotation);
        }

        _fireTimer += 1.0f / _fireRate;

        //Debug.Log("Bullets left:" + _currentAmmo);
    }

    public void Fire()
    {
        _triggerPulled = true;
    }

    public void Reload()
    {
        _currentAmmo = _clipSize;
    }
}
