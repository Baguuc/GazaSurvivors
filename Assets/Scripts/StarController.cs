using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : WeaponController
{
    public float rotationSpeed = 250f;
    public GameObject pivot;
    public float damage = 20f;

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
        pivot.transform.Rotate(Vector3.up * Time.deltaTime * this.rotationSpeed);
    }

    public override float GetDelay()
    {
        return 0f;
    }
}
