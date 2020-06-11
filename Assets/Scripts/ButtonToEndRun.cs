using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToEndRun : MonoBehaviour
{
    public static ButtonToEndRun instance;

    public bool hasCompleted;


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
        if(hasCompleted)
        {
            ButtonToRun.instance.canStartDrill = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ButtonToRun.instance.countdown > 0 && Obstacles.instance.failed == false)
        {
            hasCompleted = true;
        }
        else
        {
            hasCompleted = false;
        }
    }
}
