using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector
{
    private Weapon _currentWeapon;
    private int _currentIndex;
    private Weapon[] _weapons;

    public WeaponSelector(Weapon[] weapons)
    {
        this._weapons = weapons;
    }

    private void Start()
    {
        _currentIndex = 0;
        changeCurrentWeapon();
    }

    internal void Next()
    {
        _currentIndex++;
        if (_currentIndex >= _weapons.Length)
        {
            _currentIndex = 0;
        }
        changeCurrentWeapon();
    }

    internal void Preview()
    {
        _currentIndex--;
        if (_currentIndex < 0)
        {
            _currentIndex = _weapons.Length - 1;
        }
        changeCurrentWeapon();
    }
    internal void Fire()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.Fire();
        }
    }
    internal void Recharge()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.Recharge();
        } 
    }

    private void changeCurrentWeapon()
    {
        for(int i=0; i< _weapons.Length; i++)
        {
            _weapons[i].gameObject.SetActive(false);
        }
        _currentWeapon = _weapons[_currentIndex];
        _currentWeapon.gameObject.SetActive(true);
    }
  
}
