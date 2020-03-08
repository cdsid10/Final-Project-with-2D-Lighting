﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimHelper : MonoBehaviour
{
    public Animator anim;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Throw();
        done = false;
    }

    void Throw()
    {
        transform.parent.gameObject.GetComponent<EnemyRangedAttack>().Throwbarbell();
        anim.SetTrigger("isAttacking");
        done = true;
    }
}
