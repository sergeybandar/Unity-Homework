using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    public delegate void OnTakeMedicineChest(int hp);
    public static OnTakeMedicineChest takeMedicineChest;

    [SerializeField] private int _bonusHP;
    
    void Start()
    {
        if (_bonusHP == 0)
        {
            _bonusHP = 25;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player playe)){
            takeMedicineChest?.Invoke(_bonusHP);
        }
        Destroy(gameObject);
    }

}
