using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontTarget : MonoBehaviour
{
    public static FrontTarget instance;

    public Animator anim;
    public GameObject fLight;
    public bool fisTriggered;

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
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullets")
        {
            anim.SetTrigger("pressed");
            yield return new WaitForSeconds(1);
            fLight.SetActive(true);
            fisTriggered = true;
        }
    }
}
