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
    public float stopDistance;

    private void Awake()
    {
        instance = this;
    }

    public void Throwbarbell()
    {
        if (GetComponent<EnemyController>().theBody.isVisible && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < shootRange && EnemyController.instance.moveDirection == Vector3.zero)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) > stopDistance)
            {
                fireCounter -= Time.deltaTime;

                if (fireCounter <= 0)
                {
                    anim.SetTrigger("isAttacking");
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                }
            }
           /* else if(Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) <= stopDistance)
            {
                anim.ResetTrigger("isAttacking");
            }
            */

        }
      
    }


    private void Update()
    {

        Throwbarbell();
    }
}
