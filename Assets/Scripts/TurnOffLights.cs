using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    public GameObject dLight;
    public GameObject globalLightLow;
    public GameObject playerLight;
    public GameObject flashLight;

    public GameObject[] allLights;

    public bool canAccess;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canAccess)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dLight.SetActive(true);
                globalLightLow.SetActive(false);
                playerLight.SetActive(false);
                flashLight.SetActive(false);

                foreach (GameObject obj in allLights)
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canAccess = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canAccess = false;
    }
}

