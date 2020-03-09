using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    
    public float stopDistance;

    [HideInInspector]
    public Transform player;
    public float speed;

    public float timeBwAttacks;
    private float attackTime;

    public float attackSpeed;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MeleeAttack();
    }

    public void MeleeAttack()
    {
        if(player != null)
        {
            if(Time.time >= attackTime)
            {
                StartCoroutine (Attack());
                attackTime = Time.time + timeBwAttacks;
            }
        }
    }

    IEnumerator Attack()
    {
        if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) <= stopDistance)
            {
            
            anim.SetTrigger("isMelee");
            Vector2 originalPosition = transform.position;
            Vector2 targetPosition = player.position;

            float percent = 0;
            while (percent <= 1)
            {
                percent += Time.deltaTime * attackSpeed;
                float formula = (-Mathf.Pow(percent, 3) + percent) * 2;
                transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
                yield return null;
            }
            PlayerHealthController.instance.DamagePlayer();
        }
    }
}
