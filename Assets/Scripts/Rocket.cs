using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    [SerializeField] private float _scale;
    [SerializeField] private float _powerExplosion;

    private Collider[] _collidedObjects;

    private void Start()
    {
        _collidedObjects = new Collider[128];
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        new GameObject().AddComponent<Explosion>();
        Destroy(gameObject);
        float radius = _scale / 2;
        Vector3 center = collision.contacts[0].point;
        
        int countCollied = Physics.OverlapSphereNonAlloc(center, radius, _collidedObjects);

        for(int i = 0; i < countCollied; i++)
        {
            Collider col = _collidedObjects[i];

            if (col.TryGetComponent(out HealthController health))
            {
                if (health.CanTakeDamage(_damage))
                {
                    return;
                }

                if (health.TryGetComponent(out Rigidbody rigidbody) == false)
                {
                    rigidbody = collision.gameObject.AddComponent<Rigidbody>();
                }
                rigidbody.AddExplosionForce(_powerExplosion, center, radius);
            }
        }
    }
}
