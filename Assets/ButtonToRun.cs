using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToRun : MonoBehaviour
{
    public static ButtonToRun instance;

    public bool canStartDrill;
    public bool drillStarted;
    public bool isReset;

    public float countdown;
    private float timerStart;
    public bool timerRunning;
    public bool reset;

    public GameObject key;


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
       

        if(canStartDrill)
        {
            if(Input.GetKey(KeyCode.E))
            {
                timerRunning = true;
                drillStarted = true;
                
            }
            
        }
        if (timerRunning)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown > 0 && ButtonToEndRun.instance.hasCompleted)
        {
            key.SetActive(true);
            timerRunning = false;
        }
        else if (countdown <= 0)
        {
            reset = true;
        }

        if (reset)
        {
            countdown = 10f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canStartDrill = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canStartDrill = false;
    }
}
