using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 4f;
    public float health = 20f;
    public TextMeshProUGUI hpDisplay;
    public Canvas canvas;

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
        Debug.Log(damageAmount);
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

    private void Update()
    {
        this.hpDisplay.text = $"{this.health} HP";
        this.canvas.transform.LookAt(new Vector3(this.canvas.transform.position.x, this.canvas.transform.position.y, 55));
    }
}
