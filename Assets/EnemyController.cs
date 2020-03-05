using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    public Animator anim;

    public int health = 150;

    public GameObject[] deathSplatters;
    public GameObject hitEffect;

    public GameObject floatingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < rangeToChasePlayer)
        {
            moveDirection = PlayerMovement.instance.transform.position - transform.position;
        }

        moveDirection.Normalize();

        theRB.velocity = moveDirection * moveSpeed;

        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;
        if (floatingText)
        {
            Instantiate(floatingText, transform.position, Quaternion.identity, transform);
        }

        Instantiate(hitEffect, transform.position, transform.rotation);

        if(health <= 0)
        {
            Destroy(gameObject);

            int rotation = Random.Range(0, 4);
            Instantiate(deathSplatters[Random.Range(0, deathSplatters.Length)], transform.position, Quaternion.Euler(0, 0, rotation * 90));
        }
    }
}
