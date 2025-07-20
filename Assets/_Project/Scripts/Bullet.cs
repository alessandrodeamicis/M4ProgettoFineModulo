using System.Collections;
using System.Collections.Generic;
using Assets._Project.Scripts;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed = 25f;
    private float _bulletLifeTime = 5f;
    private int _bulletDamage = 2;
    private IBulletSpawner _spawner;
    private Rigidbody _rb;

    public int GetDamage() => _bulletDamage;

    public void Setup(IBulletSpawner spawner)
    {
        _spawner = spawner;
    }
    private void OnCollisionEnter(Collision collision)
    {
        CancelInvoke();
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        _spawner.ReleaseBullet(this);
    }

    public void Shoot(Vector3 direction)
    {
        if(_rb == null) _rb = GetComponent<Rigidbody>();

        _rb.velocity = direction * _bulletSpeed;
        _rb.angularVelocity = Vector3.zero;

        CancelInvoke();
        Invoke("ReturnToPool", _bulletLifeTime);
    }
}
