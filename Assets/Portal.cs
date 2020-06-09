using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static Portal instance;

    public Animator anim;

    public bool spawned;

    public GameObject bullet;
    public Transform firePoint;

    public int timesShot;
    public bool fiveDone;
    public bool canShoot;

    public float fireRate;
    private float fireCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossBehavior.instance.gameObject.activeInHierarchy)
        {
            anim.SetTrigger("spawn");

            spawned = true;

            anim.SetTrigger("stay");


            if (spawned && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < 20f)
            {
                fireCounter -= Time.deltaTime;

                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);

                }
            }
        }
        else
        {
            anim.SetTrigger("end");
        }

    }

    

    void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.forward * 10f);
            timesShot++;
            if (timesShot >= 5)
            {
                
                fiveDone = true;
                canShoot = false;
            }
        }
    }


}
