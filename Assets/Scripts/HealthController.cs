using System;
using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int _health = 3;

    public int Health
    {
        get
        {
            return _health;
        }
    }
    public bool CanTakeDamage(int damage)
    {
        
       if(_health > 0)
        {
            _health -= damage;     
        }
        if (_health <= 0)
        {
            StartCoroutine(Die());
            return false;
        }
      return true;
    }

    private IEnumerator Die()
    {
        var component = GetComponent<Renderer>();

        component.material.color = Color.red;
        yield return new WaitForSeconds(1f);
        component.material.color = Color.green;
        yield return new WaitForSeconds(1f);
        component.material.color = Color.red;
        yield return new WaitForSeconds(1f);
        component.material.color = Color.green;
        yield return new WaitForSeconds(1f);
        component.material.color = Color.red;
        yield return new WaitForSeconds(1f);
        component.material.color = Color.green;
        yield return new WaitForSeconds(1f);
        component.material.color = Color.gray;


    }
}