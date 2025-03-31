using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    private void Start()
    {
        Damage.onDamage += TakeDamege;
    }
    private void Update()
    {
        
    }

    private void TakeDamege(float damege)
    {
        if (_health <= 0)
        {
            Debug.Log("Враг побежден");
            return;
        }
        _health -= damege;
        Debug.Log($"Нанесено {damege} урона");
        Debug.Log($"hp врага: {_health}");
       
    }

    private void OnDestroy()
    {
        Damage.onDamage -= TakeDamege;
    }
}
