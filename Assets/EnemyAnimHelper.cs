using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimHelper : MonoBehaviour
{
    public Animator anim;
    public float shootRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Throw();
    }

    void Throw()
    {
        if (transform.parent.gameObject.GetComponent<EnemyRangedAttack>().shouldShoot == true && Vector3.Distance(EnemyRangedAttack.instance.transform.position, PlayerMovement.instance.transform.position) < shootRange && EnemyController.instance.moveDirection == Vector3.zero)
        {
            transform.parent.gameObject.GetComponent<EnemyRangedAttack>().Throwbarbell();
            anim.SetTrigger("isAttacking");
        }
    }
}
