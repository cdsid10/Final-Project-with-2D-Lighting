using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
 

    public Animator anim;
    public bool shouldShoot;

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;
    


    public void Throwbarbell()
    {
        fireCounter -= Time.deltaTime;

        if (fireCounter <= 0)
        {
          
            
            fireCounter = fireRate;
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);

        }
      
    }


    private void Update()
    {
      
        
    }
}
