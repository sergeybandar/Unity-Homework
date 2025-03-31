using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] protected int _damage = 1;
    protected Rigidbody _rigRigidbody;
    

    public bool IsActive { get; set; }

    private void Awake()
    {
        _rigRigidbody = GetComponent<Rigidbody>();
    }
    public void Sleep()
    {
        _rigRigidbody.Sleep();
        gameObject.SetActive(false);
        IsActive = false;
    }

    private void OnBecameInvisible()
    {
        if (!IsActive)
        {
            return;
        }
        Destroy(gameObject);
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if(collision.gameObject.TryGetComponent(out HealthController health))
        {
            if (health.CanTakeDamage(_damage))
            {
                return;
            }

            if (collision.gameObject.TryGetComponent(out Rigidbody rigidbody) == false)
            {
                rigidbody = collision.gameObject.AddComponent<Rigidbody>();
            }
            rigidbody.AddForce(_rigRigidbody.velocity * 25, ForceMode.Impulse);
        }
    }

  
    internal void Run(Vector3 path, Vector3 startPosition, Quaternion rotation)
    {
        transform.position = startPosition;
        transform.rotation = rotation;
        gameObject.SetActive(true);
        _rigRigidbody.WakeUp();
        _rigRigidbody.AddForce(path);
        IsActive=true;
    }
}