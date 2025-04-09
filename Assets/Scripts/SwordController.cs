using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController
{
    public override void Dispose(Collider enemy)
    {
        Destroy(enemy.gameObject);
    }
}
