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
    public bool canShoot = true;

    public AudioSource audioShoot;
    public AudioClip Pew;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (Input.GetMouseButton(0))
            {
                startTime += Time.deltaTime;
                //AudioManager.instance.PlaySFX(4);

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
                //anim.SetBool("isShooting", false);
                anim.SetTrigger("idle");
            }




            if (Input.GetMouseButton(0))
            {
                //audioShoot.PlayOneShot(Pew, 0.5f);
                anim.SetBool("isShooting", true);
                textAnim.SetBool("charged", true);
                chargedText.SetActive(true);

            }
            else if(startTime < endTime)
            {
                anim.SetBool("isShooting", false);
                anim.SetTrigger("idle");
                textAnim.SetBool("charged", false);
                chargedText.SetActive(false);
            }
        }
    }
    
}

    

