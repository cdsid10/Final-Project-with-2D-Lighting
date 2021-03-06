﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClassC : MonoBehaviour
{
    public GameObject key;
    public Animator anim;

    private bool canTrigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Open());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindWithTag("Player"))
        {
            if (GameObject.Find("Key Class C").GetComponent<KeyFollow>().hasKey == true)
            {

                canTrigger = true;

            }
        }
    }

    IEnumerator Open()
    {
        if (canTrigger)
        {
            Destroy(GameObject.Find("Key Class C"));
            yield return new WaitForSeconds(0.5f);
            key.SetActive(true);
            anim.SetTrigger("open");

            yield return new WaitForSeconds(2f);
            AudioManager.instance.PlaySFX(0);
            Destroy(GameObject.Find("Class C Key Animation"));
            Destroy(gameObject);
        }
    }
}
