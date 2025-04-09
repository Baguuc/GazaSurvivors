using UnityEngine;

public class BulletController : WeaponController
{
    public override void Dispose(Collider enemy)
    {
        Destroy(this.gameObject);
        Destroy(enemy.gameObject);
    }
}
