using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<WeaponController> weapons;
    public float speed = 5f;
    public GameObject levelManager;

    Vector2 controllerInput;
    Rigidbody rb;
    private List<GameObject> enemies;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemies = new List<GameObject>();
        
        RegisterAttacks();
    }

    void Update()
    {
        controllerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(controllerInput.x, 0, controllerInput.y);
        Vector3 targetPosition = transform.position + movementVector * Time.fixedDeltaTime * speed;
        rb.MovePosition(targetPosition);
    }
    
    void RegisterAttacks()
    {
        foreach (WeaponController weapon in this.weapons)
        {
            Action callback = () =>
            {
                enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
                enemies = enemies.OrderBy(enemy => Vector3.Distance(enemy.transform.position, transform.position)).ToList();

                weapon.Attack(enemies);
            };

            StartCoroutine(CreateCoroutine(callback, weapon.GetDelay()));
        }
    }

    private IEnumerator CreateCoroutine(Action f, float interval)
    {
        while(true)
        {
            f();

            yield return new WaitForSeconds(interval);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            levelManager.GetComponent<LevelManger>().ReducePlayerHeath(5);
        }
    }
}
