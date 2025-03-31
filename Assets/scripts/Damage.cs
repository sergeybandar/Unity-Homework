using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public delegate void OnDamage(float damage);
    public static OnDamage onDamage;

    [SerializeField] private int _baseDamage;
    [SerializeField] private float _multiplier;

    private void Start()
    {
        Debug.Log("Для нанесения урона нажмите Space");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hit();
        }
    }
    public void Hit()
    {   
        float damage = _baseDamage * _multiplier;
        onDamage?.Invoke(damage);
    }

}
