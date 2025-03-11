using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponDataManager), menuName = "Data/Wepon/Manager")]
public class WeaponDataManager : ScriptableObject
{
    public static WeaponDataManager Instance { get; private set; }

    WeaponDataManager() : base() {
        Instance = this;
    }

    [Serializable]
    private sealed class WeponDataByWeaponName
    {
        public Weapon weapon;
        public WeaponData weaponData;
    }

    [SerializeField] private WeponDataByWeaponName[] _weaponsData;
    public bool TryGetWeaponDataByWeaponName(Weapon weapon, out WeaponData weaponDate)
    {
        weaponDate = null;
        for (int i = 0; i < _weaponsData.Length; i++)
        {
            if(_weaponsData[i].weapon.name.Equals(weapon.name))
            {
                weaponDate =_weaponsData[i].weaponData;
                return true;
            }
        }
        return false;
    }
}
