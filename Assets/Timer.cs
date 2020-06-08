using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonToRun.instance.timerRunning)
        {
            float t = ButtonToRun.instance.countdown;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = seconds;
        }
        if(Obstacles.instance.failed)
        {
            ButtonToRun.instance.reset = true;
        }
    }
}
