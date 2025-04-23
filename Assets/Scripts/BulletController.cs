using System.Collections.Generic;
using UnityEngine;

public class BulletController : WeaponController
{
    public GameObject gun;
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;

    public override void Dispose(Collider enemy)
    {
        Destroy(this.gameObject);
        Destroy(enemy.gameObject);
    }

    public override void Attack(List<GameObject> enemies)
    {
        Debug.Log("Gun attack!");
        //sprawdz czy mamy jaki� wrog�w na li�cie
        if (enemies.Count > 0)
        {
            //obr�� "pistolet" w kierunku najbli�szego wroga
            gun.transform.LookAt(enemies[0].transform);
            //stw�rz pocisk na wsp�rz�dnych bulletSpawn z rotacj� "pistoletu" i zapisz referencje do niego do bullet
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, gun.transform.rotation);
            //rozp�d� pocisk w prz�d
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
            //skasuj najbli�szego wroga
            //Destroy(enemies[0]); //czy to jest bezpieczne? zostanie refencja do obiektu w enemies?
            Debug.Log("Pif paf!");
        }
    }

    public override float GetDelay()
    {
        return 2f;
    }
}
