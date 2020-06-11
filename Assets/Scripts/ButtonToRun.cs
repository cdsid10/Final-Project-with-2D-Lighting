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
    public float timeToAutoKey;
    private float timerStart;
    public bool timerRunning;
    public bool reset;

    public GameObject key;
    public GameObject arrow;


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
            timeToAutoKey -= Time.deltaTime;
        }
        if (countdown > 0 && ButtonToEndRun.instance.hasCompleted && Obstacles.instance.failed == false)
        {
            key.SetActive(true);
            timerRunning = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<ButtonToRun>().enabled = false;
        }
        
        if(timeToAutoKey <= 0)
        {
            key.SetActive(true);
        }


        if (countdown <= 0)
        {
            reset = true;
            //timerRunning = false;
            drillStarted = false;
            canStartDrill = false;
        }
        

        if (reset)
        {
            
            //timerRunning = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canStartDrill = true;
        arrow.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canStartDrill = false;
        arrow.SetActive(false);
    }
}
