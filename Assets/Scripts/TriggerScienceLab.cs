using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScienceLab : MonoBehaviour
{
    public float count = 2f;
    public GameObject key;
    public bool gotKey;

    private bool isStepping;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStepping)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                key.SetActive(true);
                gotKey = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isStepping = true;
        //if(isStepping && !gotKey)
        {
            //AudioManager.instance.PlaySFX(8);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStepping = false;
    }


}
