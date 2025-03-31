using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _bulletsSpawnPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _capacityMagazine;
    [SerializeField] private float _force;
    [SerializeField] private float _shotDelay;

    private Transform _bulletRoot;
    private Bullet[] _bullets;
    private float _timeDalay=0;

    private void Start()
    {
        _bulletRoot = new GameObject("BulletRoot").transform;
        Recharge();
        
    }
    private void Update()
    {
        _timeDalay += Time.deltaTime;
    }
    public virtual void Fire()
    {
        if (_timeDalay > _shotDelay)
        {
            if(TryGetBullet(out Bullet bullet))
            {
                bullet.Run(_bulletsSpawnPoint.forward * _force, _bulletsSpawnPoint.position, transform.rotation);
            }

            _timeDalay = 0;
        }
    }

    public virtual void Recharge()
    {
        _bullets = new Bullet[ _capacityMagazine ];
        for (int i = 0; i < _capacityMagazine; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, _bulletRoot);
            bullet.Sleep();
            _bullets[i] = bullet;
        }
    }

    private bool TryGetBullet(out Bullet bullet)
    {
        int candidate = -1;
        if (_bullets == null)
        {
            bullet = default;
            return false;
        }

        for (int i = 0; i < _bullets.Length; i++)
        {   bullet = _bullets[i]; 
            if( bullet == null)
            {
                continue;
            }

            if (bullet.IsActive)
            {
                continue;
            }

            candidate = i;
            break;
        }

        if(candidate == -1)
        {
            bullet = default;
            return false;
        }
        bullet = _bullets[candidate];
        return true;
    }
}
