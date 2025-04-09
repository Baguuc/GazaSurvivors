using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        // jezeli trigger ma tag "Bullet" (czyli jest kulka), zniszcz przeciwnika i kulke
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
            GameObject.FindWithTag("LevelManager").GetComponent<LevelManger>().AddPoints(1);
        }
    }

}
