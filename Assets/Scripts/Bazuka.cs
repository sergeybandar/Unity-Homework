using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazuka : Weapon
{
    [SerializeField] private GameObject rocket;
   public override void Fire()
    {
        base.Fire();
        rocket.SetActive(false);
    }

    public override void Recharge()
    {
        base.Recharge();
        rocket.SetActive(true);
    }
}
