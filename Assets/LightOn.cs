using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    public GameObject gLight;
    public GameObject playerLight;
    public GameObject flashLight;

    public bool canSwitchOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canSwitchOn)
        {
            gLight.SetActive(true);
            playerLight.SetActive(false);
            flashLight.SetActive(false);
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameObject.FindWithTag("Player"))
        {
            canSwitchOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canSwitchOn = false;
    }
}
