using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public bool isMoving;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public bool isShooting;

    public GameObject projectile;
    public Transform firePoint;

    public Transform player;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            isShooting = true;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        

     
        

    }

    void ThrowShoot()
    {
        if (timeBtwShots <= 0)
        {
            isShooting = true;
            if (isShooting)
            {
                anim.SetBool("isShooting", true);

                Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
            isShooting = false;
        }
    }
}
