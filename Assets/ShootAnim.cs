using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAnim : MonoBehaviour
{
    public Animator anim;
    public GameObject[] bullets;
    public Transform firePoint;

    public float timeBetweenShots;
    private float shotCounter;

    public float startTime;
    public float endTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            startTime += Time.deltaTime;
        }

            if (startTime >= endTime)
            {


                if (Input.GetMouseButtonUp(0))
                {

                    anim.SetTrigger("shotaf");

                    Instantiate(bullets[Random.Range(0, bullets.Length)], firePoint.position, firePoint.rotation);

                    shotCounter = timeBetweenShots;

                    startTime = 0;
                }

            }
        

        if (Input.GetMouseButton(0))
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }
    
}

    

