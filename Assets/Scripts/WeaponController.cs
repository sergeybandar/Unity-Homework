using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //[SerializeField] private List<Weapon> weapons = new List<Weapon>();
    //[SerializeField] private Weapon _activeWeapon;

    private WeaponSelector _weaponSelector;

    private void Start()
    {
        Weapon[] weapons = GetComponentsInChildren<Weapon>(true);
        _weaponSelector = new WeaponSelector(weapons);
    }

    void Update()
    {
        float scroallWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scroallWheel >= 0.1f)
        {
            _weaponSelector.Next();
        }
        if (scroallWheel <= -0.1f)
        {
            _weaponSelector.Preview();
        }
        if (Input.GetMouseButton(0))
        {
            _weaponSelector.Fire();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _weaponSelector.Recharge();
        }
    }
}
