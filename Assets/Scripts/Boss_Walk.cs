using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Walk : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;

    public Rigidbody2D theRB;
    public Vector3 moveDirection;
    private Transform playerPos;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        theRB = animator.GetComponent<Rigidbody2D>();
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("idle");
        }
        else if(timer > 0)
        {

            timer -= Time.deltaTime;
        }

       // moveDirection = PlayerMovement.instance.transform.position - animator.transform.position;

        //moveDirection.Normalize();

       // theRB.velocity = moveDirection * speed;

        //Vector2 target = new Vector2(playerPos.position.x, playerPos.position.y);
        //animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
