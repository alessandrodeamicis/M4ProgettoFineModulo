using System.Collections;
using System.Collections.Generic;
using Assets._Project.Scripts;
using UnityEngine;

public class PlayerBulletSpawner : MonoBehaviour, IBulletSpawner
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;

    private Queue<Bullet> _bulletPool = new Queue<Bullet>();

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet b = GetBullet();
            b.transform.position = _spawnPoint.position;
            b.Shoot(_spawnPoint.forward);
        }
    }

    public Bullet GetBullet()
    {
        Bullet bullet = null;
        if (_bulletPool.Count > 0)
        {
            bullet = _bulletPool.Dequeue();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Instantiate(_bulletPrefab);
            bullet.Setup(this);
        }
        return bullet;
    }

    public void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }
}
