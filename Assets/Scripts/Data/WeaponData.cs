using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponData), menuName = "Data/Wepon/Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private float _force;
    [SerializeField] private float _shotDelay;

    public float Force { get => _force;}
    public float ShotDelay { get => _shotDelay;}
    
}
