using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController
{
    public GameObject swordHandle;
    public float damage = 10f;

    public override void Dispose(Collider enemy)
    {
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController == null)
        {
            return;
        }

        enemyController.Damage(this.damage);
    }

    public override void Attack(List<GameObject> enemies)
    {
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
