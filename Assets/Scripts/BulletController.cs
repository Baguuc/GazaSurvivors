using System.Collections.Generic;
using UnityEngine;

public class BulletController : WeaponController
{
    public GameObject gun;
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;
    public float damage = 5f;

    public override void Dispose(Collider enemy)
    {
        Destroy(this.gameObject);

        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController == null)
        {
            return;
        }

        enemyController.Damage(this.damage);
    }

    public override void Attack(List<GameObject> enemies)
    {
        if (enemies.Count > 0)
        {
            gun.transform.LookAt(enemies[0].transform);

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, gun.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
        }
    }

    public override float GetDelay()
    {
        return 2f;
    }
}
