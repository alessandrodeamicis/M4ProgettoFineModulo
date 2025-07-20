using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class TurretBulletSpawner : MonoBehaviour, IBulletSpawner
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _shootingRate = 0.5f;
        [SerializeField] private Transform _spawnPoint;

        private TurretController _turretController;
        private Queue<Bullet> _bulletPool = new Queue<Bullet>();
        private float _lastShotTime;

        private void Start()
        {
            _turretController = GetComponent<TurretController>();
        }
        private void Update()
        {
            if (Time.time - _lastShotTime > _shootingRate)
            {
                _lastShotTime = Time.time;

                Bullet b = GetBullet();
                b.transform.position = _spawnPoint.position;
                if (_turretController.GetPlayerNear())
                {
                    b.Shoot(_spawnPoint.forward);
                }
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
}
