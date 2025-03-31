using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwMedicineChest : MonoBehaviour
{
    [SerializeField] private MedicineChest _medicineChest;
    [SerializeField] private Transform[] _spawnPoints;

    void Start()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            Instantiate(_medicineChest, spawnPoint);
        }
    }

}
