using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 30.0f;
    [SerializeField] private float _lifeTime = 10.0f;
    [SerializeField] private int _damage = 5;

    private void Awake()
    {
        Invoke(KILL_METHODNAME, _lifeTime);
    }

    void FixedUpdate()
    {
        if (!WallDetection())
            transform.position += transform.forward * Time.deltaTime * _speed;
    }

    private static readonly string[] RAYCAST_MASK = {"StaticLevel", "DynamicLevel"};
    bool WallDetection()
    {
        Ray collisionRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(collisionRay, Time.deltaTime * _speed,LayerMask.GetMask(RAYCAST_MASK)))
        {
            Kill();
            return true;
        }

        return false;
    }

    private const string KILL_METHODNAME = "Kill";

    void Kill()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.GetComponent<Health>();

        if (otherHealth != null)
        {
            otherHealth.Damage(_damage);
            Kill();
        }
    }
}
