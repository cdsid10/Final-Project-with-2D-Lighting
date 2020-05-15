using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAnim : MonoBehaviour
{
    public static ShootAnim instance;

    public Animator anim;
    public Animator textAnim;
    public GameObject[] bullets;
    public Transform firePoint;
    public GameObject chargedText;

    public float timeBetweenShots;
    private float shotCounter;

    public float startTime;
    public float endTime;


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
        if (!Dialog.instance.isTalking)
        {
            if (Input.GetMouseButton(0))
            {
                startTime += Time.deltaTime;

            }



            if (Input.GetMouseButtonUp(0) && startTime >= endTime)
            {

                anim.SetTrigger("shotaf");

                Instantiate(bullets[Random.Range(0, bullets.Length)], firePoint.position, firePoint.rotation);

                shotCounter = timeBetweenShots;

                startTime = 0;


            }
            else if (Input.GetMouseButtonUp(0) && startTime < endTime)
            {
                startTime = 0;
            }




            if (Input.GetMouseButton(0))
            {
                anim.SetBool("isShooting", true);
                textAnim.SetBool("charged", true);
                chargedText.SetActive(true);

            }
            else
            {
                anim.SetBool("isShooting", false);
                textAnim.SetBool("charged", false);
                chargedText.SetActive(false);
            }
        }
    }
    
}

    

