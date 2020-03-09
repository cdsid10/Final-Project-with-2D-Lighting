using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{

    public static EnemyRangedAttack instance;

    public Animator anim;
    public bool shouldShoot;

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;
    public float shootRange;

    private void Awake()
    {
        instance = this;
    }

    public void Throwbarbell()
    {
        if (GetComponent<EnemyController>().theBody.isVisible && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < shootRange && EnemyController.instance.moveDirection == Vector3.zero)
        {
            fireCounter -= Time.deltaTime;

            if (fireCounter <= 0)
            {
                fireCounter = fireRate;
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            }
        }
      
    }


    private void Update()
    {
      
        
    }
}
