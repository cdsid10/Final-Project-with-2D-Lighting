using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private float Speed;
    private bool RestoreTime;

    public GameObject impactEffect;

    private void Start()
    {
        RestoreTime = false;
    }

    private void Update()
    {
        if(RestoreTime)
        {
            if (Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * Speed;
            }
            else
            {
                Time.timeScale = 1f;
                RestoreTime = false;
            }
        }
    }

    public void StopTime(float changeTime, int RestoreSpeed, float Delay)
        {
        Speed = RestoreSpeed;

        if (Delay > 0 && PlayerMovement.instance.enabled == true)
        {
            StopCoroutine(StartTimeAgain(Delay));
            StartCoroutine(StartTimeAgain(Delay));
        }
        else
        {
            RestoreTime = true;
        }

        //Instantiate(impactEffect, transform.position, Quaternion.identity);

        Time.timeScale = changeTime;


        }

    IEnumerator StartTimeAgain(float amt)
    {
        RestoreTime = true;
        yield return new WaitForSecondsRealtime(amt);
    }

}
