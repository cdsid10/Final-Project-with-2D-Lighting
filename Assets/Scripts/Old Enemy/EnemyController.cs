using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    public float stopDistance;
    public Vector3 moveDirection;

    public Animator anim;

    public int health = 150;

    public GameObject[] deathSplatters;
    public GameObject hitEffect;

    public SpriteRenderer theBody;

    public GameObject floatingText;

    private bool faceRight;

    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theBody.isVisible)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = PlayerMovement.instance.transform.position - transform.position;
                anim.ResetTrigger("isAttacking");
                if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) <= stopDistance)
                {
                    moveDirection = Vector3.zero;
                }
            }
            else
            {
                moveDirection = Vector3.zero;
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


            if(theRB.velocity.x > 0)
            {
                faceRight = true;
            }
            else if(theRB.velocity.x < 0)
            {
                faceRight = false;
            }

            if(faceRight)
            {
                theBody.flipX = false;
                anim.SetBool("Mirror", false);
            }
            else if( !faceRight)
            {
                theBody.flipX = true;
                anim.SetBool("Mirror", true);
            }
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        if (floatingText)
        {
            Instantiate(floatingText, transform.position, Quaternion.identity);
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
