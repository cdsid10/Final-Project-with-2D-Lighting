﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerMovement.instance.transform.position - transform.position;
        direction.Normalize();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (BossBehavior.instance.dead)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }

        Destroy(gameObject);
        //AudioManager.instance.PlaySFX(4);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}


