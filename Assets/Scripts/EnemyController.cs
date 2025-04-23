using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 4f;
    public float health = 20f;

    GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerWeapon")
        {
            WeaponController weaponController = other.GetComponent<WeaponController>();

            if(weaponController == null)
            {
                return;
            }
            
            Collider selfCollider = this.GetComponent<Collider>();

            if (selfCollider == null)
            {
                return;
            }

            weaponController.Dispose(selfCollider);
        }
    }

    public void Damage(float damageAmount)
    {
        this.health -= damageAmount;

        if(this.health <= 0)
        {
            Destroy(this.gameObject);
            GameObject.FindWithTag("LevelManager").GetComponent<LevelManger>().AddPoints(1);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
