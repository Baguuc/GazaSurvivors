using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController
{
    public GameObject swordHandle;

    public override void Dispose(Collider enemy)
    {
        Destroy(enemy.gameObject);
    }

    public override void Attack(List<GameObject> enemies)
    {
        Debug.Log("Sword attack!");
        if (enemies.Count > 0 && Vector3.Distance(enemies[0].transform.position, transform.position) < 1.5f)
        {
            swordHandle.SetActive(true);
        }
        else
        {
            swordHandle.SetActive(false);
        }
    }

    public override float GetDelay()
    {
        return 0f;
    }
}
