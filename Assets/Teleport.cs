using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public static Teleport instance;

    public Transform player;
    public Animator anim;

    public GameObject explosion;

    private bool canTele;
    
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
            
            transform.position = new Vector3(player.position.x + 2, player.position.y, player.position.z);
            yield return new WaitForSeconds(1);
            transform.position = gameObject.transform.position;
            anim.SetTrigger("endTele");
            
            anim.SetTrigger("charging");

            yield return new WaitForSeconds(2);


            anim.SetTrigger("dead");
            Instantiate(explosion, transform.position, Quaternion.identity);
            


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
}
