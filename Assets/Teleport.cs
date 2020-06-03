using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public static Teleport instance;

    public SpriteRenderer theSR;
    public Transform player;
    public Animator anim;

    public GameObject explosion;
    private GameObject inst;

    private bool canTele;
    bool hasTele;

    private Vector3 newPos;

    //public Vector3 teleLocation = new Vector3(player.position.x + 2, player.position.y, player.position.z);

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
        
    }

    IEnumerator Tele()
    {
        if (canTele)
        {
            anim.SetTrigger("startTele");
            yield return new WaitForSeconds(2);

            if (!hasTele)
            {
                transform.position = new Vector3(Random.Range(player.position.x - 2, player.position.x + 2), player.position.y, player.position.z);
                if(transform.position.x > player.transform.position.x)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else if(transform.position.x < player.transform.position.x)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                } 
                newPos = transform.position;
                hasTele = true;
                yield return new WaitForSeconds(1);
            }
            
            anim.SetTrigger("endTele");
            yield return new WaitForSeconds(0.3f);
            
            anim.SetTrigger("charging");
            yield return new WaitForSeconds(2);
            


            anim.SetTrigger("dead");
            
            inst = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
            Destroy(inst, 1);
            Destroy(gameObject);
            
            


        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTele = true;
        StartCoroutine(Tele());

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTele = false;
    }
}
