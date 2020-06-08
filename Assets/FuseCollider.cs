using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseCollider : MonoBehaviour
{

    public GameObject tileMap;

    private bool canTrigger;
    public GameObject fuse;
    public Animator anim;

    public GameObject gLight, g2Light;
    public GameObject playerLight;
    public GameObject flashLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Open());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        


        if (GameObject.FindWithTag("Player"))
        {
            if (GameObject.Find("Fuse").GetComponent<FuseFollow>().hasFuse == true)
            {

                canTrigger = true;

            }
        }
    }

    IEnumerator Open()
    {
        if (canTrigger)
        {
            
            Destroy(GameObject.Find("Fuse"));

            
            yield return new WaitForSeconds(0.5f);
            fuse.SetActive(true);
            anim.SetTrigger("open");

            yield return new WaitForSeconds(3f);
            tileMap.SetActive(false);

           // gLight.SetActive(true);
            //g2Light.SetActive(false);
            //playerLight.SetActive(false);
            //flashLight.SetActive(false);
            Destroy(GameObject.Find("Fuse Animation"));
            Destroy(gameObject);
        }
    }
}
