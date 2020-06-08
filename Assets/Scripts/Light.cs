using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject dLight;
    public GameObject globalLightLow;
    public GameObject playerLight;
    public GameObject flashLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dLight.SetActive(false);
        globalLightLow.SetActive(true);
        playerLight.SetActive(true);
        flashLight.SetActive(true);
    }

    
}
