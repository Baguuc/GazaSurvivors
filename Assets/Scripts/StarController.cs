using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : WeaponController
{
    public float rotationSpeed = 250f;
    public GameObject pivot;

    public override void Dispose(Collider enemy)
    {
        Destroy(enemy.gameObject);
    }

    public override void Attack(List<GameObject> enemies)
    {
        Debug.Log("Star attack!");
        pivot.transform.Rotate(Vector3.up * Time.deltaTime * this.rotationSpeed);
    }

    public override float GetDelay()
    {
        return 0f;
    }
}
