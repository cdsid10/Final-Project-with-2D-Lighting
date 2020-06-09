using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public Transform player;
    public Animator anim;

    public bool isFlipped = false;

    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Tele()
    {
        anim.SetTrigger("jump");
        yield return new WaitForSeconds(1);

        transform.position = new Vector3(Random.Range(player.position.x - 5, player.position.x + 5), player.position.y, player.position.z);
        newPos = transform.position;

        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("endJump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Tele());
        return;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
