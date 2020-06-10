using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public static BossBehavior instance;

    private bool isFlipped;

    public bool shouldShoot;
    public float fireRate;
    private float fireCounter;

    public float shootRange;

    public GameObject bullet;
    public Transform firePoint;

    public float timer;

    public Animator anim;

    public bool shot;
    public Transform movePoints;
    private Vector3 moveDirection;

    public int health = 10;
    public bool dead;

    private void Awake()
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();

       // StartCoroutine(Tele());
        
    }

    

   // IEnumerator Tele()
    
        /*if (Portal.instance.fiveDone)
        {
            anim.SetTrigger("jump");
            yield return new WaitForSeconds(2);

            transform.position = new Vector2(movePoints.position.x, movePoints.position.y);

            yield return new WaitForSeconds(1);
            anim.SetTrigger("endJump");
            anim.SetTrigger("idle");

            Portal.instance.fiveDone = false;
            Portal.instance.canShoot = true;
        } */
    
    

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > PlayerMovement.instance.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < PlayerMovement.instance.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        

        

        if (health <= 0)
        {
            dead = true;
            StartCoroutine(Dead());
            
        }
    }

    IEnumerator Dead()
    {
        if (dead)
        {
            anim.SetTrigger("dead");
            yield return new WaitForSeconds(3.5f);
            gameObject.SetActive(false);
        }
    }
}



